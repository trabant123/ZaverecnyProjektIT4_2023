using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asikonec
{
    internal class User
    {
        public int Id;
        public string Role;
        public string FirstName;
        public string LastName;
        public string Birthday;
        public string Email;
        public int PhoneNumber;
        public string Username;
        public string UserPassword;

        public User() 
        {
            
        }

        public SqlDataReader giveData()
        {
            SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
            connString.Open();
            SqlCommand comm = connString.CreateCommand();
            comm.CommandText = "SELECT Id as Id, Role as Role, FirstName as FirstName, LastName as LastName, Birthday as Birthday, Email as Email, Phonenumber as PhoneNumber, Username as Username, UserPassword as UserPassword FROM Users";
            SqlDataReader sqlDataReader = comm.ExecuteReader();
            return sqlDataReader;
            connString.Close();
        }

        public SqlDataReader getUser(string Name)
        {
            SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
            connString.Open();
            SqlCommand comm = connString.CreateCommand();
            comm.CommandText = $"SELECT Role as Role, Username as Username, UserPassword as UserPassword FROM Users WHERE Username = '{Name}'";
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
                comm.CommandText = $"INSERT INTO Users (Role, FirstName, LastName, Birthday, Email, PhoneNumber, Username, UserPassword) VALUES ('{Role}', '{FirstName}', '{LastName}', '{Birthday}', '{Email}', {PhoneNumber}, '{Username}', '{UserPassword}')";
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
            /*try
            {*/
                SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
                connString.Open();
                SqlCommand comm = connString.CreateCommand();
                comm.CommandText = $"UPDATE Users SET Role = '{Role}', Firstname = '{FirstName}', LastName = '{LastName}', Birthday = '{Birthday}', Email = '{Email}', PhoneNumber = {PhoneNumber}, Username = '{Username}', UserPassword = '{UserPassword}' WHERE Id = {Id}";
                comm.ExecuteNonQuery();
                connString.Close();
            /*}
            catch
            {
                MessageBox.Show("Please insert correct values.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public void Delete(User user)
        {
            SqlConnection connString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Administrace;Integrated Security=True");
            connString.Open();
            SqlCommand comm = connString.CreateCommand();
            comm.CommandText = $"DELETE Users WHERE Users.Id = {Id}";
            comm.ExecuteNonQuery();
            connString.Close();

        }
    }
}
