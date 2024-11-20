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
        public Form1()
        {
            InitializeComponent();

            createCells();

            startNewGame();
        }

        private void startNewGame()
        {
            loadValues();

            var hintsCount = 0;

            if (easyLevel.Checked)
                hintsCount = 45;

            else if (mediumLevel.Checked)
                hintsCount = 30;

            else if (hardLevel.Checked)
                hintsCount = 15;

            //Show values of 45 cells as hints
            showRandomValueHints(hintsCount);
        }

        Random randomHint = new Random();

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

        Random random = new Random();

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
            var numsLeft= new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

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

        SudokuCell[,] cells = new SudokuCell[9, 9];

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
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    //Key Press event assigned for each cell
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            //do nothing if the cell is locked
            if (cell.IsLocked)
                return;

            int value;

            //Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                //clear the cell value if the key pressed is "0"
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wrongCells = new List<SudokuCell>();

            foreach (var cell in cells)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text))
                {
                    wrongCells.Add(cell);
                }
            }

            if (wrongCells.Any())
            {
                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show("Incorrect numbers");
            }
            else
            {
                MessageBox.Show("Congratulations!");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if(cell.IsLocked == false)
                    cell.Clear();
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            startNewGame();
        }
    }
}

   