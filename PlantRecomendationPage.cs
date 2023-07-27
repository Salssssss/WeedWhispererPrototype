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
    public partial class PlantRecomendationPage : Form
    {
        private int userId;
        private PlantRecommendation pr;
        private PlantDAO plantDAO;
        private List<Plant> plants;
        public PlantRecomendationPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            pr = new PlantRecommendation();
            plantDAO = new PlantDAO();
            PopulateComboBoxes();
        }
        private void PopulateComboBoxes()
        {
            // Create a list of PlantGroups
            List<string> plantGroups = new List<string>
            {
                 "All",
                 "Flower",
                 "Vegetable",
                 "Herb",
                 // Add more as needed
            };
            comboBox1.Items.AddRange(plantGroups.ToArray());
            List<string> duration = new List<string>
            {
                "All",
                "Perenial",
                "Annual",
                "Biennial",
            };
            comboBox2.Items.AddRange(duration.ToArray());
            List<string> growthHabit = new List<string>
            {
                "All",
                "Shrub",
                "Herb",
                "Vine",
            };
            comboBox3.Items.AddRange(growthHabit.ToArray());
            List<string> Location = new List<string>
            {
                "Any",
                "Georgia",
                //Future iterations will include all states and possibly use gps data to get location information and categorize areas to show plants native to them.
                //for this prototype we are only showing Georgia 
            };
            comboBox4.Items.AddRange(Location.ToArray());
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPlantGroup = comboBox1.SelectedItem.ToString();
                if (selectedPlantGroup == "All") { selectedPlantGroup = null; }
                string selectedDuration = comboBox2.SelectedItem.ToString();
                if (selectedDuration == "All") { selectedDuration = null; }
                string selectedGrowthHabit = comboBox3.SelectedItem.ToString();
                if (selectedGrowthHabit == "All") { selectedGrowthHabit = null; }
                string selectedNativeStatus = comboBox4.SelectedItem.ToString();
                selectedNativeStatus = GetNativeStatusFromState(selectedNativeStatus);
                plants = pr.getRecommendedPlants(selectedNativeStatus, selectedGrowthHabit, selectedPlantGroup, selectedDuration);
            }
            catch
            {
                MessageBox.Show("Please select values for each dropdown.");
            }

            DisplayRecommendedPlants(plants);
        }
        private void DisplayRecommendedPlants(List<Plant> recommendedPlants)
        {
            // Clear the CheckedListBox
            checkedListBox1.Items.Clear();

            // Add the recommended plants to the CheckedListBox
            foreach (Plant plant in recommendedPlants)
            {
                checkedListBox1.Items.Add(plant.Name);
            }
        }
        private string GetNativeStatusFromState(string state)
        {
            // Define a dictionary to map states to their corresponding native status
            Dictionary<string, string> stateToNativeStatusMap = new Dictionary<string, string>
            {
             { "Georgia", "L48" },
             // Add other state mappings as needed
            };
            if (stateToNativeStatusMap.ContainsKey(state))
            {
                return stateToNativeStatusMap[state];
            }
            else
            {
                return null;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (string plant in checkedListBox1.CheckedItems)
                {
                    Plant plantToAdd = plantDAO.GetPlantByName(plant);
                    plantDAO.AddUserPlant(plantToAdd, userId);
                }
                MessageBox.Show("Selected plants added to MyPlants successfully.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
