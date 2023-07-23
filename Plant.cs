public class Plant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string PlantGroup { get; set; }
    public string Duration { get; set; }
    public string GrowthHabit { get; set; }
    public string NativeStatus { get; set; }

    public Plant()
    {
        // Default constructor
    }

    public Plant(int id, string name, string symbol, string plantGroup, string duration, string growthHabit, string nativeStatus)
    {
        Id = id;
        Name = name;
        Symbol = symbol;
        PlantGroup = plantGroup;
        Duration = duration;
        GrowthHabit = growthHabit;
        NativeStatus = nativeStatus;
    }
}
