using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace transition
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            string filetext = File.ReadAllText("Converse.txt"); // this refreashes from the start of the text file
            // string filetext = File.R
            richTextBox1.Text = filetext;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            File.AppendAllText("Converse.txt", input + "\n\n");
            textBox1.Text = "";

            string filetext = File.ReadAllText("Converse.txt"); // this refreashes from the start of the text file
            // string filetext = File.R
            richTextBox1.Text = filetext;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
