using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class PlantRecommendation
{
  private PlantDAO plantDAO;

  public PlantRecommendation(string connectionString)
  { 
    plantDAO = new PlantDAO(connectionString);
  }

  public List<Plant> getRecommendedPlants(string nativeStatus = null, string growthHabit = null, string plantGroup = null, string duration = null)
  {
    // list of all available plants in the database
    List<Plant> allPlants = new List<Plant>;

    //migrate plants to list
    try
    {
      allPlants= plantDAO.GetAllPlants();
    }
    catch(Exception error)
    {
      Console.WriteLine("Error migrating plant data: " + error.Message);
      
      //if error occurs return empty list
      return new List<Plant>();
    }
    
    
  }
    

  

}
