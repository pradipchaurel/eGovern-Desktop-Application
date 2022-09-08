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
    public partial class passport : Form
    {
        public passport()
        {
            InitializeComponent();
            DisplayPassport();
        }

        int index;
        int Id;


        //SQL connection

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //To display data in datagridview
        private void DisplayPassport()
        {
            con.Open();
            string cmd = "Select * from passport";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        //Clear Function
        private void Clear()
        {
            textBox1.Clear();
            dateTimePicker1.ResetText();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
        }


        //To add data
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please fill all the required filled");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into passport values (@Full_Name,@DOB,@Passport_Office,@Address,@National_ID_No,@Father_Name,@Phone_No,@Gender,@Passport_Type,@Duration)", con);
                    cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Passport_Office", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@National_ID_No", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone_NO", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Passport_Type", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Duration", comboBox4.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your record submited successfully");
                    con.Close();
                    DisplayPassport();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            
        }

        //To go back 
        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu obj = new MainMenu();
            obj.Show();
            this.Hide();
        }

        private void passport_Load(object sender, EventArgs e)
        {

        }

        //For auto fill

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            Id = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
            textBox2.Text = row.Cells[4].Value.ToString();
            textBox3.Text = row.Cells[5].Value.ToString();
            textBox4.Text = row.Cells[6].Value.ToString();
            textBox5.Text = row.Cells[7].Value.ToString();
            comboBox2.Text = row.Cells[8].Value.ToString();
            comboBox3.Text = row.Cells[9].Value.ToString();
            comboBox4.Text = row.Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please select data to update");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update passport set Full_Name=@Full_Name,DOB=@DOB,Passport_Office=@Passport_Office,Address=@Address,National_ID_No=@National_ID_No,Father_Name=@Father_Name,Phone_No=@Phone_No,Gender=@Gender,Passport_Type=@Passport_Type,Duration=@Duration WHERE Id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", this.Id);
                    cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Passport_Office", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@National_ID_No", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone_NO", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Passport_Type", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Duration", comboBox4.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your record updated successfully");
                    con.Close();
                    DisplayPassport();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
            
        }
        //To delete Data
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please select data to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from passport WHERE Id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", this.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data deleted successfully");
                    con.Close();
                    DisplayPassport();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
            
        }
    }
}
