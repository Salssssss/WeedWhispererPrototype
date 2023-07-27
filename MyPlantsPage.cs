using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeedWhisperPrototypeApp
{
    public partial class MyPlantsPage : Form
    {
        private MyPlants myPlants;
        private int userId;
        private PlantDAO plantDAO;
        public MyPlantsPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            myPlants = new MyPlants(userId);
            plantDAO = new PlantDAO();  
        }

        private void MyPlantsPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the current user's plants
            var plants = myPlants.GetMyPlants();

            checkedListBox1.Items.Clear();

            foreach (Plant plant in plants)
            {
                checkedListBox1.Items.Add($"{plant.Name} ({plant.Symbol}) - {plant.PlantGroup}\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlantRecomendationPage pl = new PlantRecomendationPage(userId);
            pl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> plants = new List<string>();
            foreach (string plant in checkedListBox1.CheckedItems)
            {
                string plantname = plant.Split(' ')[0];          
                plants.Add(plantname);
            }
            foreach (string plant in plants)
            {
                Plant plantToRemove = plantDAO.GetPlantByName(plant);
                myPlants.RemovePlant(plantToRemove.Id);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoggedInForm loggedInForm = new LoggedInForm(userId);
            loggedInForm.Show();

        }
    }
}
