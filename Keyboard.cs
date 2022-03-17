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
            txt_key_inputbox.Text = currentTxtBox;
        }
        
        public string getText()
        {
            return txt_key_inputbox.Text;
        }

       

        private void btn_key_letter_number_Click(object sender, EventArgs e)
        {
            txt_key_inputbox.Text += (sender as Button).Text;
        }
               
        private void btn_key_space_Click(object sender, EventArgs e)
        {
            txt_key_inputbox.Text += ' ';
        }

        private void btn_key_leftarrow_Click(object sender, EventArgs e)
        {
            txt_key_inputbox.SelectionStart = txt_key_inputbox.SelectionStart - 1;
        }

        private void btn_key_rightarrow_Click(object sender, EventArgs e)
        {
            txt_key_inputbox.SelectionStart = txt_key_inputbox.SelectionStart + 1;
        }

        private void btn_key_backspace_Click(object sender, EventArgs e)
        {
            txt_key_inputbox.Text = txt_key_inputbox.Text.Substring(0, txt_key_inputbox.Text.Length - 1);
        }

        private void btn_key_shift_Click(object sender, EventArgs e)
        {

            List<Button> buttonlist = new List<Button>()
            {
                btn_key_a, btn_key_b, btn_key_c, btn_key_d,
                btn_key_e, btn_key_f, btn_key_g, btn_key_h, btn_key_i,
                btn_key_j, btn_key_k, btn_key_l, btn_key_m, btn_key_n,
                btn_key_o, btn_key_p, btn_key_q, btn_key_r, btn_key_s,
                btn_key_t, btn_key_u, btn_key_v, btn_key_w, btn_key_x,
                btn_key_y, btn_key_z
            };
            if (btn_key_a.Text == "a")
            {
                foreach (Button btn in buttonlist)
                {
                    btn.Text = btn.Text.ToUpper();
                }
            }
            else
            {
                foreach (Button btn in buttonlist)
                {
                    btn.Text = btn.Text.ToLower();
                }
            }
        }
    }
}
