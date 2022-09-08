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
    public partial class death_certificate : Form
    {
        public death_certificate()
        {
            InitializeComponent();
            DisplayDetail();
        }

        int Id;
        int index;

        //SQL connection

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }


        //To display
        private void DisplayDetail()
        {
            con.Open();
            string cmd = "Select * from death_certificate";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        //clear
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
        }


        //To add data
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
                    SqlCommand cmd = new SqlCommand("Insert into death_certificate values (@Full_Name,@DOB,@Mother_Name,@Gender,@Father_Name,@Birth_Address,@Death_Address,@Death_Date,@Nationality)", con);
                    cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Mother_Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Birth_Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Death_Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Death_Date", dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox3.SelectedItem.ToString());
                    


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your record submited successfully");
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

        //Auto fill
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            Id = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[3].Value.ToString();
            comboBox2.Text = row.Cells[4].Value.ToString();
            textBox3.Text = row.Cells[5].Value.ToString();
            textBox4.Text = row.Cells[6].Value.ToString();
            textBox5.Text = row.Cells[7].Value.ToString();
            dateTimePicker2.Text = row.Cells[8].Value.ToString();
            comboBox3.Text = row.Cells[9].Value.ToString();
        }

        //update
        private void button2_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Update death_certificate set Full_Name=@Full_Name,DOB=@DOB,Mother_Name=@Mother_Name,Gender=@Gender,Father_Name=@Father_Name,Birth_Address=@Birth_Address,Death_Address=@Death_Address,Death_Date=@Death_Date,Nationality=@Nationality WHERE Id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Mother_Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Birth_Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Death_Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Death_Date", dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@Nationality", comboBox3.SelectedItem.ToString());



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your record updated successfully");
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

        //to delete
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
                    SqlCommand cmd = new SqlCommand("Delete from death_certificate WHERE Id=@ID", con);
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
