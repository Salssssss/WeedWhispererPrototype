using System;
using System.Collections.Generic;

public class MyPlants
{
    public int UserId { get; set; }
    public List<Plant> Plants { get; set; }
    private PlantDAO plantDAO;

    public MyPlants(int userId)
    {
        UserId = userId;
        Plants = GetMyPlants();
        Plants = GetMyPlants() ?? new List<Plant>();
    }

    public List<Plant> GetMyPlants()
    {
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
        userPlantDAO.AddUserPlant(plant, UserId);
        Plants.Add(plant);
    }

    public void RemovePlant(int plantId)
    {
        Plant plantToRemove = Plants.Find(p => p.Id == plantId);
        if (plantToRemove != null)
        {
            Plants.Remove(plantToRemove);
            plantDAO.RemoveUserPlant(plantId, UserId);
        }
        else
        {
            Console.WriteLine($"Plant with PlantId {plantId} not found in MyPlants.");
        }
    }
}
