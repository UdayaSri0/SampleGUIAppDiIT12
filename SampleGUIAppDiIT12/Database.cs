using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGUIAppDiIT12
{
    internal class Database
    {
        // Connection string (replace with your actual database connection string)
        private string connectionString = "Data Source=darkstar;Initial Catalog=SampleGUIAppDiIT12;Integrated Security=True;Encrypt=False";

        // Method to verify login credentials
        public DataTable Login(string username, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }

            return dt;
        }
    }
}
