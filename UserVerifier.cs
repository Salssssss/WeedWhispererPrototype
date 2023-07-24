using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
public class UserVerifier
{

    User user = new User();
    public bool VerifyUserCredentials(string email, string password)
    {
        // Check if the provided email and password match the user's credentials in the database
        // Return true if the credentials are valid, false otherwise
        
        if (email == user.Email && password == user.Password) { return true; }

        else { return false; }
    }
}