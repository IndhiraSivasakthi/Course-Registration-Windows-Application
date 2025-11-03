using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class CourseDetailsForm : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public CourseDetailsForm()
        {
            InitializeComponent();
        }

        private void CourseDetailsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!AreAllFieldsFilled())
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                
                SaveDataToDatabase();
                AreAllFieldsFilled();
                ClearFormData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SaveDataToDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO CourseDetails (RegisterNo, Semester, Subject1, SubjectCode1, TheoryLab1, Staff1, Subject2, SubjectCode2, TheoryLab2, Staff2, Subject3, SubjectCode3, TheoryLab3, Staff3, Subject4, SubjectCode4, TheoryLab4, Staff4, Subject5, SubjectCode5, TheoryLab5, Staff5, Subject6, SubjectCode6, TheoryLab6, Staff6, Subject7, SubjectCode7, TheoryLab7, Staff7) " +
                                         "VALUES (@RegisterNo, @Semester, @Subject1, @SubjectCode1, @TheoryLab1, @Staff1, @Subject2, @SubjectCode2, @TheoryLab2, @Staff2, @Subject3, @SubjectCode3, @TheoryLab3, @Staff3, @Subject4, @SubjectCode4, @TheoryLab4, @Staff4, @Subject5, @SubjectCode5, @TheoryLab5, @Staff5, @Subject6, @SubjectCode6, @TheoryLab6, @Staff6, @Subject7, @SubjectCode7, @TheoryLab7, @Staff7)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RegisterNo", textBox1.Text);
                    command.Parameters.AddWithValue("@Semester", textBox9.Text);
                    command.Parameters.AddWithValue("@Subject1", comboBox1.Text);
                    command.Parameters.AddWithValue("@SubjectCode1", textBox2.Text);
                    command.Parameters.AddWithValue("@TheoryLab1", comboBox29.Text);
                    command.Parameters.AddWithValue("@Staff1", comboBox36.Text);


                    command.Parameters.AddWithValue("@Subject2", comboBox2.Text);
                    command.Parameters.AddWithValue("@SubjectCode2", textBox3.Text);
                    command.Parameters.AddWithValue("@TheoryLab2", comboBox30.Text);
                    command.Parameters.AddWithValue("@Staff2", comboBox37.Text);

                    command.Parameters.AddWithValue("@Subject3", comboBox3.Text);
                    command.Parameters.AddWithValue("@SubjectCode3", textBox4.Text);
                    command.Parameters.AddWithValue("@TheoryLab3", comboBox31.Text);
                    command.Parameters.AddWithValue("@Staff3", comboBox38.Text);


                    command.Parameters.AddWithValue("@Subject4", comboBox4.Text);
                    command.Parameters.AddWithValue("@SubjectCode4", textBox5.Text);
                    command.Parameters.AddWithValue("@TheoryLab4", comboBox32.Text);
                    command.Parameters.AddWithValue("@Staff4", comboBox39.Text);


                    command.Parameters.AddWithValue("@Subject5", comboBox5.Text);
                    command.Parameters.AddWithValue("@SubjectCode5", textBox6.Text);
                    command.Parameters.AddWithValue("@TheoryLab5", comboBox33.Text);
                    command.Parameters.AddWithValue("@Staff5", comboBox40.Text);


                    command.Parameters.AddWithValue("@Subject6", comboBox6.Text);
                    command.Parameters.AddWithValue("@SubjectCode6", textBox7.Text);
                    command.Parameters.AddWithValue("@TheoryLab6", comboBox34.Text);
                    command.Parameters.AddWithValue("@Staff6", comboBox41.Text);


                    command.Parameters.AddWithValue("@Subject7", comboBox7.Text);
                    command.Parameters.AddWithValue("@SubjectCode7", textBox8.Text);
                    command.Parameters.AddWithValue("@TheoryLab7", comboBox35.Text);
                    command.Parameters.AddWithValue("@Staff7", comboBox42.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course Registration successful!");
                            
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                        OpenHomeForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
           
        }

        private bool AreAllFieldsFilled()
        {
           
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                  !string.IsNullOrWhiteSpace(textBox9.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                  !string.IsNullOrWhiteSpace(textBox2.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox29.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox36.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                  !string.IsNullOrWhiteSpace(textBox3.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox30.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox37.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox3.Text) &&
                  !string.IsNullOrWhiteSpace(textBox4.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox31.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox38.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox4.Text) &&
                  !string.IsNullOrWhiteSpace(textBox5.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox32.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox39.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox5.Text) &&
                  !string.IsNullOrWhiteSpace(textBox6.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox33.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox40.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox6.Text) &&
                  !string.IsNullOrWhiteSpace(textBox7.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox34.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox41.Text) &&

                  !string.IsNullOrWhiteSpace(comboBox7.Text) &&
                  !string.IsNullOrWhiteSpace(textBox8.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox35.Text) &&
                  !string.IsNullOrWhiteSpace(comboBox42.Text);

           
        }
        private void ClearFormData()
        {
            
            textBox1.Text = string.Empty;
            textBox9.Text = string.Empty;

            comboBox1.SelectedIndex = -1;
            textBox2.Text = string.Empty;
            comboBox29.SelectedIndex = -1;
            comboBox36.SelectedIndex = -1;

    
           
            comboBox2.SelectedIndex = -1;
            textBox3.Text = string.Empty;
            comboBox30.SelectedIndex = -1;
            comboBox37.SelectedIndex = -1;

            comboBox3.SelectedIndex = -1;
            textBox4.Text = string.Empty;
            comboBox31.SelectedIndex = -1;
            comboBox38.SelectedIndex = -1;
  
            comboBox4.SelectedIndex = -1;
            textBox5.Text = string.Empty;
            comboBox32.SelectedIndex = -1;
            comboBox39.SelectedIndex = -1;
            
            comboBox5.SelectedIndex = -1;
            textBox6.Text = string.Empty;
            comboBox33.SelectedIndex = -1;
            comboBox40.SelectedIndex = -1;
           
            comboBox6.SelectedIndex = -1;
            textBox7.Text = string.Empty;
            comboBox34.SelectedIndex = -1;
            comboBox41.SelectedIndex = -1;

            comboBox7.SelectedIndex = -1;
            textBox8.Text = string.Empty;
            comboBox35.SelectedIndex = -1;
            comboBox42.SelectedIndex = -1;

           
        }


        private void OpenHomeForm()
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenHomeForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string registerNo = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(registerNo))
            {
                FetchAndDisplayCourseDetails(registerNo);
            }
            else
            {
                MessageBox.Show("Please enter a valid register number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAndDisplayCourseDetails(string registerNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Semester, Subject1, SubjectCode1, TheoryLab1, Staff1, " +
                                   "Subject2, SubjectCode2, TheoryLab2, Staff2, " +
                                   "Subject3, SubjectCode3, TheoryLab3, Staff3, " +
                                   "Subject4, SubjectCode4, TheoryLab4, Staff4, " +
                                   "Subject5, SubjectCode5, TheoryLab5, Staff5, " +
                                   "Subject6, SubjectCode6, TheoryLab6, Staff6, " +
                                   "Subject7, SubjectCode7, TheoryLab7, Staff7 " +
                                   "FROM CourseDetails WHERE RegisterNo = @RegisterNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RegisterNo", registerNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display fetched details in the form
                                textBox9.Text = reader["Semester"].ToString();
                                comboBox1.Text = reader["Subject1"].ToString();
                                textBox2.Text = reader["SubjectCode1"].ToString();
                                comboBox29.Text = reader["TheoryLab1"].ToString();
                                comboBox36.Text = reader["Staff1"].ToString();

                                comboBox2.Text = reader["Subject2"].ToString();
                                textBox3.Text = reader["SubjectCode2"].ToString();
                                comboBox30.Text = reader["TheoryLab2"].ToString();
                                comboBox37.Text = reader["Staff2"].ToString();

                                comboBox3.Text = reader["Subject3"].ToString();
                                textBox4.Text = reader["SubjectCode3"].ToString();
                                comboBox31.Text = reader["TheoryLab3"].ToString();
                                comboBox38.Text = reader["Staff3"].ToString();

                                comboBox4.Text = reader["Subject4"].ToString();
                                textBox5.Text = reader["SubjectCode4"].ToString();
                                comboBox32.Text = reader["TheoryLab4"].ToString();
                                comboBox39.Text = reader["Staff4"].ToString();

                                comboBox5.Text = reader["Subject5"].ToString();
                                textBox6.Text = reader["SubjectCode5"].ToString();
                                comboBox33.Text = reader["TheoryLab5"].ToString();
                                comboBox40.Text = reader["Staff5"].ToString();

                                comboBox6.Text = reader["Subject6"].ToString();
                                textBox7.Text = reader["SubjectCode6"].ToString();
                                comboBox34.Text = reader["TheoryLab6"].ToString();
                                comboBox41.Text = reader["Staff6"].ToString();

                                comboBox7.Text = reader["Subject7"].ToString();
                                textBox8.Text = reader["SubjectCode7"].ToString();
                                comboBox35.Text = reader["TheoryLab7"].ToString();
                                comboBox42.Text = reader["Staff7"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Course details not found with the provided register number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AreAllFieldsFilled())
            {
                UpdateCourseDetailsInDatabase();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void UpdateCourseDetailsInDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE CourseDetails SET " +
                                        "Semester = @Semester, " +
                                        "Subject1 = @Subject1, SubjectCode1 = @SubjectCode1, TheoryLab1 = @TheoryLab1, Staff1 = @Staff1, " +
                                        "Subject2 = @Subject2, SubjectCode2 = @SubjectCode2, TheoryLab2 = @TheoryLab2, Staff2 = @Staff2, " +
                                        "Subject3 = @Subject3, SubjectCode3 = @SubjectCode3, TheoryLab3 = @TheoryLab3, Staff3 = @Staff3, " +
                                        "Subject4 = @Subject4, SubjectCode4 = @SubjectCode4, TheoryLab4 = @TheoryLab4, Staff4 = @Staff4, " +
                                        "Subject5 = @Subject5, SubjectCode5 = @SubjectCode5, TheoryLab5 = @TheoryLab5, Staff5 = @Staff5, " +
                                        "Subject6 = @Subject6, SubjectCode6 = @SubjectCode6, TheoryLab6 = @TheoryLab6, Staff6 = @Staff6, " +
                                        "Subject7 = @Subject7, SubjectCode7 = @SubjectCode7, TheoryLab7 = @TheoryLab7, Staff7 = @Staff7 " +
                                        "WHERE RegisterNo = @RegisterNo";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        SetCommandParameters(command);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course details updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // The SetCommandParameters method is used to set parameters for the SQL command
        private void SetCommandParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@RegisterNo", textBox1.Text);
            command.Parameters.AddWithValue("@Semester", textBox9.Text);
            command.Parameters.AddWithValue("@Subject1", comboBox1.Text);
            command.Parameters.AddWithValue("@SubjectCode1", textBox2.Text);
            command.Parameters.AddWithValue("@TheoryLab1", comboBox29.Text);
            command.Parameters.AddWithValue("@Staff1", comboBox36.Text);

            command.Parameters.AddWithValue("@Subject2", comboBox2.Text);
            command.Parameters.AddWithValue("@SubjectCode2", textBox3.Text);
            command.Parameters.AddWithValue("@TheoryLab2", comboBox30.Text);
            command.Parameters.AddWithValue("@Staff2", comboBox37.Text);

            command.Parameters.AddWithValue("@Subject3", comboBox3.Text);
            command.Parameters.AddWithValue("@SubjectCode3", textBox4.Text);
            command.Parameters.AddWithValue("@TheoryLab3", comboBox31.Text);
            command.Parameters.AddWithValue("@Staff3", comboBox38.Text);

            command.Parameters.AddWithValue("@Subject4", comboBox4.Text);
            command.Parameters.AddWithValue("@SubjectCode4", textBox5.Text);
            command.Parameters.AddWithValue("@TheoryLab4", comboBox32.Text);
            command.Parameters.AddWithValue("@Staff4", comboBox39.Text);

            command.Parameters.AddWithValue("@Subject5", comboBox5.Text);
            command.Parameters.AddWithValue("@SubjectCode5", textBox6.Text);
            command.Parameters.AddWithValue("@TheoryLab5", comboBox33.Text);
            command.Parameters.AddWithValue("@Staff5", comboBox40.Text);

            command.Parameters.AddWithValue("@Subject6", comboBox6.Text);
            command.Parameters.AddWithValue("@SubjectCode6", textBox7.Text);
            command.Parameters.AddWithValue("@TheoryLab6", comboBox34.Text);
            command.Parameters.AddWithValue("@Staff6", comboBox41.Text);

            command.Parameters.AddWithValue("@Subject7", comboBox7.Text);
            command.Parameters.AddWithValue("@SubjectCode7", textBox8.Text);
            command.Parameters.AddWithValue("@TheoryLab7", comboBox35.Text);
            command.Parameters.AddWithValue("@Staff7", comboBox42.Text);
        }

    }
}
