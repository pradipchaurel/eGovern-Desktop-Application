using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eGovern
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        //Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");

        //clear function to clear data from form after register
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the required data");
            }

            else if (textBox4.Text==textBox5.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into user_registration values (@First_Name,@Last_Name,@Email,@Password,@Confirm_Password,@Citizenship_Number,@Gender)", con);
                cmd.Parameters.AddWithValue("@First_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Last_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Password", textBox4.Text);
                cmd.Parameters.AddWithValue("@Confirm_Password", textBox5.Text);
                cmd.Parameters.AddWithValue("@Citizenship_Number", textBox6.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Register Successfully");
                con.Close();
                Clear();
            }
            else
            {
                MessageBox.Show("Password doesn't match");
                textBox5.Text = "";
                textBox6.Text = "";
                textBox5.Focus();
            }


            
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
