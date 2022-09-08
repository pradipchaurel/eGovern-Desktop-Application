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
//using System.IO;

namespace eGovern
{
    public partial class citizenship : Form
    {
        public citizenship()
        {
            InitializeComponent();
            Display();
        }

       // string imgLocation = "";
        int Id;
        int index;

        //SQL connection

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5th Semester\Dot_Net\PROJECT\eGovern\eGovern\eGovern_database.mdf';Integrated Security=True");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //to display data
        private void Display()
        {
            con.Open();
            string cmd = "Select * from citizenship";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
            con.Close();
        }

        //Clear function
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();

        }

        //TO browse image from computer
        private void browseButton_Click(object sender, EventArgs e)
        {
           /* OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox3.ImageLocation = imgLocation;
            }*/
        }

        //To insert data
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text=="")
            {
                MessageBox.Show("Please fill the form");
            }

            else
            {
                try
                {
                    //to convert image into binary form
                    /*byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);
                    images = reader.ReadBytes((int)stream.Length);*/


                    con.Open();
                    SqlCommand cmd = new SqlCommand("INsert into citizenship values (@Full_Name,@DOB,@Father_Citizenship_No,@National_ID_No,@Father_Name,@Phone_No,@Gender,@Nationality,@District)", con);
                    cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Father_Citizenship_No", textBox2.Text);
                    cmd.Parameters.AddWithValue("@National_ID_No", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone_No", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Nationality", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@District", comboBox4.SelectedItem.ToString());
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data submitted successfully");
                    con.Close();
                    Display();
                    Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        //for auto fill
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            Id = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
            comboBox2.Text = row.Cells[7].Value.ToString();
            comboBox3.Text = row.Cells[8].Value.ToString();
            comboBox4.Text = row.Cells[9].Value.ToString();
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To update



                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Please Select data to update");
                }

                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update citizenship set Full_Name=@Full_Name,DOB=@DOB,Father_Citizenship_No=@Father_Citizenship_No,National_ID_No=@National_ID_No,Father_Name=@Father_Name,Phone_No=@Phone_No,Gender=@Gender,Nationality=@Nationality,District=@District Where Id=@ID", con);
                        cmd.Parameters.AddWithValue("@ID", this.Id);
                        cmd.Parameters.AddWithValue("@Full_Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Father_Citizenship_No", textBox2.Text);
                        cmd.Parameters.AddWithValue("@National_ID_No", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Father_Name", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Phone_No", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Nationality", comboBox3.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@District", comboBox4.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully");
                        con.Close();

                        Display();
                        Clear();
                    }
                    catch(Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                    }
                    
                }           
        }


        //to delete item
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Select data to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from citizenship WHERE Id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", this.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");

                    con.Close();

                    Display();
                    Clear();
                }
                catch(Exception ex)
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
