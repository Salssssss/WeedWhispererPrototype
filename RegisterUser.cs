using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class RegisterUser
{
    private readonly UserDAO userDAO;

    public RegisterUser(UserDAO userDAO)
    {
        this.userDAO = userDAO;
    }

    public bool RegisterNewUser(string name, string email, string password)
    {
        // Check if the email is already registered
        if (userDAO.GetUserByEmail(email) != null)
        {
            return false; // Email is already registered, registration failed
        }

        // Create a new user object
        User newUser = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        // Add the new user to the database
        userDAO.AddUser(newUser);

        return true; // Registration successful
    }
}
