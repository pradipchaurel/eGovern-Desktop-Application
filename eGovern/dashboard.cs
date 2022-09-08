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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        //SQL connection

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");


        private void CountPassport()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from passport",con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_passport.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountCitizenship()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from citizenship", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_citizenship.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountBirth()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from birth_certificate", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_birth.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountDeath()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from death_certificate", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_death.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountVote()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from vote", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_vote.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountPan()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from pan", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label_pan.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountNationalID()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from national_id_card", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            labe_nationalId.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            CountPassport();
            CountCitizenship();
            CountBirth();
            CountDeath();
            CountVote();
            CountPan();
            CountNationalID();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu obj = new MainMenu();
            obj.Show();
            this.Hide();
        }
    }
}
