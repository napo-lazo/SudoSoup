namespace SudoSoup.ConfigurationForms
{
    partial class WordSoupConfiguration
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.WordsTextBox = new System.Windows.Forms.TextBox();
            this.SeedTextBox = new System.Windows.Forms.TextBox();
            this.SeedLabel = new System.Windows.Forms.Label();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.GenerateButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.WordsTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.SeedTextBox, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.SeedLabel, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.InstructionsLabel, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.Enabled = false;
            this.GenerateButton.Location = new System.Drawing.Point(345, 393);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(108, 23);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate Wordsoup";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // WordsTextBox
            // 
            this.WordsTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.WordsTextBox, 2);
            this.WordsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WordsTextBox.Location = new System.Drawing.Point(117, 183);
            this.WordsTextBox.Multiline = true;
            this.WordsTextBox.Name = "WordsTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.WordsTextBox, 2);
            this.WordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WordsTextBox.Size = new System.Drawing.Size(222, 145);
            this.WordsTextBox.TabIndex = 1;
            this.WordsTextBox.TextChanged += new System.EventHandler(this.WordsTextBox_TextChanged);
            this.WordsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WordsTextBox_KeyPress);
            // 
            // SeedTextBox
            // 
            this.SeedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.SeedTextBox, 2);
            this.SeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.SeedTextBox.Location = new System.Drawing.Point(459, 207);
            this.SeedTextBox.MaxLength = 10;
            this.SeedTextBox.Name = "SeedTextBox";
            this.SeedTextBox.Size = new System.Drawing.Size(222, 35);
            this.SeedTextBox.TabIndex = 2;
            this.SeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SeedTextBox_KeyPress);
            // 
            // SeedLabel
            // 
            this.SeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SeedLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.SeedLabel, 3);
            this.SeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SeedLabel.Location = new System.Drawing.Point(459, 122);
            this.SeedLabel.Name = "SeedLabel";
            this.SeedLabel.Size = new System.Drawing.Size(307, 26);
            this.SeedLabel.TabIndex = 3;
            this.SeedLabel.Text = "Seed for Wordsoup generation";
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InstructionsLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.InstructionsLabel, 3);
            this.InstructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.InstructionsLabel.Location = new System.Drawing.Point(459, 302);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(311, 26);
            this.InstructionsLabel.TabIndex = 4;
            this.InstructionsLabel.Text = "Leave blank for a random seed";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(117, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Word list for Wordsoup";
            // 
            // WordSoupConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WordSoupConfiguration";
            this.Text = "WordSoupConfiguration";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox WordsTextBox;
        private System.Windows.Forms.TextBox SeedTextBox;
        private System.Windows.Forms.Label SeedLabel;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Label label1;
    }
}