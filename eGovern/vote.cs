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
    public partial class vote : Form
    {
        public vote()
        {
            InitializeComponent();
            DisplayDetail();
        }

        int Id;
        int index;

        //SQL connection

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //To delete

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please select data to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from vote WHERE Id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", this.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data deleted successfully");
                    con.Close();
                    DisplayDetail();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //To display
        private void DisplayDetail()
        {
            con.Open();
            string cmd = "Select * from vote";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }


        //clear function
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
            comboBox1.ResetText();
            comboBox1.ResetText();
        }

        //Add data
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all the required filled");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into vote values (@Date,@State,@District,@City_Village,@Ward_No,@Party,@Vote_For,@Voter_Card_No)", con);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@State", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@District", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@City_Village", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Ward_No", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Party", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Vote_For", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Voter_Card_No", textBox5.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Vote Submitted successfully");
                    con.Close();
                    DisplayDetail();
                    Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        //For Auto fill
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            Id = Convert.ToInt32(row.Cells[0].Value);
            dateTimePicker1.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox1.Text = row.Cells[4].Value.ToString();
            textBox2.Text = row.Cells[5].Value.ToString();
            textBox3.Text = row.Cells[6].Value.ToString();
            textBox4.Text = row.Cells[7].Value.ToString();
            textBox5.Text = row.Cells[8].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu obj = new MainMenu();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
