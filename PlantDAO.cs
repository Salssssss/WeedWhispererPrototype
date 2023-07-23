using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class PlantDAO
{
    private readonly string connectionString;

    public PlantDAO(string connectionString)
    {
        this.connectionString = connectionString;
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
}
