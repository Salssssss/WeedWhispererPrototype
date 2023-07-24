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

    List<Plant> recommended =
  }
    

  

}
