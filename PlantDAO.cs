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
            string query = "SELECT Id, Name, Type FROM Plants";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Plant plant = new Plant
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Type = (string)reader["Type"]
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
            string query = "SELECT Id, Name, Type FROM Plants WHERE Id = @Id";
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
                    Type = (string)reader["Type"]
                };

                return plant;
            }

            return null;
        }
    }
}
