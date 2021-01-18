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



        struct User
        {


            private string username;
            private string password;
            private string email;
            private string firstname;
            private string lastname;
            public string filename;

            public Dictionary<string, int> friendlist;
            public Dictionary<int, List<string>> Lobbylist;
            public Dictionary<string, int> blocked;
            public Dictionary<string, int> pending;
            public Dictionary<int, string> tempconvo;

            public User(string use, string pass, string em, string first, string last,
                Dictionary<string, int> friend, Dictionary<int, List<string>> Lobby,
                Dictionary<string, int> bloc, Dictionary<string, int> pend, Dictionary<int, string> toto, string file)
            {

                this.username = use;
                this.password = pass;
                this.email = em;
                this.firstname = first;
                this.lastname = last;
                this.friendlist = friend;
                this.Lobbylist = Lobby;
                this.blocked = bloc;
                this.pending = pend;
                this.tempconvo = toto;
                this.filename = file;
            }

            public string get_username()
            {
                return username;
            }
            /* public string getfriends(int i)
             {

             }
*/
            public void setfile(string text)
            {
                filename = text;

            }
            public string getfile()
            {
                return filename;
            }

        }

        public string name;

        User user;
        string conversing;
        public int lobbint;
        public int chatint;
        public Text()
        {
            InitializeComponent();



            StreamReader newusers = new StreamReader("users.txt");
            comboBox3.Text = "Available";
            comboBox3.Items.Add("Available");
            comboBox3.Items.Add("Away");
            comboBox3.Items.Add("Busy");
            comboBox3.Items.Add("Offline");
            string[] userlists = (newusers.ReadLine()).Split(',');
            while (userlists[0] != null)
            {
                if (userlists[0] == "Jack")
                {
                    break;
                }

                userlists = (newusers.ReadLine()).Split(',');
            }
            Dictionary<string, int> Junka = new Dictionary<string, int>();
            Dictionary<string, int> Junkc = new Dictionary<string, int>();
            Dictionary<string, int> Junkd = new Dictionary<string, int>();
            Dictionary<int, string> Junke = new Dictionary<int, string>();
            Junka.Add("", 0);
            Junkc.Add("", 0);
            Junkd.Add("", 0);
            Junke.Add(0, "");
            Dictionary<int, List<string>> Junkb = new Dictionary<int, List<string>>();
            List<string> adding = new List<string>(new string[] { "" });
            Junkb.Add(0, adding);
            user = new User(userlists[0], userlists[1], userlists[2], userlists[3], userlists[4], Junka, Junkb, Junkc, Junkd, Junke, ""); // global declaration

            user.friendlist.Clear();
            user.Lobbylist.Clear();
            user.pending.Clear();
            user.blocked.Clear();
            user.tempconvo.Clear();
            user.friendlist.Add("HarryJarry", 5);

            user.pending.Add("foxyloxy", 4);

            user.blocked.Add("Squidward", 5);

            label1.Text = "Chatting with ...";

            name = userlists[0];


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


            string timestamp = DateTime.Now.ToString("MM dd yyyy H:mm:ss tt");
            string usa = "[" + name + "]";
            string line = usa + " " + timestamp;
            string input = textBox1.Text;


            // Here is the Test Case for 



            textBox1.Text = "";
            string theline = "\n" + line + "\n" + input + "\n";
            // string filetext = File.ReadAllText("Converse.txt"); // this refreashes from the start of the text file
            // string filetext = File.R
            string texty = theline;
            richTextBox1.Text = richTextBox1.Text + texty;
            File.AppendAllText(user.getfile(), Text);



            //}

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // its feild wll be populated by function button2_Click(object sender , EventArgs e)
            String s = String.Empty;
            foreach (string str in richTextBox1.Lines)
            {
                s = str;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '[')
                    {
                        for (int y = i; y < s.Length; y++)
                        {
                            if (user.blocked.ContainsKey(s.Substring(i, y)))
                            {
                                MessageBox.Show("You are Blocked");
                                /// This wil be the sent to the user that is blocked
                                s = "";
                                break;
                            }
                            if (s[i] == ']')
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Available")
            {
                MessageBox.Show("Your status changed to " + comboBox3.Text);
            }
            if (comboBox3.Text == "Away")
            { MessageBox.Show("Your status changed to " + comboBox3.Text); }
            if (comboBox3.Text == "Busy")
            { MessageBox.Show("Your status changed to " + comboBox3.Text); }
            if (comboBox3.Text == "Offline")
            { MessageBox.Show("Your status changed to " + comboBox3.Text); }
        } /// This part is to be sent to all friends

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            foreach (KeyValuePair<string, int> friend in user.friendlist)
            {
                comboBox1.Items.Add(friend.Key);
            }


            comboBox2.Items.Add("Start Conversation");
            comboBox2.Items.Add("Open Convo");
            comboBox2.Items.Add("Remove");
            comboBox2.Items.Add("Add Friend");
            comboBox2.Items.Add("Block");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (KeyValuePair<string, int> bloc in user.blocked)
            {
                comboBox1.Items.Add(bloc.Key);
            }
            comboBox2.Items.Add("unblock");

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (KeyValuePair<string, int> known in user.pending)
            {
                comboBox1.Items.Add(known.Key);
            }
            comboBox2.Items.Add("accept as friend");
            comboBox2.Items.Add("Reject");
            comboBox2.Items.Add("Ignore");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {


                if (comboBox2.Text == "Start Conversation")
                {
                    if (user.blocked.ContainsKey(comboBox1.Text))
                    {
                        MessageBox.Show("This user is blocked, unbloc and try again");
                    }
                    else
                    {
                        Random random = new Random();

                        List<string> exitsing = new List<string>();
                        lobbint = random.Next(0, 1000);
                        if (user.Lobbylist.ContainsKey(lobbint))
                        {
                            MessageBox.Show("Lobby Already Exists\nHere is your Lobby");
                            richTextBox1.Text = user.tempconvo[lobbint];
                            if (user.Lobbylist[lobbint].Contains(user.get_username()))
                            {

                            }
                            else { user.Lobbylist[lobbint].Add(user.get_username()); }
                            conversing = "storedconversation.txt";

                            user.setfile(conversing);
                            File.WriteAllText(user.getfile(), richTextBox1.Text);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> friendly in user.friendlist)
                            {
                                if (friendly.Key == comboBox1.Text)
                                {
                                    exitsing.Add(friendly.Key);
                                }
                            }
                            exitsing.Add(user.get_username());

                            user.Lobbylist.Add(lobbint, exitsing);
                        }

                        label1.Text = "In Lobby with " + exitsing[0];
                        conversing = "storedconversation.txt";

                        user.setfile(conversing);
                        File.AppendAllText(user.getfile(), "");
                    }


                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Leave Lobby");
                }
                if (comboBox2.Text == "Open Convo")
                {
                    string converstext = "";
                    if (user.blocked.ContainsKey(comboBox1.Text))
                    {
                        MessageBox.Show("This user is blocked, unbloc and try again");
                    }
                    else
                    {
                        foreach (KeyValuePair<int, List<string>> jabbie in user.Lobbylist)
                        {
                            for (int i = 0; i < jabbie.Value.Count; i++)
                            {
                                if (comboBox1.Text == jabbie.Value[i])
                                {
                                    lobbint = jabbie.Key;
                                }
                            }
                        }


                        foreach (KeyValuePair<int, List<string>> lobbies in user.Lobbylist)
                        {
                            if (lobbint == lobbies.Key)
                            {
                                if (lobbies.Value.Contains(user.get_username()))
                                { }
                                else
                                {
                                    lobbies.Value.Add(user.get_username());
                                }
                                break;
                            }
                        }


                        foreach (KeyValuePair<int, string> talk in user.tempconvo)
                        {
                            if (lobbint == talk.Key)
                            {
                                converstext = talk.Value;
                                break;
                            }
                        }
                        conversing = "storedconversation.txt";

                        user.setfile(conversing);
                        richTextBox1.Text = converstext;


                        File.WriteAllText(user.getfile(), converstext);

                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("Leave Lobby");
                    }
                }
                if (comboBox2.Text == "Remove")
                {
                    user.friendlist.Remove(comboBox1.Text);
                    comboBox1.Items.Remove(comboBox1.Text);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                if (comboBox2.Text == "Block")
                {
                    int mess = 0;
                    foreach (KeyValuePair<string, int> buddy in user.friendlist)
                    {
                        if (comboBox1.Text == buddy.Key)
                        {
                            mess = buddy.Value;
                            break;
                        }
                    }

                    StreamReader newfile = new StreamReader("users.txt");

                    string[] readables = (newfile.ReadLine()).Split(',');



                    while (readables[0] != null)
                    {
                        if (readables[0] == comboBox1.Text)
                        {
                            user.blocked.Add(readables[0], mess);
                            break;
                        }

                        readables = (newfile.ReadLine()).Split(',');
                    }


                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                if (comboBox2.Text == "Leave Lobby")
                {

                    //string text = File.ReadAllText(conversing);
                    if (user.tempconvo.ContainsKey(lobbint))
                    {
                        user.tempconvo[lobbint] = richTextBox1.Text;
                    }
                    else { user.tempconvo.Add(lobbint, richTextBox1.Text); }

                    File.Delete(user.getfile());


                    richTextBox1.Text = "";
                    label1.Text = "Lobby Ended";
                    comboBox2.Items.Add("Start Conversation");
                    comboBox2.Items.Add("Open Convo");
                    comboBox2.Items.Add("Remove");
                    comboBox2.Items.Add("Add Friend");
                    comboBox2.Items.Add("Block");
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    comboBox2.Items.Remove("Leave Lobby");
                }
                if (comboBox2.Text == "Exit Chat")
                {
                    if (user.tempconvo.ContainsKey(user.friendlist[comboBox1.Text]))
                    {
                        user.tempconvo[user.friendlist[comboBox1.Text]] = richTextBox1.Text;
                    }
                    else
                    {
                        user.tempconvo.Add(chatint, richTextBox1.Text);
                    }

                    File.Delete(user.getfile());


                    richTextBox1.Text = "";
                    label1.Text = "Chat Over";
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    comboBox2.Items.Remove("Exit Chat");
                }
                if (comboBox2.Text == "Add Friend")
                {
                    StreamReader newfile = new StreamReader("users.txt");
                    string read = newfile.ReadLine();
                    string[] readables = read.Split(',');

                    while (read != null)
                    {

                        if (readables[0] == comboBox1.Text)
                        {
                            if (user.friendlist.ContainsKey(readables[0]))
                            {
                                MessageBox.Show(readables[0] + " are already you friend");
                                break;
                            }
                            user.friendlist.Add(readables[0], 0);
                            comboBox1.Items.Add(readables[0]);
                            break;
                        }
                        read = newfile.ReadLine();
                        readables = read.Split(',');
                    }
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }

            if (radioButton2.Checked)
            {


                if (comboBox2.Text == "unblock")
                {

                    user.blocked.Remove(comboBox1.Text);
                    comboBox1.Items.Remove(comboBox1.Text);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }
            if (radioButton3.Checked)
            {
                if (comboBox2.Text == "accept as friend")
                {

                    user.pending.Remove(comboBox1.Text);
                    user.friendlist.Add(comboBox1.Text, 1);
                    comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                }
                if (comboBox2.Text == "Reject")
                {

                    user.pending.Remove(comboBox1.Text);
                    comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                }
                if (comboBox2.Text == "Ignore")
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            comboBox3.Text = "Offline";
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

    }
}

