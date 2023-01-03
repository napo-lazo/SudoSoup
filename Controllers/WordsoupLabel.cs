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
    public partial class WordsoupLabel : Label
    {
        public bool isPartOfCompletedWord = false;

        public WordsoupLabel(string text)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Text = text;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void WordsoupLabel_Click(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;

            EventManager.GetEventManager().ClickedWordsoupLabel(currentLabel.TabIndex, currentLabel.Text, isPartOfCompletedWord);
        }
    }
}
