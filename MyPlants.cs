using System;
using System.Collections.Generic;

public class MyPlants
{
    public int UserId { get; set; }
    public List<Plant> Plants { get; set; }

    public MyPlants(int userId)
    {
        UserId = userId;
        Plants = GetMyPlants();
    }

    public List<Plant> GetMyPlants()
    {
        PlantDAO plantDAO = new PlantDAO();
        List<Plant> userPlantIds = plantDAO.GetPlantsByUserId(this.UserId);
        List<Plant> userPlants = new List<Plant>();
        foreach (Plant plant in userPlantIds)
        {
            userPlants.Add(plantDAO.GetPlantById(plant.Id));
        }

        return userPlants;
    }

    public void AddPlant(Plant plant)
    {
        PlantDAO userPlantDAO = new PlantDAO();
        userPlantDAO.AddUserPlant(plant, UserId);
        Plants.Add(plant);
    }

    public void RemovePlant(int plantId)
    {
        Plant plantToRemove = Plants.Find(p => p.Id == plantId);
        if (plantToRemove != null)
        {
            Plants.Remove(plantToRemove);

            PlantDAO plantDAO = new PlantDAO();
            plantDAO.RemoveUserPlant(plantId, UserId);
        }
        else
        {
            Console.WriteLine($"Plant with PlantId {plantId} not found in MyPlants.");
        }
    }
}
