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

namespace Asikonec
{
    public partial class LoginForm : Form
    {
        User user = new User();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string name = UserNameTextBox.Text;
            if (name != "")
            {
                SqlDataReader dataReader = user.getUser(name);
                while (dataReader.Read())
                {
                    string role = dataReader["Role"].ToString().Trim();
                    string password = dataReader["UserPassword"].ToString().Trim();
                    if (PasswordTextBox.Text == password)
                    {
                        if (role == "User")
                        {
                            ProductionForm productionForm = new ProductionForm();
                            productionForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            UsersForm usersForm = new UsersForm();
                            usersForm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorect username or password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorect username or password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
