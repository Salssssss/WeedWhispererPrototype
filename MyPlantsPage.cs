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
        public MyPlantsPage()
        {
            InitializeComponent();
            myPlants = new MyPlants(1);
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

            // Clear the text box
            textBox1.Text = "";

            // Display the plants in the text box
            foreach (Plant plant in plants)
            {
                textBox1.Text += $"{plant.Name} ({plant.Symbol}) - {plant.PlantGroup}\r\n";
            }
        }
    }
}
