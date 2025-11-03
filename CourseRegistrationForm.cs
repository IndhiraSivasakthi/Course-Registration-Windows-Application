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
using System.IO;

namespace Project
{
    public partial class CourseRegistrationForm : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public CourseRegistrationForm()
        {
            InitializeComponent();
        }

        private void CourseRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid registration number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fetch student details based on the registration number
            FetchStudentDetails(textBox1.Text);
        }
        private void FetchStudentDetails(string registrationNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string query = "SELECT Name, Programme, Department, Semester, Photo FROM Students WHERE RegisterNo = @RegisterNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter with input data
                    command.Parameters.AddWithValue("@RegisterNo", registrationNumber);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Display fetched details in labels
                            label7.Text = "NAME : " + reader["Name"].ToString();
                            label8.Text = "PROGRAMME : " + reader["Programme"].ToString();
                            label9.Text = "DEPARTMENT : " + reader["Department"].ToString();
                            label10.Text = "SEMESTER :" + reader["Semester"].ToString();

                            // Fetch and display the photo
                            if (reader["Photo"] != DBNull.Value)
                            {
                                byte[] photoBytes = (byte[])reader["Photo"];
                                pictureBox1.Image = ByteArrayToImage(photoBytes);
                            }
                            else
                            {
                                // If no photo is available, you can set a default image or leave it blank
                                pictureBox1.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Student not found with the provided registration number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenCourseDetails();
        }
        private void OpenCourseDetails()
        {
            CourseDetailsForm semesterone = new CourseDetailsForm();
            semesterone.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
