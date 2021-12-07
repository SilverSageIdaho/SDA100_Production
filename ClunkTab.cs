using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDA100
{
    public partial class mainForm : Form
    {
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "100";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "500";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1000";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            serialPort1.Write("H"); // Home XY Stage
        }

        private void button14_Click(object sender, EventArgs e)
        {
            serialPort1.Write("h"); // Home Z Stage
        }

        private void button15_Click(object sender, EventArgs e)
        {
            serialPort1.Write("P"); // Park XY Stage at Load Port position
        }

        private void button16_Click(object sender, EventArgs e)
        {
            serialPort1.Write("p"); // Park Z Stage at preFocus position
        }



        private void button18_Click(object sender, EventArgs e)
        {
            serialPort1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "B"); // X Stage BACK
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "L"); // Y Stage LEFT
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "R"); // Y Stage RIGHT
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "F"); // X Stage FRONT
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "U"); // Z Stage UP
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "D"); // Z Stage DOWN
        }

        private void button20_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "i"); // copy PreFocus preset values from UVW to XYZ
        }

        private void button19_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "I"); // Move XYZ Stages to PreFocus
        }

        private void button22_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "G"); // START SCAN
        }

        private void button21_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "e"); // STOP SCAN
        }

        private void button23_Click(object sender, EventArgs e)
        {
            serialPort1.Write(textBox3.Text);
            textBox3.Text = "";
        }
        private void button25_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "L"); // Y Stage LEFT
        }
        private void button24_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + textBox1.Text + "f"); // Focus Optics
        }
    }
}



