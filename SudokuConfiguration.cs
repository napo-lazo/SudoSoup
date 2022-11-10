using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudoSoup
{
    public partial class SudokuConfiguration : Form
    {
        public int? seedValue { get; set; }

        public SudokuConfiguration()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string seedText = this.SeedTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(seedText))
                this.seedValue = Convert.ToInt32(seedText);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
