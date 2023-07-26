using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlantRecommendation
{
  private PlantDAO plantDAO;

  public PlantRecommendation()
  { 
    plantDAO = new PlantDAO();
  }

  public List<Plant> getRecommendedPlants(string nativeStatus = null, string growthHabit = null, string plantGroup = null, string duration = null)
  {
    // list of all available plants in the database
    List<Plant> allPlants = new List<Plant>();

    try
    //migrate plants to list
    {
      allPlants= plantDAO.GetAllPlants();
    }
    catch(Exception error)
    {
      Console.WriteLine("Error migrating plant data: " + error.Message);
      
      //if error occurs return empty list
      return new List<Plant>();
    }

    // list of recommended plants 
    List<Plant> recommendedList = new List<Plant>();

    // we'll recommened plants to user based on their desired parameters 

    // iterate through all plants in the data base
    foreach(Plant plant in allPlants)
    {
      
      // use method to check all desired parameters 
      if(PlantMatchCheck(plant, nativeStatus, growthHabit, plantGroup, duration))
      {  
          recommendedList.Add(plant); // adds plant that matches ALL parameters to recommeded list 

      }
    }

    // finally return recommeded plants to user
    return recommendedList;
  }
    
  // method for checking if user's desired parameters match parameters of a plant in database
  private bool PlantMatchCheck(Plant plant, string nativeStatus, string growthHabit, string plantGroup, string duration){

      // check to see if parameters match
      bool isNativeStatusMatch = string.IsNullOrEmpty(nativeStatus) || nativeStatus.Equals(plant.NativeStatus, StringComparison.OrdinalIgnoreCase);
      bool isGrowthHabitMatch = string.IsNullOrEmpty(growthHabit) || growthHabit.Equals(plant.GrowthHabit, StringComparison.OrdinalIgnoreCase);
      bool isPlantGroupMatch = string.IsNullOrEmpty(plantGroup) || plantGroup.Equals(plant.PlantGroup, StringComparison.OrdinalIgnoreCase);
      bool isDurationMatch = string.IsNullOrEmpty(duration) || duration.Equals(plant.Duration, StringComparison.OrdinalIgnoreCase);

      // will return if all parameters are met
      return isNativeStatusMatch && isGrowthHabitMatch && isPlantGroupMatch && isDurationMatch;
  }

}
  


