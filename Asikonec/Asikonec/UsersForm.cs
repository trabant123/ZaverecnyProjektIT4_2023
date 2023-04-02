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
    public partial class UsersForm : Form
    {
        User user = new User();

        public UsersForm()
        {
            InitializeComponent();
        }
        public void Display()
        {
            SqlDataReader display = user.giveData();
            while (display.Read())
            {
                ListViewItem item = new ListViewItem();

                item.Text = display["Role"].ToString();
                item.SubItems.Add(display["FirstName"].ToString());
                item.SubItems.Add(display["LastName"].ToString());
                item.SubItems.Add(display["Birthday"].ToString());
                item.SubItems.Add(display["Email"].ToString());
                item.SubItems.Add(display["PhoneNumber"].ToString());
                item.SubItems.Add(display["Username"].ToString());
                item.SubItems.Add(display["UserPassword"].ToString());

                item.Tag = display["Id"];

                listViewUsers.Items.Add(item);
            }

        }

        public void RefreshListView()
        {
            listViewUsers.Items.Clear();
            Display();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            user.Role = RoleComboBox.GetItemText(RoleComboBox.Text);
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
            user.Email = EmailTextBox.Text;
            user.PhoneNumber = int.Parse(PhoneNumberTextBox.Text);
            user.Username = UsernameTextBox.Text;
            user.UserPassword = PasswordTextBox.Text;
            user.Add();
            RefreshListView();
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            user.Id = int.Parse(listViewUsers.SelectedItems[0].Tag.ToString());
            user.Role = RoleComboBox.GetItemText(RoleComboBox.Text);
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
            user.Email = EmailTextBox.Text;
            user.PhoneNumber = int.Parse(PhoneNumberTextBox.Text);
            user.Username = UsernameTextBox.Text;
            user.UserPassword = PasswordTextBox.Text;
            user.Edit();
            RefreshListView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count != 0)
            {
                user.Id = int.Parse(listViewUsers.SelectedItems[0].Tag.ToString());
                user.Delete(user);
                RefreshListView();
            }
            else
            {
                MessageBox.Show("Please select record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProductionButton_Click(object sender, EventArgs e)
        {
            ProductionForm productionForm = new ProductionForm();
            productionForm.Show();
            this.Hide();
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count != 0)
            {
                if (listViewUsers.SelectedItems[0].Text == "Admin")
                {
                    RoleComboBox.SelectedIndex = 1;
                }
                else
                {
                    RoleComboBox.SelectedIndex = 0;
                }
                FirstNameTextBox.Text = listViewUsers.SelectedItems[0].SubItems[1].Text;
                LastNameTextBox.Text = listViewUsers.SelectedItems[0].SubItems[2].Text;
                BirthdayDateTimePicker.Value = DateTime.Parse(listViewUsers.SelectedItems[0].SubItems[3].Text);
                EmailTextBox.Text = listViewUsers.SelectedItems[0].SubItems[4].Text;
                PhoneNumberTextBox.Text = listViewUsers.SelectedItems[0].SubItems[5].Text;
                UsernameTextBox.Text = listViewUsers.SelectedItems[0].SubItems[6].Text;
                PasswordTextBox.Text = listViewUsers.SelectedItems[0].SubItems[7].Text;
            }
        }
    }
}
