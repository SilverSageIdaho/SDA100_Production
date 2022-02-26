using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDA100
{
    public partial class Keyboard : Form
    {
        public Keyboard(string currentTxtBox)
        {
            InitializeComponent();
            txt_Test.Text = currentTxtBox;
        }
        
        public string getText()
        {
            return txt_Test.Text;
        }

        private void btn_Test1_Click(object sender, EventArgs e)
        {
            txt_Test.Text += btn_Test1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Test.Text += btn_Test2.Text;
        }

        private void btn_Test3_Click(object sender, EventArgs e)
        {
            txt_Test.Text += btn_Test3.Text;
        }
    }
}
