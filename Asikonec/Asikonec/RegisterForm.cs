using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asikonec
{
    public partial class RegisterForm : Form
    {
        User user = new User();
        public RegisterForm()
        {
            InitializeComponent();
        }
        
        public void Display()
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            user.Role = "User";
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
            user.Email = EmailTextBox.Text;
            user.PhoneNumber = int.Parse(PhoneNumberTextBox.Text);
            user.Username = UserNameTextBox.Text;
            user.UserPassword = PasswordTextBox.Text;
            user.Add();
        }
    }
}
