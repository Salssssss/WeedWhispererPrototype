using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
public class UserVerifier
{

    public bool VerifyUserCredentials(string email, string password)
    {
        UserDAO verify_user = new UserDAO();
        User user = verify_user.GetUserByEmail(email);

        if (user != null && email == user.Email && password == user.Password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}