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

namespace Project
{
    public partial class Register : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string email = textBox4.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            try
            {
                // Check if the username or email is already taken
                if (IsUsernameOrEmailTaken(username, email))
                {
                    MessageBox.Show("Username or email is already taken. Please choose different ones.");
                    return;
                }

                // Register the user in the database
                if (RegisterUser(username, password, email))
                {
                    MessageBox.Show("Registration successful!");

                    // Set DialogResult to OK before closing the form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error occurred during registration. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database operations
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private bool IsUsernameOrEmailTaken(string username, string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Query to count rows with the provided username or email
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username OR Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);

                    // ExecuteScalar returns the number of rows that satisfy the condition
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, the username or email is already taken
                    return count > 0;
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Method to register the user in the database
        private bool RegisterUser(string username, string password, string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Query to insert a new user into the Users table
                string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email);

                    // ExecuteNonQuery returns the number of rows affected
                    int rowsAffected = command.ExecuteNonQuery();

                    // If rowsAffected is greater than 0, registration is successful
                    return rowsAffected > 0;
                }
                
            }

        }

       
    }
}
