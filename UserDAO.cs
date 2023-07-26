
using System;
using System.Data;
using System.Data.SqlClient;

public class UserDAO
{
    private readonly string connectionString;

    public UserDAO()
    {
        this.connectionString = "Server=tcp:weedwhisperer.database.windows.net,1433;Initial Catalog=weedwhisperer;Persist Security Info=False;User ID=weeder;Password=Whisper123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public User GetUserById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                User user = new User
                {
                    id = (int)reader["Id"],
                    Username = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                };

                return user;
            }

            return null;
        }

    }

    public User GetUserByEmail(string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                User user = new User
                {
                    id = (int)reader["Id"],
                    Username = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                };

                return user;
            }

            return null;
        }
    }

    public void AddUser(User user)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Manually generate a unique ID for the new user
                user.id = GenerateUniqueUserId();

                string query = "INSERT INTO Users (Id, Name, Email, Password) VALUES (@Id, @Name, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", user.id);
                command.Parameters.AddWithValue("@Name", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void UpdateUser(User user)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Id", user.id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteUser(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    private int GenerateUniqueUserId()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT MAX(Id) FROM Users"; // Get the maximum existing user ID
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

