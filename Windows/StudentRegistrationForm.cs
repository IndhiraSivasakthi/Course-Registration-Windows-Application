using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class StudentRegistrationForm : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public StudentRegistrationForm()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Save data to the database
                SaveDataToDatabase();
            }
        }
        private bool ValidateInput()
        {
            // Check if Name is not empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if Register No is not empty
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a valid register number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if Department is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if Semester is selected
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a semester.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if Year is selected
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if Email is valid
            if (!IsValidEmail(textBox3.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Programme.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter a valid contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter a valid section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter a valid regulation.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            // You can add more validation rules as needed

            // If all checks pass, return true
            return true;
        }

        private bool IsValidEmail(string email)
        {
            // You can implement a more sophisticated email validation if needed

            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Reset all input fields
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            pictureBox1.Image = null;
        }

        private void SaveDataToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string query = "INSERT INTO Students (Name, RegisterNo, Department, Semester, Year, Email,ContactNo,Section,Regulation,Programme,Photo) " +
                               "VALUES (@Name, @RegisterNo, @Department, @Semester, @Year, @Email,@ContactNo,@Section,@Regulation,@Programme, @Photo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameters with input data
                    command.Parameters.AddWithValue("@Name", textBox1.Text);
                    command.Parameters.AddWithValue("@RegisterNo", textBox2.Text);
                    command.Parameters.AddWithValue("@Department", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Semester", comboBox3.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Year", comboBox2.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Email", textBox3.Text);
                    command.Parameters.AddWithValue("@ContactNo", textBox4.Text);
                    command.Parameters.AddWithValue("@Section", textBox5.Text);
                    command.Parameters.AddWithValue("@Regulation", textBox6.Text);
                    command.Parameters.AddWithValue("@Programme", comboBox4.SelectedItem.ToString());




                    // Check if the PictureBox contains an image before attempting to save
                    if (pictureBox1.Image != null)
                    {
                        // Convert the image to bytes and save to the database
                        byte[] photoBytes = ImageToByteArray(pictureBox1.Image);
                        command.Parameters.AddWithValue("@Photo", photoBytes);
                    }
                    else
                    {
                        // If no image is selected, set the parameter to NULL or a default value as needed
                        command.Parameters.AddWithValue("@Photo", DBNull.Value);
                    }

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student registration successful!");
                    }
                    else
                    {
                        MessageBox.Show("Error occurred during student registration. Please try again.");
                    }
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Implement logic to upload and display a photo
            // For simplicity, let's assume a file dialog for photo selection

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into the PictureBox
                    pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenHomeForm();
        }


        private void OpenHomeForm()
        {
            Homepage homePage = new Homepage();
            homePage.Show();
            this.Hide(); // Hide the current form
        }
       
    }
}
