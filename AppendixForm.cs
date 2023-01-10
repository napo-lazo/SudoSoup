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
    public partial class AppendixForm : Form
    {
        public AppendixForm()
        {
            InitializeComponent();
        }

        private void AppendixForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventManager.GetEventManager().AppendixFormClosed();
        }
    }
}
