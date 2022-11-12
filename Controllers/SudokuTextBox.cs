using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudoSoup.Controllers
{
    public partial class SudokuTextBox : TextBox
    {
        public SudokuTextBox(string text)
        {
            InitializeComponent();
            TextAlign = HorizontalAlignment.Center;
            Dock = DockStyle.Fill;
            MaxLength = 1;
            Text = text;

            if (!string.IsNullOrWhiteSpace(text))
                Enabled = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void SudokuTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SudokuTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
