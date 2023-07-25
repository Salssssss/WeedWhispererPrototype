using System;

public class WaterSchedule
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlantId { get; set; }
    public DateTime WateringDate { get; set; }

    public WaterSchedule(int scheduleId, int userId, int plantId, DateTime wateringDate)
    {
        Id = scheduleId;
        UserId = userId;
        PlantId = plantId;
        WateringDate = wateringDate.Date;
    }
    public WaterSchedule(int userId, int plantId, DateTime wateringDate)
    {
        UserId = userId;
        PlantId = plantId;
        WateringDate = wateringDate.Date;
    }

    public void SaveWateringSchedule()
    {
        ScheduleDAO scheduleDAO = new ScheduleDAO();
        scheduleDAO.AddWaterSchedule(this);
    }

    public void AlertUserIfWateringDayHasArrived()
    {
        // Get the current date and time
        DateTime currentDate = DateTime.Now;

        // Check if the watering date has arrived
        if (currentDate.Date >= WateringDate.Date)
        {
            // Send an alert to the user (however we do that)
            Console.WriteLine($"Alert: Today is the watering day for PlantId {PlantId}!");

            ScheduleDAO scheduleDAO = new ScheduleDAO();
            scheduleDAO.RemoveWaterSchedule(Id);
        }
    }
}
