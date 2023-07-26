﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class PlantDAO
{
    private readonly string connectionString;

    public PlantDAO()
    {
        this.connectionString = "Server=tcp:weedwhisperer.database.windows.net,1433;Initial Catalog=weedwhisperer;Persist Security Info=False;User ID=weeder;Password=Whisper123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public List<Plant> GetAllPlants()
    {
        List<Plant> plants = new List<Plant>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Symbol, PlantGroup, Duration, GrowthHabit, NativeStatus FROM Plants";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Plant plant = new Plant
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Symbol = (string)reader["Symbol"],
                    PlantGroup = (string)reader["PlantGroup"],
                    Duration = (string)reader["Duration"],
                    GrowthHabit = (string)reader["GrowthHabit"],
                    NativeStatus = (string)reader["NativeStatus"]
                };

                plants.Add(plant);
            }
        }

        return plants;
    }

    public Plant GetPlantById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Symbol, PlantGroup, Duration, GrowthHabit, NativeStatus FROM Plants WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Plant plant = new Plant
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Symbol = (string)reader["Symbol"],
                    PlantGroup = (string)reader["PlantGroup"],
                    Duration = (string)reader["Duration"],
                    GrowthHabit = (string)reader["GrowthHabit"],
                    NativeStatus = (string)reader["NativeStatus"]
                };

                return plant;
            }

            return null;
        }
    }
    public List<Plant> GetPlantsByCriteria(string nativeStatus = null, string growthHabit = null, string plantGroup = null, string duration = null)
    {
        List<Plant> plants = new List<Plant>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Symbol, PlantGroup, Duration, GrowthHabit, NativeStatus FROM Plants WHERE 1=1";

            if (!string.IsNullOrEmpty(nativeStatus))
                query += " AND NativeStatus = @NativeStatus";

            if (!string.IsNullOrEmpty(growthHabit))
                query += " AND GrowthHabit = @GrowthHabit";

            if (!string.IsNullOrEmpty(plantGroup))
                query += " AND PlantGroup = @PlantGroup";

            if (!string.IsNullOrEmpty(duration))
                query += " AND Duration = @Duration";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(nativeStatus))
                command.Parameters.AddWithValue("@NativeStatus", nativeStatus);

            if (!string.IsNullOrEmpty(growthHabit))
                command.Parameters.AddWithValue("@GrowthHabit", growthHabit);

            if (!string.IsNullOrEmpty(plantGroup))
                command.Parameters.AddWithValue("@PlantGroup", plantGroup);

            if (!string.IsNullOrEmpty(duration))
                command.Parameters.AddWithValue("@Duration", duration);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Plant plant = new Plant
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Symbol = (string)reader["Symbol"],
                    PlantGroup = (string)reader["PlantGroup"],
                    Duration = (string)reader["Duration"],
                    GrowthHabit = (string)reader["GrowthHabit"],
                    NativeStatus = (string)reader["NativeStatus"]
                };

                plants.Add(plant);
            }
        }

        return plants;
    }
    public List<Plant> GetPlantsByUserId(int userId)
    {
        List<Plant> plants = new List<Plant>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT P.Id, P.Name, P.Symbol, P.PlantGroup, P.Duration, P.GrowthHabit, P.NativeStatus " +
               "FROM Plants AS P " +
               "INNER JOIN UserPlants AS UP ON P.Id = UP.PlantId " +
               "WHERE UP.UserId = @UserId";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Plant plant = new Plant
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Symbol = (string)reader["Symbol"],
                    PlantGroup = (string)reader["PlantGroup"],
                    Duration = (string)reader["Duration"],
                    GrowthHabit = (string)reader["GrowthHabit"],
                    NativeStatus = (string)reader["NativeStatus"],
                };

                plants.Add(plant);
            }
        }

        return plants;
    }
    public void AddUserPlant(Plant userPlant, int userID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO UserPlants (UserId, PlantId) VALUES (@UserId, @PlantId)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userID);
            command.Parameters.AddWithValue("@PlantId", userPlant.Id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    public void RemoveUserPlant(int plantId, int userId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM UserPlants WHERE PlantId = @PlantId AND UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlantId", plantId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Successfully removed PlantId {plantId} for UserId {userId} from UserPlants.");
                    }
                    else
                    {
                        Console.WriteLine($"PlantId {plantId} for UserId {userId} not found in UserPlants.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while removing the plant from UserPlants: " + ex.Message);
        }
    }
}
