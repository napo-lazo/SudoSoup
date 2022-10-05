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
            this.GameContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameContainer
            // 
            this.GameContainer.ColumnCount = 3;
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.27659F));
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.GameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2766F));
            this.GameContainer.Controls.Add(this.GameGrid, 1, 1);
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameContainer);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.GameContainer.ResumeLayout(false);
            this.GameContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GameContainer;
        private System.Windows.Forms.TableLayoutPanel GameGrid;
    }
}