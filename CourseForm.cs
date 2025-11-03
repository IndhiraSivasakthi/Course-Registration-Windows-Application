using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;


namespace Project
{
    public partial class CourseForm : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public CourseForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string registerNo = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(registerNo))
            {
                MessageBox.Show("Please enter a valid register number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                FetchAndDisplayDetails(registerNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchAndDisplayDetails(string registerNo)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Fetch student details
                string studentQuery = "SELECT Name, Programme, Department, Semester, Photo FROM Students WHERE RegisterNo = @RegisterNo";
                using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("@RegisterNo", registerNo);

                    using (SqlDataReader studentReader = studentCommand.ExecuteReader())
                    {
                        if (studentReader.Read())
                        {
                            // Display fetched student details in labels
                            label7.Text = "NAME: " + studentReader["Name"].ToString();
                            label8.Text = "PROGRAMME: " + studentReader["Programme"].ToString();
                            label9.Text = "DEPARTMENT: " + studentReader["Department"].ToString();
                            label10.Text = "SEMESTER: " + studentReader["Semester"].ToString();

                            // Fetch and display the photo
                            if (studentReader["Photo"] != DBNull.Value)
                            {
                                byte[] photoBytes = (byte[])studentReader["Photo"];
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
                            return;
                        }
                    }
                }

                // Fetch course details
                string courseQuery = "SELECT Subject1, SubjectCode1, TheoryLab1, Staff1, " +
                                     "Subject2, SubjectCode2, TheoryLab2, Staff2, " +
                                     "Subject3, SubjectCode3, TheoryLab3, Staff3, " +
                                     "Subject4, SubjectCode4, TheoryLab4, Staff4, " +
                                     "Subject5, SubjectCode5, TheoryLab5, Staff5, " +
                                     "Subject6, SubjectCode6, TheoryLab6, Staff6, " +
                                     "Subject7, SubjectCode7, TheoryLab7, Staff7 " +
                                     "FROM CourseDetails WHERE RegisterNo = @RegisterNo";

                using (SqlCommand courseCommand = new SqlCommand(courseQuery, connection))
                {
                    courseCommand.Parameters.AddWithValue("@RegisterNo", registerNo);

                    using (SqlDataReader courseReader = courseCommand.ExecuteReader())
                    {
                        if (courseReader.Read())
                        {
                            label7.Text = "Subject 1: " + courseReader["Subject1"].ToString();
                            label14.Text = "Sub Code: " + courseReader["SubjectCode1"].ToString();
                            label21.Text = "Theory/Lab: " + courseReader["TheoryLab1"].ToString();
                            label28.Text = "Staff: " + courseReader["Staff1"].ToString();


                            label8.Text = "Subject 2: " + courseReader["Subject2"].ToString();
                            label15.Text = "Sub Code: " + courseReader["SubjectCode2"].ToString();
                            label22.Text = "Theory/Lab: " + courseReader["TheoryLab2"].ToString();
                            label29.Text = "Staff: " + courseReader["Staff2"].ToString();

                            label9.Text = "Subject 3: " + courseReader["Subject3"].ToString();
                            label16.Text = "Sub Code: " + courseReader["SubjectCode3"].ToString();
                            label23.Text = "Theory/Lab: " + courseReader["TheoryLab3"].ToString();
                            label30.Text = "Staff: " + courseReader["Staff3"].ToString();

                            label10.Text = "Subject 4: " + courseReader["Subject4"].ToString();
                            label17.Text = "Sub Code: " + courseReader["SubjectCode4"].ToString();
                            label24.Text = "Theory/Lab: " + courseReader["TheoryLab4"].ToString();
                            label31.Text = "Staff: " + courseReader["Staff4"].ToString();

                            label9.Text = "Subject 5: " + courseReader["Subject5"].ToString();
                            label18.Text = "Sub Code : " + courseReader["SubjectCode5"].ToString();
                            label25.Text = "Theory/Lab: " + courseReader["TheoryLab5"].ToString();
                            label32.Text = "Staff: " + courseReader["Staff5"].ToString();

                            label12.Text = "Subject 6: " + courseReader["Subject6"].ToString();
                            label19.Text = "Sub Code: " + courseReader["SubjectCode6"].ToString();
                            label26.Text = "Theory/Lab: " + courseReader["TheoryLab6"].ToString();
                            label33.Text = "Staff: " + courseReader["Staff6"].ToString();

                            label13.Text = "Subject 7: " + courseReader["Subject7"].ToString();
                            label20.Text = "Sub Code: " + courseReader["SubjectCode7"].ToString();
                            label27.Text = "Theory/Lab: " + courseReader["TheoryLab7"].ToString();
                            label34.Text = "Staff: " + courseReader["Staff7"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Course details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
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


        private void OpenHomeForm()
        {
            Homepage homePage = new Homepage();
            homePage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            OpenHomeForm();
        }
    }
}
