using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class FeedbackForm : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-IUGD8B6L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        public FeedbackForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int easeRating = GetCheckBoxRating(groupBox1);
            string technicalIssue = textBox1.Text;
            string suggestion = textBox2.Text;

            SaveFeedbackToDatabase(easeRating, technicalIssue, suggestion);

            MessageBox.Show("Thank you for your feedback!", "Feedback Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetCheckBoxRating(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    // Assuming the Tag property of the CheckBox contains the rating
                    if (int.TryParse(checkBox.Tag?.ToString(), out int rating))
                    {
                        return rating;
                    }
                }
            }
            return 0;
        }

        private void SaveFeedbackToDatabase(int easeRating, string technicalIssue, string suggestion)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO FeedbackResponses (Rating, TechnicalIssue, Suggestion) " +
                               "VALUES (@Rating, @TechnicalIssue, @Suggestion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rating", easeRating);
                    command.Parameters.AddWithValue("@TechnicalIssue", technicalIssue);
                    command.Parameters.AddWithValue("@Suggestion", suggestion);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void OpenHomeForm()
        {
            Homepage homePage = new Homepage();
            homePage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteFeedbackFromDatabase();

            MessageBox.Show("Feedback deleted successfully!", "Feedback Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenHomeForm();

            this.Close();
        }

        private void DeleteFeedbackFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM FeedbackResponses";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenHomeForm();
        }
    }
}
