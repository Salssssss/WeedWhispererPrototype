using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeedWhisperPrototypeApp
{
    public partial class UserRegisterLogin : Form
    {
        public UserRegisterLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            UserVerifier verifier = new UserVerifier();

            // Verify user credentials
            if (verifier.VerifyUserCredentials(email, password))
            {
                UserDAO userDAO = new UserDAO();
                // Credentials are valid, open the LoggedInForm
                int userId = userDAO.GetUserByEmail(email).id; // You may need to implement this method in UserVerifier
                LoggedInForm loggedInForm = new LoggedInForm(userId);
                loggedInForm.Show();
                this.Hide(); // Hide the login form (optional, you may close it instead)
            }
            else
            {
                // Credentials are invalid, display an error message
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }
    }
}
