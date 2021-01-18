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

namespace WindowsFormsApp1
{
    //public class FileMissing : Exception
    //{
    //    public FileMissing(string message) : base("File is missing Converse.txt")//base(message)
    //    {
    //    }
    //}

    public partial class Text : Form
    {
        string namelin = "Jack";
        int lobby_num = 0;
        public Text()
        {
            InitializeComponent();

            /*
            int users = 4;
            int usernum = 0;


            string Users = "";
            for (int a = 0; a < users - 1; a++)
            {
                usernum++;
                string j = usernum.ToString();
                Users = Users + "user" + j + ",";

            }
            usernum++;
            string s = usernum.ToString();
            Users = Users + "user" + s + "!";
            lobby_num++;
            string lobbyid = lobby_num.ToString();

            String Users_lobby = "\nLobby" + lobbyid + ": " + Users + "\n";


            File.AppendAllText("Converse.txt", Users_lobby);

            StreamReader file = new StreamReader("Converse.txt");

            string line = file.ReadLine();
            while (line != null)
            {
                if (line != "Lobby" + lobbyid + ": " + Users)
                {
                    richTextBox1.AppendText(line + "\n");

                }
                line = file.ReadLine();
            }
            file.Close();
            */


            // string filetext = File.R
            //richTextBox1.Text = filetext;
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }

        private void Text_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            string looker = textBox1.Text;
            int i;
            int count = 0;
            int position = 0;
            string comm;
            for (i = 0; i < looker.Length; i++)
            {
                comm = looker.Substring(0, i);

                if (comm == "add ")
                {
                    break;
                }
                if (comm == "del ")
                {

                    break;
                }
                if (comm == "block ")
                {

                    break;
                }
                if (comm == "unblock ")
                {

                    break;
                }
                count++;
            }
            string finder;
            comm = looker.Substring(0, count);

            if (comm == "add ")
            {

                finder = looker.Substring(count);
                StreamReader file = new StreamReader("Users.txt");
                string friendly = file.ReadLine();
                while (friendly != null)
                {
                    if (finder == friendly)
                    {
                        File.AppendAllText("MyFriends.txt", finder + "\n");
                    }
                    friendly = file.ReadLine();
                }
                file.Close();
                textBox1.Text = "";
            }
            else if (comm == "del ")
            {

                finder = looker.Substring(count);
                StreamReader file = new StreamReader("MyFriends.txt");
                string deleter = file.ReadLine();
                while (deleter != null)
                {
                    if (deleter != finder)
                    {
                        File.AppendAllText("deletefriend.txt", deleter);
                    }
                    deleter = file.ReadLine();
                }
                file.Close();

                FileStream fileStream = File.Open("MyFriends.txt", FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

                StreamReader newfile = new StreamReader("deletefriend.txt");
                string restore = newfile.ReadLine();
                while (restore != null)
                {

                    File.AppendAllText("MyFriends.txt", restore);
                    restore = newfile.ReadLine();
                }
                newfile.Close();
                textBox1.Text = "";
                FileStream jacob = File.Open("deletefriend.txt", FileMode.Open);
                jacob.SetLength(0);
                jacob.Close();
            }
            else if (comm == "block ")
            {
                finder = looker.Substring(count);
                StreamReader blocker = new StreamReader("Users.txt");
                string troll = blocker.ReadLine();
                while (troll != null)
                {
                    if (troll == finder)
                    {
                        File.AppendAllText("block.txt", troll);
                    }
                    troll = blocker.ReadLine();
                }
                blocker.Close();
                textBox1.Text = "";
            }
            else if (comm == "unblock ")
            {
                finder = looker.Substring(count);
                StreamReader file = new StreamReader("block.txt");
                string undo = file.ReadLine();
                while (undo != null)
                {
                    if (undo != finder)
                    {
                        File.AppendAllText("unblock.txt", undo);
                    }
                    undo = file.ReadLine();
                }
                file.Close();

                FileStream fileStream = File.Open("block.txt", FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

                StreamReader newfile = new StreamReader("unblock.txt");
                string restore = newfile.ReadLine();
                while (restore != null)
                {

                    File.AppendAllText("MyFriends.txt", restore);
                    restore = newfile.ReadLine();
                }
                newfile.Close();
                textBox1.Text = "";

                FileStream spinny = File.Open("unblock.txt", FileMode.Open);
                spinny.SetLength(0);
                spinny.Close();
            }
            */
            // else
            // {

            string timestamp = DateTime.Now.ToString("MM dd yyyy H:mm:ss tt");

            string user = "[" + namelin + "]";
            string line = user + " " + timestamp;
            string input = textBox1.Text;
            bool ifblocked = false;

            // Here is the Test Case for 

            StreamReader nwfile = new StreamReader("block.txt");
            string see = nwfile.ReadLine();
            while (see != null)
            {
                if (namelin == see)
                {
                    ifblocked = true;
                }
                see = nwfile.ReadLine();
            }
            nwfile.Close();
            if (ifblocked)
            {
                MessageBox.Show("You have been Blocked");
            }
            else
            {

                File.AppendAllText("Converse.txt", line);
                File.AppendAllText("Converse.txt", "\n" + input + "\n\n");
                textBox1.Text = "";
                string theline = "\n" + line + "\n" + input + "\n";
                // string filetext = File.ReadAllText("Converse.txt"); // this refreashes from the start of the text file
                // string filetext = File.R
                string texty = theline;
                richTextBox1.Text = richTextBox1.Text + theline;
            }
            //}
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // its feild wll be populated by function button2_Click(object sender , EventArgs e)
        }
        /*
        private void button1_Click(object sender, EventArgs e)      // this is refreash
        {
            //string filetext = File.ReadAllText("Converse.txt");
            //richTextBox1.Text = filetext;

        }
        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = File.ReadAllText("MyFriends.txt");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string finder = textBox3.Text;
            StreamReader blocker = new StreamReader("Users.txt");
            string troll = blocker.ReadLine();
            while (troll != null)
            {
                if (troll == finder)
                {
                    File.AppendAllText("block.txt", troll);
                    File.AppendAllText("block.txt", "\n");
                }
                troll = blocker.ReadLine();
            }
            blocker.Close();
            textBox3.Text = "";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string looker = textBox2.Text;
            StreamReader file = new StreamReader("Users.txt");
            string friendly = file.ReadLine();
            while (friendly != null)
            {
                if (looker == friendly)
                {
                    File.AppendAllText("MyFriends.txt", looker);
                    File.AppendAllText("MyFriends.txt", "\n");
                }
                friendly = file.ReadLine();
            }
            file.Close();
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream jacob = File.Open("deletefriend.txt", FileMode.Open);
            jacob.SetLength(0);
            jacob.Close();
            string finder = textBox2.Text;
            StreamReader file = new StreamReader("MyFriends.txt");
            string deleter = file.ReadLine();
            while (deleter != null)
            {
                if (deleter != finder)
                {
                    File.AppendAllText("deletefriend.txt", deleter);
                    File.AppendAllText("deletefriend.txt", "\n");

                }
                deleter = file.ReadLine();
            }
            file.Close();

            FileStream fileStream = File.Open("MyFriends.txt", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();

            StreamReader newfile = new StreamReader("deletefriend.txt");
            string restore = newfile.ReadLine();
            while (restore != null)
            {

                File.AppendAllText("MyFriends.txt", restore);
                File.AppendAllText("MyFriends.txt", "\n");
                restore = newfile.ReadLine();
            }
            newfile.Close();
            textBox2.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {

            FileStream spinny = File.Open("unblock.txt", FileMode.Open);
            spinny.SetLength(0);
            spinny.Close();

            string finder = textBox3.Text;
            StreamReader file = new StreamReader("block.txt");
            string undo = file.ReadLine();
            while (undo != null)
            {
                if (undo != finder)
                {
                    File.AppendAllText("unblock.txt", undo);
                    File.AppendAllText("unblock.txt", "\n");
                }
                undo = file.ReadLine();
            }
            file.Close();

            FileStream fileStream = File.Open("block.txt", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();

            StreamReader newfile = new StreamReader("unblock.txt");
            string restore = newfile.ReadLine();
            while (restore != null)
            {

                File.AppendAllText("block.txt", restore);
                File.AppendAllText("block.txt", "\n");
                restore = newfile.ReadLine();
            }
            newfile.Close();
            textBox3.Text = "";


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("lobbies.txt");
            textBox1.Text = "Write LobbyID here, then press create to make a lobby or Join to join lobby";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string finder = textBox1.Text;

            StreamReader newfile = new StreamReader("lobbies.txt");
            string restore = newfile.ReadLine();
            string com;
            int count = 0;
            string lobb;
            while (restore != null)
            {
                
                for (int i = 0; i < restore.Length; i++)
                {
                    com = restore.Substring(0, i);
                    if (finder == com)
                    {
                       
                        break;
                    }
                    count++;
                }
                lobb = restore.Substring(0, count);
                if (finder == lobb)
                { 
                    break;
                }
                restore = newfile.ReadLine();
            }
          

            File.AppendAllText("Converse.txt",restore);
            File.AppendAllText("Converse.txt", "\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string finder = textBox1.Text;
           


            File.AppendAllText("lobbies.txt", finder + ": " + namelin + ", " + DateTime.Now.ToString("MM dd yyyy HH:mm:ss tt"));
            File.AppendAllText("lobbies.txt", "\n");
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            FileStream fileStream = File.Open("Converse.txt", FileMode.Open);

            fileStream.SetLength(0);
            fileStream.Close();


        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
