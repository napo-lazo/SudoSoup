namespace SudoSoup
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.WindowTable = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonsTable = new System.Windows.Forms.TableLayoutPanel();
            this.SudokuBtn = new System.Windows.Forms.Button();
            this.WordSearchBtn = new System.Windows.Forms.Button();
            this.WindowTable.SuspendLayout();
            this.ButtonsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowTable
            // 
            this.WindowTable.ColumnCount = 3;
            this.WindowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
            this.WindowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.94118F));
            this.WindowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
            this.WindowTable.Controls.Add(this.ButtonsTable, 1, 1);
            this.WindowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowTable.Location = new System.Drawing.Point(0, 0);
            this.WindowTable.Name = "WindowTable";
            this.WindowTable.RowCount = 3;
            this.WindowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.62162F));
            this.WindowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.75676F));
            this.WindowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.62162F));
            this.WindowTable.Size = new System.Drawing.Size(800, 450);
            this.WindowTable.TabIndex = 0;
            // 
            // ButtonsTable
            // 
            this.ButtonsTable.ColumnCount = 1;
            this.ButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.Controls.Add(this.SudokuBtn, 0, 0);
            this.ButtonsTable.Controls.Add(this.WordSearchBtn, 0, 1);
            this.ButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsTable.Location = new System.Drawing.Point(191, 100);
            this.ButtonsTable.Name = "ButtonsTable";
            this.ButtonsTable.RowCount = 2;
            this.ButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.Size = new System.Drawing.Size(417, 249);
            this.ButtonsTable.TabIndex = 0;
            // 
            // SudokuBtn
            // 
            this.SudokuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SudokuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SudokuBtn.Location = new System.Drawing.Point(15, 30);
            this.SudokuBtn.Margin = new System.Windows.Forms.Padding(15, 30, 15, 30);
            this.SudokuBtn.Name = "SudokuBtn";
            this.SudokuBtn.Size = new System.Drawing.Size(387, 64);
            this.SudokuBtn.TabIndex = 0;
            this.SudokuBtn.Text = "Sudoku";
            this.SudokuBtn.UseVisualStyleBackColor = true;
            this.SudokuBtn.Click += new System.EventHandler(this.SudokuBtn_Click);
            // 
            // WordSearchBtn
            // 
            this.WordSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WordSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordSearchBtn.Location = new System.Drawing.Point(15, 154);
            this.WordSearchBtn.Margin = new System.Windows.Forms.Padding(15, 30, 15, 30);
            this.WordSearchBtn.Name = "WordSearchBtn";
            this.WordSearchBtn.Size = new System.Drawing.Size(387, 65);
            this.WordSearchBtn.TabIndex = 1;
            this.WordSearchBtn.Text = "Word Search";
            this.WordSearchBtn.UseVisualStyleBackColor = true;
            this.WordSearchBtn.Click += new System.EventHandler(this.WordSearchBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WindowTable);
            this.Name = "MainForm";
            this.Text = "Sudo Soup";
            this.WindowTable.ResumeLayout(false);
            this.ButtonsTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel WindowTable;
        private System.Windows.Forms.TableLayoutPanel ButtonsTable;
        private System.Windows.Forms.Button SudokuBtn;
        private System.Windows.Forms.Button WordSearchBtn;
    }
}

