using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenStudentForm();
        }
        private void OpenStudentForm()
        {
            StudentRegistrationForm Studentform = new StudentRegistrationForm();
            Studentform.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenCourseForm();

        }
        private void OpenCourseForm()
        {
            CourseRegistrationForm Courseform = new CourseRegistrationForm();
            Courseform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFeedbackForm();
        }
        private void OpenFeedbackForm()
        {
            FeedbackForm feedbackform = new FeedbackForm();
            feedbackform.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
