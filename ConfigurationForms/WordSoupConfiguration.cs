using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudoSoup.ConfigurationForms
{
    public partial class WordSoupConfiguration : Form
    {
        public int? seedValue { get; set; }
        public string[] wordList { get; set; }

        public WordSoupConfiguration()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string seedText = this.SeedTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(seedText))
                this.seedValue = Convert.ToInt32(seedText);

            this.wordList = WordsTextBox.Lines.Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void WordsTextBox_TextChanged(object sender, EventArgs e)
        {
            GenerateButton.Enabled = WordsTextBox.Text.Trim().Length != 0;
        }

        private void WordsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}
