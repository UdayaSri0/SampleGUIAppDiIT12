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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                // Get the input values from the textboxes
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Check if any field is empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please fill in both Username and Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create an instance of the Database class and call the Login method
                Database db = new Database();
                DataTable dt = db.Login(username, password);

                // Check if user exists and handle redirection based on user role
                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["Role"].ToString();

                    // Open the respective form based on the role
                    if (role == "Admin")
                    {
                        frmAdmin adminForm = new frmAdmin();
                        adminForm.Show();
                        this.Hide();  // Hide the login form
                    }
                    else if (role == "User")
                    {
                        frmUser userForm = new frmUser();
                        userForm.Show();
                        this.Hide();  // Hide the login form
                    }
                    else
                    {
                        MessageBox.Show("Invalid role assigned. Contact administrator.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();  // Set focus back to the username field
        }
    }
}
