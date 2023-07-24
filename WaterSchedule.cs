using System;

public class WaterSchedule
{
    public int Id { get; set; }
    public int PlantId { get; set; }
    public DateTime WateringDate { get; set; }

    public WaterSchedule()
    {
        // Default constructor
    }

    public WaterSchedule(int id, int plantId, DateTime wateringDate)
    {
        Id = id;
        PlantId = plantId;
        WateringDate = wateringDate;
    }
}
