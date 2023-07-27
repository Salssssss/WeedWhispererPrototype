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
    public partial class LoggedInForm : Form
    {
        private int userId;
        private UserDAO userDAO;
        public LoggedInForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            userDAO = new UserDAO();
        }

        private void LoggedInForm_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = userDAO.GetUserById(userId);
            LabelUsername.Text = "Welcome! " + user.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyPlantsPage myPlantsPage = new MyPlantsPage(userId);
            myPlantsPage.Show();
            this.Hide();
        }

        private void LabelUsername_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserRegisterLogin userRegisterLogin = new UserRegisterLogin();
            userRegisterLogin.Show();
            this.Close();
        }
    }
}
