namespace SudoSoup
{
    partial class GameForm
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
            this.GameContainer = new System.Windows.Forms.TableLayoutPanel();
            this.GameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameContainer
            // 
            this.GameContainer.ColumnCount = 3;
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.27659F));
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2766F));
            this.GameContainer.Controls.Add(this.GameGrid, 1, 1);
            this.GameContainer.Controls.Add(this.menuStrip1, 0, 0);
            this.GameContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameContainer.Location = new System.Drawing.Point(0, 0);
            this.GameContainer.Name = "GameContainer";
            this.GameContainer.RowCount = 3;
            this.GameContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.27659F));
            this.GameContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.GameContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.27659F));
            this.GameContainer.Size = new System.Drawing.Size(800, 450);
            this.GameContainer.TabIndex = 0;
            // 
            // GameGrid
            // 
            this.GameGrid.AutoSize = true;
            this.GameGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.GameGrid.ColumnCount = 2;
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameGrid.Location = new System.Drawing.Point(173, 98);
            this.GameGrid.Name = "GameGrid";
            this.GameGrid.RowCount = 2;
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameGrid.Size = new System.Drawing.Size(453, 252);
            this.GameGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.GameContainer.SetColumnSpan(this.menuStrip1, 3);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsPDFToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newToolStripMenuItem.Text = "New ";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveAsPDFToolStripMenuItem
            // 
            this.saveAsPDFToolStripMenuItem.Name = "saveAsPDFToolStripMenuItem";
            this.saveAsPDFToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAsPDFToolStripMenuItem.Text = "Save as PDF";
            this.saveAsPDFToolStripMenuItem.Click += new System.EventHandler(this.saveAsPDFToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendixToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Visible = false;
            // 
            // appendixToolStripMenuItem
            // 
            this.appendixToolStripMenuItem.Checked = true;
            this.appendixToolStripMenuItem.CheckOnClick = true;
            this.appendixToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendixToolStripMenuItem.Name = "appendixToolStripMenuItem";
            this.appendixToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.appendixToolStripMenuItem.Text = "Appendix";
            this.appendixToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.appendixToolStripMenuItem_CheckStateChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameContainer);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.GameContainer.ResumeLayout(false);
            this.GameContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GameContainer;
        private System.Windows.Forms.TableLayoutPanel GameGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendixToolStripMenuItem;
    }
}