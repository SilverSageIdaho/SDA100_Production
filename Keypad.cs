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
    public partial class Keypad : Form
    {
        public Keypad(string currentTxtBoxText)
        {
            InitializeComponent();
            txt_keypad_inputbox.Text = currentTxtBoxText;
            
        }

        public string getText()
        {
            return txt_keypad_inputbox.Text;
        }

        private void btn_keypad_number_Click(object sender, EventArgs e)
        {
            txt_keypad_inputbox.Text += (sender as Button).Text;
        }

        private void btn_keypad_backspace_Click(object sender, EventArgs e)
        {
            txt_keypad_inputbox.Text = txt_keypad_inputbox.Text.Substring(0, txt_keypad_inputbox.Text.Length - 1);
        }
    }
}
