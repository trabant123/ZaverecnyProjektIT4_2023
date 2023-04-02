using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asikonec
{
    internal class Work
    {
        public int Id;
        public int UserId;
        public int TaskId;
        public string WorkType;
        public string WorkHours;

        public Work() 
        {
        
        }
        public SqlDataReader giveData()
        {
            SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
            connString.Open();
            SqlCommand comm = connString.CreateCommand();
            comm.CommandText = "SELECT Production.Id as Id,Users.Id as UserId,Tasks.Id as TaskId,Tasks.WorkType as WorkType,Production.WorkHours as WorkHours FROM Production " +
                "inner join Users on Users.Id = Production.UserId " +
                "inner join Tasks on Tasks.Id = Production.TaskId";
            SqlDataReader sqlDataReader = comm.ExecuteReader();
            return sqlDataReader;
            connString.Close();
        }
        public void Add()
        {
            try
            {
                SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
                connString.Open();
                SqlCommand comm = connString.CreateCommand();
                comm.CommandText = $"INSERT INTO Production (UserId, TaskId, WorkHours) VALUES ({UserId},{TaskId},{WorkHours})";
                comm.ExecuteNonQuery();
                connString.Close();
            }
            catch
            {
                MessageBox.Show("Please insert correct values.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Edit()
        {
            try
            {
                SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
                connString.Open();
                SqlCommand comm = connString.CreateCommand();
                comm.CommandText = $"UPDATE Production SET UserId = {UserId}, TaskId = {TaskId}, WorkHours = {WorkHours} WHERE Id = {Id}";
                comm.ExecuteNonQuery();
                connString.Close();
            }
            catch
            {
                MessageBox.Show("Please insert correct values.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(Work work)
        {
            SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
            connString.Open();
            SqlCommand comm = connString.CreateCommand();
            comm.CommandText = $"DELETE Production WHERE Production.Id = {Id}";
            comm.ExecuteNonQuery();
            connString.Close();

        }
    }
}
