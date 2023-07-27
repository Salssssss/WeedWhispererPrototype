using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPasswordRegister.UseSystemPasswordChar = true;
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
                this.Hide();
                loggedInForm.Show();
            }
            else
            {
                // Credentials are invalid, display an error message
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsernameRegister.Text;
            string email = textBoxEmailRegister.Text;
            string password = textBoxPasswordRegister.Text;

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new user and add to the database
            UserDAO userDAO = new UserDAO();
            User newUser = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            try
            {
                userDAO.AddUser(newUser);
                MessageBox.Show("User registration successful!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggedInForm loggedInForm = new LoggedInForm(newUser.id);
                this.Hide();
                loggedInForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while registering the user: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
