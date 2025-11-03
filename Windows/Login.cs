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
    public partial class Login : Form
    {

        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Check if both username and password are provided
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                // Validate the user by checking the database
                if (ValidateUser(username, password))
                {
                    

                    // Transition to the HomeForm
                    OpenHomeForm();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database operations
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Query to check if a user with the provided username and password exists
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // ExecuteScalar returns the number of rows that satisfy the condition
                    int count = (int)command.ExecuteScalar();

                    // If count is 1, the user with the provided credentials exists
                    return count == 1;
                }
            }
        }


        
        private void OpenHomeForm()
        {
            Homepage homePage = new Homepage();
            homePage.Show();
            this.Hide(); // Hide the current form
        }

        // Method to open the RegisterForm
        private void OpenRegisterForm()
        {
            Register registerForm = new Register();
            registerForm.Show();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenRegisterForm();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
       

