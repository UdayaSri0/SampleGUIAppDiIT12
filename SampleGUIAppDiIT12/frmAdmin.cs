using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleGUIAppDiIT12
{
    public partial class frmAdmin : Form
    {
        // Instantiate the Database class
        Database db = new Database();

        public frmAdmin()
        {
            InitializeComponent();
            LoadUserData();  // Load data when the form opens
            txtAccountName.Text = "Logged in as Admin";  // Example display for logged-in admin
        }

        // Method to load user data into DataGridView
        private void LoadUserData()
        {
            // Fetch data from the database
            DataTable dt = db.GetUsers();

            // Bind data to DataGridView
            dataGridViewUserData.DataSource = dt;
        }

        // Insert Button Click Event
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (db.InsertUser(username, password, "User"))  // Assuming all new users are regular users
            {
                MessageBox.Show("User inserted successfully!");
                LoadUserData();  // Refresh the DataGridView after insertion
            }
            else
            {
                MessageBox.Show("Failed to insert user.");
            }
        }

        // Delete Button Click Event
        private void txtDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserData.SelectedRows.Count > 0)
            {
                int userID = Convert.ToInt32(dataGridViewUserData.SelectedRows[0].Cells["UserID"].Value);

                if (db.DeleteUser(userID))
                {
                    MessageBox.Show("User deleted successfully!");
                    LoadUserData();  // Refresh the DataGridView after deletion
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        // Search Button Click Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            DataTable dt = db.SearchUser(username);
            dataGridViewUserData.DataSource = dt;  // Set the filtered data as the new data source
        }

        // Logout Button Click Event
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        // Update Button Click Event
        private void txtUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewUserData.SelectedRows.Count > 0)
            {
                int userID = Convert.ToInt32(dataGridViewUserData.SelectedRows[0].Cells["UserID"].Value);
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (db.UpdateUser(userID, username, password))
                {
                    MessageBox.Show("User updated successfully!");
                    LoadUserData();  // Refresh the DataGridView after update
                }
                else
                {
                    MessageBox.Show("Failed to update user.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }

        }
    }
}