using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public void RefreshContacts()
        {
            try
            {
                listBox3.Items.Clear();
                string listContact;
                StreamReader inputFile;

                inputFile = File.OpenText("contacts.txt");

                while (!inputFile.EndOfStream)
                {
                    listContact = inputFile.ReadLine();
                    listBox3.Items.Add(listContact);

                }
                inputFile.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.BackColor = Color.Yellow;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.BackColor = Color.Red;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.BackColor = Color.White;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.BackColor = SystemColors.Control;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city;
            if (comboBox1.SelectedIndex != -1)
            {
                city = comboBox1.SelectedItem.ToString();
                
                switch (city)
                {
                    case "Honolulu":
                        label2.Text = "Hawaii-Aleutian";
                        break;
                    case "San Francisco":
                        label2.Text = "Pacific";
                        break;
                    case "Denver":
                        label2.Text = "Mountain";
                        break;
                    case "Minneapolis":
                        label2.Text = "Central";
                        break;
                    case "New York":
                        label2.Text = "Eastern";
                        break;
                }
            }
            else
            {
                MessageBox.Show("Select a City");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string countryName;
                StreamReader inputFile;

                inputFile = File.OpenText("countries.txt");

                while (!inputFile.EndOfStream)
                {
                    countryName = inputFile.ReadLine();
                    listBox1.Items.Add(countryName);

                }
                inputFile.Close();
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        try
            {
                StreamWriter outputFile;

                outputFile = File.AppendText("friends.txt");

                outputFile.WriteLine(textBox1.Text);

                outputFile.Close();

                MessageBox.Show("The name was written to the file");

                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sideUp;

            Random rand = new Random();
            sideUp = rand.Next(2);

            if (sideUp == 0)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                label5.Text = "The coin landed on Heads";
            } else
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                label5.Text = "The coin landed on Tails";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int speed;
            decimal hoursTravelled;
            decimal miles;
            int partMiles;

            try
            {
                speed = int.Parse(textBox2.Text);
                hoursTravelled = decimal.Parse(textBox3.Text);

                miles = speed * hoursTravelled;

                int count = 1;
                while (count < hoursTravelled)
                {
                    partMiles = count * speed;
                    listBox2.Items.Add("After " + count + " hours, the distance travelled was " + partMiles + " miles");
                    count++;
                }
                listBox2.Items.Add("After " + hoursTravelled + " hours, the distance travelled was " + miles + " miles");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string contactName;
            string contactNumber;
            string contactInfo;

            

            try
            {
                StreamWriter outputFile;

                outputFile = File.AppendText("contacts.txt");
                contactName = textBox4.Text;
                contactNumber = textBox5.Text;

                contactInfo = "Name: " + contactName + " - Number: " + contactNumber;

                outputFile.WriteLine(contactInfo);

                outputFile.Close();

                //MessageBox.Show("Contact Added.");

                textBox4.Text = "";
                textBox5.Text = "";
                textBox4.Focus();
                RefreshContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        private void button7_Click(object sender, EventArgs e)
        {
            File.Create("contacts.txt").Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshContacts();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
 

