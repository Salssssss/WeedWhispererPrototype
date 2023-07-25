using System.Collections.Generic;

public class MyPlants
{
    public int UserId { get; set; }
    public List<Plant> Plants { get; set; }

    public MyPlants(int userId)
    {
        UserId = userId;
        Plants = new List<Plant>();
    }
    public MyPlants GetPlantsByUserId(int userId)
    {
        MyPlants myPlants = new MyPlants(userId);

        PlantDAO plantDAO = new PlantDAO("your_connection_string");
        List<Plant> userPlants = plantDAO.GetPlantsByUserId(userId);

        myPlants.Plants.AddRange(userPlants);

        return myPlants;
    }
}