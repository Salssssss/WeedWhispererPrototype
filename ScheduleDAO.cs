using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class ScheduleDAO
{
    private readonly string connectionString;

    public ScheduleDAO()
    {
        this.connectionString = "Server=tcp:weedwhisperer.database.windows.net,1433;Initial Catalog=weedwhisperer;Persist Security Info=False;User ID=weeder;Password=Whisper123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public void AddWaterSchedule(WaterSchedule schedule)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO WaterSchedules (PlantId, WateringDate) VALUES (@PlantId, @WateringDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PlantId", schedule.PlantId);
            command.Parameters.AddWithValue("@WateringDate", schedule.WateringDate);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public List<WaterSchedule> GetWaterSchedules()
    {
        List<WaterSchedule> schedules = new List<WaterSchedule>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, PlantId, WateringDate FROM WaterSchedules";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                WaterSchedule schedule = new WaterSchedule
                {
                    Id = (int)reader["Id"],
                    PlantId = (int)reader["PlantId"],
                    WateringDate = (DateTime)reader["WateringDate"]
                };

                schedules.Add(schedule);
            }
        }

        return schedules;
    }
}
