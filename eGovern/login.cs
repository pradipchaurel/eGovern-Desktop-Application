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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM user_registration WHERE Email = '"+textBox1.Text+"' and Password ='"+textBox2.Text+"' ";
            SqlCommand cmd = new SqlCommand(login,con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                MainMenu obj = new MainMenu();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            registration obj = new registration();
            obj.Show();
            this.Hide();
        }




        //
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
