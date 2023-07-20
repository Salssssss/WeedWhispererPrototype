using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserDAO
{
    private readonly string connectionString;

    public UserDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public User GetUserById(int id)
    {
        
    }

    public User GetUserByEmail(string email)
    {
       
    }

    public void AddUser(User user)
    {
        
    }

    public void UpdateUser(User user)
    {
        
    }

    public void DeleteUser(int id)
    {
        
    }
}
