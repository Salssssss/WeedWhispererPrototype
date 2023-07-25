using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MyPlants
{
    public List<Plant> Plants { get; set; }

    public MyPlants()
    {
        Plants = new List<Plant>();
    }

    public void AddPlant(Plant plant)
    {
        // Add plant to the list
        if (!string.IsNullOrWhiteSpace(plant))
        {
            Plants.add(plant);
            Console.WriteLine(plant + " has been added to your list of plants!");
        }
        else
        {
            Console.WriteLine("Plant name cannot be empty, please add the name of your plant.");
        }   
            
    }

    public void RemovePlant(Plant plant)
    {
        // Remove plant from the list
        if (Plants.contains(plant))
        {
            Plant.remove(plant);
            Console.WriteLine(plant + " has been removed from your plnats.");
        }
        else
        {
            Console.WriteLine("Plant not found.");
        }
        
    }

    public List<Plant> GetPlants()
    {
        // Return the list of plants
        if (Plants.count > 0)
        {
            return Plants;
        }
        else
        {
            Console.WriteLine("Your list is empty.");
        }
        
    }
}
