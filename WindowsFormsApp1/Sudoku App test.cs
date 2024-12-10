using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SudokuCell selectedCell;
        Random randomHint = new Random();
        Random random = new Random();
        SudokuCell[,] cells = new SudokuCell[9, 9];

        //New array for calculating which numbers are used up and which have some left
        int[] remainingNumbers = new int[9];

        public Form1()
        {
            InitializeComponent();
            InitializeRemainingNumbers();

            createCells();

            startNewGame();
        }

        private void startNewGame()
        {
            loadValues();

            var hintsCount = 0;

            if (easyLevel.Checked)
            {
                hintsCount = 65;
            }
            else if (mediumLevel.Checked)
            {
                hintsCount = 55;
            }
            else 
            { 
                hintsCount = 35;
            }

            //Show values of 45 cells as hints
            showRandomValueHints(hintsCount);
        }

        private void showRandomValueHints(int hintsCount)
        {
            //Show value in random cells
            //hints count is based on level player chooses
            for (int i = 0; i < hintsCount; i++)
            {
                var rX = randomHint.Next(9);
                var rY = randomHint.Next(9);

                //Style hint cells differently
                //lock cell so player cannot edit the value
                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
                cells[rX, rY].ForeColor = Color.Black;
                cells[rX, rY].IsLocked = true;
            }

        }

        private void loadValues()
        {
            //clear the values in each cell
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
            }

            //this will be called recursively
            //until it finds a suitable value for each cell
            findValueForNextCell(0, -1);
        }



        private bool findValueForNextCell(int i, int j)
        {
            //increment the i and j values to move to the next cell
            //and if the column ends, move to the next row.
            if (++j > 8)
            {
                j = 0;
                //exit if the line ends
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //find a valid and random number for the cell and move to the next cell
            //and check if it can be allocated with another random number
            do
            {
                //if there are no numbers left in the list to try
                //return to the previous cell and allocate it with a different number
                if (numsLeft.Count < 1)
                {
                    cells[i,j].Value = 0;
                    return false;
                }

                //take a random number for the numbers left list
                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i,j].Value = value;

                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForNextCell(i, j));
            
            return true;
        }

        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                //check all cells in a vertical direction
                if (i != y && cells[x, i].Value == value)
                    return false;

                //check all cells in a horizontal direction
                if (i != x && cells[i, y].Value == value)
                    return false;
            }
            
            //check all the cells in the specific block
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Create 81 cells for with styles and locations based on the index 
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    //Key Press event assigned for each cell
                    cells[i, j].Enter += cell_Enter;

                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        public void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;
            int value;

            //do nothing if the cell is locked
            if (cell.IsLocked)
            {
                return;
            }

            //Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                if (value == 0 && !string.IsNullOrEmpty(cell.Text))
                {
                    int oldValue = int.Parse(cell.Text);
                    remainingNumbers[oldValue - 1]++;
                }
                else if (value > 0 && value <= 9)
                {
                    if (!string.IsNullOrEmpty(cell.Text))
                    {
                        int oldValue = int.Parse(cell.Text);
                        remainingNumbers[oldValue + 1]++;
                    }
                    remainingNumbers[value - 1]--;
                }

                cell.Text = value.ToString();
                cell.ForeColor = System.Drawing.Color.MediumBlue;
                cell.IsUserInput = true;

                UpdateNumberPanel();

                //Check if game is completed
                endGameMechanic();
            }
            else if (value == 0)
            {
                cell.Clear();
                cell.ForeColor = SystemColors.ControlDark;
            }
        }

        private void UpdateNumberPanel()
        {
            foreach (Button btn in numberPanel1.Controls)
            {
                int num = (int)btn.Tag;

                btn.Enabled = remainingNumbers[num - 1] > 0;
                btn.Visible = remainingNumbers[num - 1] > 0;
            }
        }

        private void InitializeRemainingNumbers()
        {
            for (int i = 0; i < 9; i++)
            {
                remainingNumbers[i] = 9;
            }
        }

        private void cell_Enter(object sender, EventArgs e)
        {
            // Clear highlights
            clearHighlights();

            //Get the selected cell
            selectedCell = sender as SudokuCell;

            if (selectedCell == null)
            {
                return;
            }

            //Highlight the row and column

            highlightRowAndColumn(selectedCell.X, selectedCell.Y);

            //Highlight cells with same value

            if (!string.IsNullOrEmpty(selectedCell.Text))
            {
                highlightSameValueCells(selectedCell.Text);
            }
        }

        private void highlightRowAndColumn(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                //Highlight the column
                cells[x, i].BackColor = System.Drawing.Color.LightSteelBlue;
              

                //Highlight the row
                cells[i, y].BackColor = System.Drawing.Color.LightSteelBlue;

            }
        }

        private void highlightSameValueCells(string value)
        {
            foreach (var cell in cells)
            {
                if (cell.Text == value && !string.IsNullOrEmpty(value))
                {
                    cell.BackColor = SystemColors.AppWorkspace;
                    cell.Font = new Font(SystemFonts.DefaultFont.FontFamily, 20, FontStyle.Bold);
                }
            }
        }

        private void clearHighlights()
        {
            foreach (var cell in cells)
                if (cell.IsUserInput == true)
                {
                    cell.BackColor = ((cell.X / 3) + (cell.Y / 3)) % 2 == 0 ? SystemColors.Control
                        : Color.LightGray;
                    cell.Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cell.ForeColor = System.Drawing.Color.MediumBlue;
                    cell.FlatAppearance.BorderSize = 1;
                }
                else
                {
                    cell.BackColor = ((cell.X / 3) + (cell.Y / 3)) % 2 == 0 ? SystemColors.Control
                        : Color.LightGray;
                    cell.Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cell.ForeColor = SystemColors.InfoText;
                    cell.FlatAppearance.BorderSize = 1;
                }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            var wrongCells = new List<SudokuCell>();
            var userInputCells = new List<SudokuCell>();

            foreach (var cell in cells)
            {
                if (cell.IsUserInput)
                {
                    userInputCells.Add(cell);
                }

                if (!string.Equals(cell.Value.ToString(), cell.Text) && cell.IsUserInput)
                {
                    wrongCells.Add(cell);
                }
            }

            if (wrongCells.Any())
            {
                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show("Incorrect numbers");
            }
            else if (userInputCells.Any())
            {
                MessageBox.Show($"No wrong numbers and you have {CellsRemaining()} cells remaining!");
            }
        }

        private bool IsGameEnd()
        {
            foreach (var cell in cells)
            {
                if (string.IsNullOrEmpty(cell.Text))
                {
                    return false;
                }

                if (!string.Equals(cell.Value.ToString(), cell.Text))
                {
                    return false;
                }
            }

            return true;
        }

        public void endGameMechanic()

        {
            if (CountFilledCells() == 81)
            {
                if (IsGameEnd())
                {
                    MessageBox.Show("Congratulations!");
                }
                else
                {
                    MessageBox.Show("Some cells are incorrect, please use the 'Check Input' button for assistance");
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if(cell.IsLocked == false)
                {
                    cell.Clear();
                    cell.ForeColor = SystemColors.ControlDarkDark;
                }
            }
        }

        public int CountFilledCells()
        {
            int filledCount = 0;

            foreach (var cell in cells)
            {
                if (!string.IsNullOrEmpty(cell.Text))
                {
                    filledCount++;
                }

            }

            return filledCount;
        }

        public int CellsRemaining()

        {
            int count = 81 - CountFilledCells();
            return count;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

    }
}

   