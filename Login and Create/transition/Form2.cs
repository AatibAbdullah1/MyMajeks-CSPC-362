using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transition
{
    public partial class Form2 : Form
    {

    public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 15;
            textBox1.MaxLength = 15;

      
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please enter Username & password");

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Username");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Username");
            }
            else
            {
                MessageBox.Show("You have successfully Entered a Username and Password");
            }
        }
        
    }
}
