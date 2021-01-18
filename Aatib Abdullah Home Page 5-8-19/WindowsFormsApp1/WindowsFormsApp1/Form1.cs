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
        struct Username
        {



            public string username;

            public int Status;

            string Password;

            string Email;

            string FirstName;

            string LastName;


            public Username(string use, string pass, string em, string first, string last, int stat)
            {

                this.username = use;
                this.Password = pass;
                this.Email = em;
                this.FirstName = first;
                this.LastName = last;
                this.Status = stat;
            }


            bool checkCredentials(string username, string password)
            {

                return true; // temporary value
            }
            void Login(string username, string password, string email, string firstname, string lastname, int status)
            {
                bool Successful_login = checkCredentials(username,password);
                if (Successful_login == true)
                {
                    status = 1;
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
            void LogoutButton(string Username, string Password, string Email, string FirstName, string LastName, int Status)
            {
                //Status = 0; (Logged out)
                //Update Database
                //Clear Local Instance
                //Close.HomeScreenForm()
                //display.LoginScreen();	
            }
           public void UpdateStatus(int newStatus)
            {
                this.Status = newStatus;
            }
            public string get_username()
            {
                return username;
            }
        }







        struct fl
        {
            int f;
            public  Dictionary<List<string>, int> current_convos;
            public Dictionary<string,int> Lobby_relations;
            public List<int> lobbyid;
            public List<string> tempconv;
            public List<string> friends;
           
            
            public void getLobbyIDs(int lr)
            {
                string temp = "";
                int k = 0;
                for (int i = 0; i < Lobby_relations.Count; i++)
                {
                    if (i == 0)
                    {
                        lobbyid.Add(lr);
                    }
                    else
                    {
                        bool hit = false;
                        
                        foreach (KeyValuePair<string, int> nutty in Lobby_relations)
                        {
                            if (nutty.Value == lobbyid[i])
                            {
                                temp = nutty.Key;
                            }
                        }
                        for (int j = 0; j < i; j++)
                        {
 
                            hit = false;
                            if (Lobby_relations.ContainsValue(lobbyid[j]))
                            {
                                
                                hit = true;
                                break;
                            }
                            
                        }
                        if (!hit)
                        {
                           
                            lobbyid[k++] = Lobby_relations[temp];
                        }
                    }

                }

            }
            void getUniqueFriends()
            {

            }

            public int friendamoutn()
            {
                return friends.Capacity;
            }

            

            bool currentsconversation(Dictionary<List<string>, int> currentconvs, List<string> currntconv, List<string> friendsInLobby)
            {
                return false; // temporary value
            }
            void LoadTemConvo(Dictionary<List<String>, int> currentconv, List<string> friendsInLobby)
            {
                


            }
          public void LoadTempConvo(int lobbyID, string text)
            {

                tempconv[lobbyID] = text;

            }
            public void DeleteFriend(string username)
            {
                this.friends.Remove(username);
            }
            public void sendFriend(string nonsense)
            {

            }

        }
        struct blocked
        {
            string nameofuser;
            public List<string> blacklist;
            public void setname(string usings)
            {
                nameofuser = usings;
            }
        }
        struct pending
        {
            string username;
            public List<string> friendrequest;
            public void setname(string uings)
            {
                username = uings;
            }
        }



        public string name;
         Username user;
        fl userfriend;
        blocked block;
        pending pend;
        string conversing;
        public int lobbint;
        public int chatint;
        public Text()
        {
            InitializeComponent();




         
            comboBox3.Text = "Available";
            comboBox3.Items.Add("Available");
            comboBox3.Items.Add("Away");
            comboBox3.Items.Add("Busy");
            comboBox3.Items.Add("Offline");
         
            userfriend = new fl();



            label1.Text = "Chatting with ...";


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

            userfriend.tempconv[lobbint] = richTextBox1.Text;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            /*

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
                            if ()
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
            }*/
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
                user.UpdateStatus(1);
            }
            if (comboBox3.Text == "Away")
            { MessageBox.Show("Your status changed to " + comboBox3.Text);
                user.UpdateStatus(2);
            }
            if (comboBox3.Text == "Busy")
            { MessageBox.Show("Your status changed to " + comboBox3.Text);
                user.UpdateStatus(3);
            }
            if (comboBox3.Text == "Offline")
            { MessageBox.Show("Your status changed to " + comboBox3.Text);
                user.UpdateStatus(4);
            }
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

            foreach(KeyValuePair<List<string>, int> nut in userfriend.current_convos)
            { int i = 0;
                while (i < userfriend.current_convos.Keys.Count())
                {
                    comboBox1.Items.Add(nut.Key[i]);
                    i++;
                }
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
            for (int i = 0; i < block.blacklist.Count; i++)
            {
                comboBox1.Items.Add(block.blacklist[i]);
            }
            comboBox2.Items.Add("unblock");

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            for (int i = 0; i < pend.friendrequest.Count; i++)
            {
                comboBox1.Items.Add(pend.friendrequest[i]);
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
                    if (block.blacklist.Contains(comboBox1.Text))
                    {
                        MessageBox.Show("This user is blocked, unbloc and try again");
                    }
                    else
                    {

                        
                        List<string> people = new List<string>();// string of friends
                        lobbint = userfriend.lobbyid.Capacity;
                        lobbint++;
                        /* if (userfriend.lobbyid.Contains)
                          {
                              MessageBox.Show("Lobby Already Exists\nHere is your Lobby");
                              richTextBox1.Text = userfriend.current_convos[lobbint];
                              List<string> people = userfriend.Lobby_relations[lobbint].Split('.');
                              if (.Contains(user.get_username()))
                              {

                              }
                              else { user.Lobbylist[lobbint].Add(user.get_username()); }
                              conversing = "storedconversation.txt";

                              user.setfile(conversing);
                              File.WriteAllText(user.getfile(), richTextBox1.Text);
                          }
                         //  else
                         //{*/
                        userfriend.lobbyid.Add(lobbint);
                        people.Add(user.get_username());
                        for (int i=0; i < userfriend.friendamoutn(); i++)
                        {
                            if(userfriend.friends[i] == comboBox1.Text)
                            {
                                people.Add(userfriend.friends[i]);
                                userfriend.current_convos.Add(people, lobbint);
                                userfriend.Lobby_relations.Add(comboBox1.Text,lobbint);
                            }
                        }

                        
                

                        label1.Text = "In Lobby with" + comboBox1.Text + "& Others";
                      
                    }


                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox2.Items.Add("Leave Lobby");
                }
                if (comboBox2.Text == "Open Convo")
                {
                
                    if (block.blacklist.Contains(comboBox1.Text))
                    {
                        MessageBox.Show("This user is blocked, unbloc and try again");
                    }
                    else
                    {
                        for(int i = 1; i < (userfriend.tempconv.Capacity+1); i++)
                        {
                            userfriend.tempconv.Remove(userfriend.tempconv[i]);
                        }

                        foreach (KeyValuePair<List<string>, int> conv in userfriend.current_convos)
                        {
                            if (conv.Key.Contains(comboBox1.Text)){
                                if (lobbint == conv.Value)
                                {
                                    lobbint = conv.Value;
                                    conv.Key.Add(user.get_username());
                                }
                            }
                        }

                        richTextBox1.Text = userfriend.tempconv[lobbint];
                        

                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox2.Items.Add("Leave");
                    }
                }
           
                if (comboBox2.Text == "Remove")
                {
                    userfriend.DeleteFriend(comboBox1.Text);
                    comboBox1.Items.Remove(comboBox1.Text);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                if (comboBox2.Text == "Block")
                {
                    if (userfriend.friends.Contains(comboBox1.Text))
                    { userfriend.friends.Remove(comboBox1.Text); }

                    block.blacklist.Add(comboBox1.Text);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                if (comboBox2.Text == "Leave Lobby")
                {

                    //string text = File.ReadAllText(conversing);
                    if (lobbint <= userfriend.tempconv.Capacity)
                    {

                        userfriend.LoadTempConvo(lobbint,richTextBox1.Text);
                    }
                    else
                    {
                        userfriend.tempconv.Add(richTextBox1.Text);
                    }
                    foreach (KeyValuePair<List<String>, int> nut in userfriend.current_convos)
                    {
                        if (lobbint == nut.Value)
                        {
                            if (nut.Key.Contains(user.get_username()))
                            {
                                nut.Key.Remove(user.get_username());

                            }
                        }
                    }

                   
                    richTextBox1.Text = "";
                    label1.Text = "Lobby Ended";
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    comboBox2.Items.Remove("Leave");
                }

                if (comboBox2.Text == "Add Friend")
                { 
                            if (userfriend.friends.Contains(comboBox1.Text))
                            {
                        MessageBox.Show(comboBox1.Text + " are already you friend");
                            }

                    userfriend.sendFriend(comboBox1.Text);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }

            if (radioButton2.Checked)
            {


                if (comboBox2.Text == "unblock")
                {

                    block.blacklist.Remove(comboBox1.Text);
                    comboBox1.Items.Remove(comboBox1.Text);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }
            if (radioButton3.Checked)
            {
                if (comboBox2.Text == "accept as friend")
                {

                    userfriend.sendFriend(comboBox1.Text);
                  
                    comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                }
                if (comboBox2.Text == "Reject")
                {

                    pend.friendrequest.Remove(comboBox1.Text);
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