using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class SudokuCell : Button
    {
        public int Value { get; set; }
        public bool IsLocked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsUserInput { get; set; }


        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
            this.IsUserInput = false;
        }
    }

    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.easyLevel = new System.Windows.Forms.RadioButton();
            this.mediumLevel = new System.Windows.Forms.RadioButton();
            this.hardLevel = new System.Windows.Forms.RadioButton();
            this.newGameButton = new System.Windows.Forms.Button();
            this.numberPanel1 = new System.Windows.Forms.Panel();
            this.panelbutton1 = new System.Windows.Forms.Button();
            this.panelbutton2 = new System.Windows.Forms.Button();
            this.panelbutton3 = new System.Windows.Forms.Button();
            this.panelbutton4 = new System.Windows.Forms.Button();
            this.panelbutton5 = new System.Windows.Forms.Button();
            this.panelbutton6 = new System.Windows.Forms.Button();
            this.panelbutton7 = new System.Windows.Forms.Button();
            this.panelbutton8 = new System.Windows.Forms.Button();
            this.panelbutton9 = new System.Windows.Forms.Button();
            this.numberPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 370);
            this.panel1.TabIndex = 0;
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.checkButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.checkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkButton.Location = new System.Drawing.Point(408, 13);
            this.checkButton.Margin = new System.Windows.Forms.Padding(4);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(325, 70);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Check Input";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearButton.Location = new System.Drawing.Point(408, 91);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(325, 71);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear Input";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Difficulty";
            // 
            // easyLevel
            // 
            this.easyLevel.AutoSize = true;
            this.easyLevel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyLevel.Location = new System.Drawing.Point(413, 253);
            this.easyLevel.Margin = new System.Windows.Forms.Padding(4);
            this.easyLevel.Name = "easyLevel";
            this.easyLevel.Size = new System.Drawing.Size(54, 22);
            this.easyLevel.TabIndex = 4;
            this.easyLevel.TabStop = true;
            this.easyLevel.Text = "Easy";
            this.easyLevel.UseVisualStyleBackColor = true;
            // 
            // mediumLevel
            // 
            this.mediumLevel.AutoSize = true;
            this.mediumLevel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumLevel.Location = new System.Drawing.Point(413, 283);
            this.mediumLevel.Margin = new System.Windows.Forms.Padding(4);
            this.mediumLevel.Name = "mediumLevel";
            this.mediumLevel.Size = new System.Drawing.Size(76, 22);
            this.mediumLevel.TabIndex = 5;
            this.mediumLevel.TabStop = true;
            this.mediumLevel.Text = "Medium";
            this.mediumLevel.UseVisualStyleBackColor = true;
            // 
            // hardLevel
            // 
            this.hardLevel.AutoSize = true;
            this.hardLevel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardLevel.Location = new System.Drawing.Point(413, 313);
            this.hardLevel.Margin = new System.Windows.Forms.Padding(4);
            this.hardLevel.Name = "hardLevel";
            this.hardLevel.Size = new System.Drawing.Size(57, 22);
            this.hardLevel.TabIndex = 6;
            this.hardLevel.TabStop = true;
            this.hardLevel.Text = "Hard";
            this.hardLevel.UseVisualStyleBackColor = true;
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.newGameButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newGameButton.Location = new System.Drawing.Point(518, 215);
            this.newGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(215, 120);
            this.newGameButton.TabIndex = 6;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // numberPanel1
            // 
            this.numberPanel1.Controls.Add(this.panelbutton9);
            this.numberPanel1.Controls.Add(this.panelbutton8);
            this.numberPanel1.Controls.Add(this.panelbutton7);
            this.numberPanel1.Controls.Add(this.panelbutton6);
            this.numberPanel1.Controls.Add(this.panelbutton5);
            this.numberPanel1.Controls.Add(this.panelbutton4);
            this.numberPanel1.Controls.Add(this.panelbutton3);
            this.numberPanel1.Controls.Add(this.panelbutton2);
            this.numberPanel1.Controls.Add(this.panelbutton1);
            this.numberPanel1.Location = new System.Drawing.Point(408, 169);
            this.numberPanel1.Name = "numberPanel1";
            this.numberPanel1.Size = new System.Drawing.Size(325, 36);
            this.numberPanel1.TabIndex = 7;
            // 
            // panelbutton1
            // 
            this.panelbutton1.FlatAppearance.BorderSize = 0;
            this.panelbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton1.Location = new System.Drawing.Point(5, 3);
            this.panelbutton1.Name = "panelbutton1";
            this.panelbutton1.Size = new System.Drawing.Size(30, 30);
            this.panelbutton1.TabIndex = 0;
            this.panelbutton1.Text = "1";
            this.panelbutton1.UseVisualStyleBackColor = false;
            // 
            // panelbutton2
            // 
            this.panelbutton2.FlatAppearance.BorderSize = 0;
            this.panelbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton2.Location = new System.Drawing.Point(40, 3);
            this.panelbutton2.Name = "panelbutton2";
            this.panelbutton2.Size = new System.Drawing.Size(30, 30);
            this.panelbutton2.TabIndex = 1;
            this.panelbutton2.Text = "2";
            this.panelbutton2.UseVisualStyleBackColor = false;
            // 
            // panelbutton3
            // 
            this.panelbutton3.FlatAppearance.BorderSize = 0;
            this.panelbutton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton3.Location = new System.Drawing.Point(76, 3);
            this.panelbutton3.Name = "panelbutton3";
            this.panelbutton3.Size = new System.Drawing.Size(30, 30);
            this.panelbutton3.TabIndex = 1;
            this.panelbutton3.Text = "3";
            this.panelbutton3.UseVisualStyleBackColor = false;
            // 
            // panelbutton4
            // 
            this.panelbutton4.FlatAppearance.BorderSize = 0;
            this.panelbutton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton4.Location = new System.Drawing.Point(112, 3);
            this.panelbutton4.Name = "panelbutton4";
            this.panelbutton4.Size = new System.Drawing.Size(30, 30);
            this.panelbutton4.TabIndex = 1;
            this.panelbutton4.Text = "4";
            this.panelbutton4.UseVisualStyleBackColor = false;
            // 
            // panelbutton5
            // 
            this.panelbutton5.FlatAppearance.BorderSize = 0;
            this.panelbutton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton5.Location = new System.Drawing.Point(148, 3);
            this.panelbutton5.Name = "panelbutton5";
            this.panelbutton5.Size = new System.Drawing.Size(30, 30);
            this.panelbutton5.TabIndex = 1;
            this.panelbutton5.Text = "5";
            this.panelbutton5.UseVisualStyleBackColor = false;
            // 
            // panelbutton6
            // 
            this.panelbutton6.FlatAppearance.BorderSize = 0;
            this.panelbutton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton6.Location = new System.Drawing.Point(184, 3);
            this.panelbutton6.Name = "panelbutton6";
            this.panelbutton6.Size = new System.Drawing.Size(30, 30);
            this.panelbutton6.TabIndex = 1;
            this.panelbutton6.Text = "6";
            this.panelbutton6.UseVisualStyleBackColor = false;
            // 
            // panelbutton7
            // 
            this.panelbutton7.FlatAppearance.BorderSize = 0;
            this.panelbutton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton7.Location = new System.Drawing.Point(220, 3);
            this.panelbutton7.Name = "panelbutton7";
            this.panelbutton7.Size = new System.Drawing.Size(30, 30);
            this.panelbutton7.TabIndex = 1;
            this.panelbutton7.Text = "7";
            this.panelbutton7.UseVisualStyleBackColor = false;
            // 
            // panelbutton8
            // 
            this.panelbutton8.FlatAppearance.BorderSize = 0;
            this.panelbutton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton8.Location = new System.Drawing.Point(256, 3);
            this.panelbutton8.Name = "panelbutton8";
            this.panelbutton8.Size = new System.Drawing.Size(30, 30);
            this.panelbutton8.TabIndex = 1;
            this.panelbutton8.Text = "8";
            this.panelbutton8.UseVisualStyleBackColor = false;
            // 
            // panelbutton9
            // 
            this.panelbutton9.FlatAppearance.BorderSize = 0;
            this.panelbutton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelbutton9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.panelbutton9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelbutton9.Location = new System.Drawing.Point(292, 3);
            this.panelbutton9.Name = "panelbutton9";
            this.panelbutton9.Size = new System.Drawing.Size(30, 30);
            this.panelbutton9.TabIndex = 1;
            this.panelbutton9.Text = "9";
            this.panelbutton9.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(744, 402);
            this.Controls.Add(this.numberPanel1);
            this.Controls.Add(this.hardLevel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.mediumLevel);
            this.Controls.Add(this.easyLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Sudoku";
            this.numberPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Button checkButton;
        private Button clearButton;
        private Label label1;
        private RadioButton easyLevel;
        private RadioButton hardLevel;
        private RadioButton mediumLevel;
        private Button newGameButton;
        private Panel numberPanel1;
        private Button panelbutton1;
        private Button panelbutton9;
        private Button panelbutton8;
        private Button panelbutton7;
        private Button panelbutton6;
        private Button panelbutton5;
        private Button panelbutton4;
        private Button panelbutton3;
        private Button panelbutton2;
    }
}

