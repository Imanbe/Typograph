using System;
using System.Windows.Forms;

namespace Typograph
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            string str = textBox_Input.Text;
            Parser.Pasring(ref str);
            textBox_Input.Text = str;
        }

        private void textBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Convert_Click(sender, e);
            }
        }
    }
}
