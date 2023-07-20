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
    }

    public void RemovePlant(Plant plant)
    {
        // Remove plant from the list
    }

    public List<Plant> GetPlants()
    {
        // Return the list of plants
        return Plants;
    }
}