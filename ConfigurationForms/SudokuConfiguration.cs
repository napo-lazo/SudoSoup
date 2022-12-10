using System;
using System.Windows.Forms;

namespace SudoSoup.ConfigurationForms
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

        private void SeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
