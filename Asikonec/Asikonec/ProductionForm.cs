using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Asikonec
{
    public partial class ProductionForm : Form
    {
        Work work = new Work();
        

        public ProductionForm()
        {
            InitializeComponent();
        }
        public void Display()
        {
            SqlDataReader display = work.giveData();
            while (display.Read())
            {
                ListViewItem item = new ListViewItem();

                item.Text = display["UserId"].ToString();
                item.SubItems.Add(display["TaskId"].ToString());
                item.SubItems.Add(display["WorkType"].ToString());
                item.SubItems.Add(display["WorkHours"].ToString());

                item.Tag = display["Id"];

                listViewProduction.Items.Add(item);
            }

        }

        private void ProductionForm_Load(object sender, EventArgs e)
        {
            Display();
            
        }

        public void RefreshListView()
        {
            listViewProduction.Items.Clear();
            Display();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            work.UserId = int.Parse(UserTextBox.Text);
            work.TaskId = int.Parse(TaskTextBox.Text);
            work.WorkHours = HoursTextBox.Text;
            work.Add();
            RefreshListView();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            work.Id = int.Parse(listViewProduction.SelectedItems[0].Tag.ToString());
            work.UserId = int.Parse(UserTextBox.Text);
            work.TaskId = int.Parse(TaskTextBox.Text);
            work.WorkType = listViewProduction.SelectedItems[0].SubItems[2].Text;
            work.WorkHours = HoursTextBox.Text;
            work.Edit();
            RefreshListView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(listViewProduction.SelectedItems.Count != 0)
            {
                work.Id = int.Parse(listViewProduction.SelectedItems[0].Tag.ToString());
                work.Delete(work);
                RefreshListView();
            }
            else
            {
                MessageBox.Show("Please select record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
            this.Hide();
        }

        private void listViewProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProduction.SelectedItems.Count != 0)
            {
                UserTextBox.Text = listViewProduction.SelectedItems[0].Text;
                TaskTextBox.Text = listViewProduction.SelectedItems[0].SubItems[1].Text;
                WorkTypeTextBox.Text = listViewProduction.SelectedItems[0].SubItems[2].Text;
                HoursTextBox.Text = listViewProduction.SelectedItems[0].SubItems[3].Text;
            }
        }
    }
}
