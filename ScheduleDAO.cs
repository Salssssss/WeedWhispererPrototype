using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ScheduleDAO
{
    private string connectionString;

    public ScheduleDAO()
    {
        this.connectionString = "Server=tcp:weedwhisperer.database.windows.net,1433;Initial Catalog=weedwhisperer;Persist Security Info=False;User ID=weeder;Password=Whisper123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public void AddWaterSchedule(WaterSchedule waterSchedule)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                waterSchedule.Id = GenerateUniqueScheduleId();
                connection.Open();

                string query = "INSERT INTO Schedule (ScheduleId, UserId, PlantId, WateringDate) " +
                               "VALUES (@ScheduleId, @UserId, @PlantId, @WateringDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleId", waterSchedule.Id);
                    command.Parameters.AddWithValue("@UserId", waterSchedule.UserId);
                    command.Parameters.AddWithValue("@PlantId", waterSchedule.PlantId);
                    command.Parameters.AddWithValue("@WateringDate", waterSchedule.WateringDate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Watering schedule added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add watering schedule.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding watering schedule: " + ex.Message);
        }
    }

    public void RemoveWaterSchedule(int scheduleId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Schedule WHERE ScheduleId = @ScheduleId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleId", scheduleId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Watering schedule with ScheduleId {scheduleId} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Watering schedule with ScheduleId {scheduleId} not found.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while removing watering schedule: " + ex.Message);
        }
    }
    public List<WaterSchedule> GetWaterSchedulesByUserId(int userId)
    {
        List<WaterSchedule> waterSchedules = new List<WaterSchedule>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ScheduleId, UserId, PlantId, WateringDate " +
                               "FROM Schedule " +
                               "WHERE UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int scheduleId = (int)reader["ScheduleId"];
                            int plantId = (int)reader["PlantId"];
                            DateTime wateringDate = (DateTime)reader["WateringDate"];

                            WaterSchedule waterSchedule = new WaterSchedule(scheduleId, userId, plantId, wateringDate);
                            waterSchedules.Add(waterSchedule);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while fetching watering schedules: " + ex.Message);
        }

        return waterSchedules;
    }
    private int GenerateUniqueScheduleId()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT MAX(ScheduleId) FROM Schedule";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            object result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                // If the table is empty, start with ID 1
                return 1;
            }
            else
            {
                // Otherwise, generate the next unique ID
                int maxId = Convert.ToInt32(result);
                return maxId + 1;
            }
        }
    }
}
