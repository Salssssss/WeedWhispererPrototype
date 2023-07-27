using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
public class UserVerifier
{
    private readonly UserDAO userDAO;

    public UserVerifier(){
        this.userDAO = new UserDAO();
    }
    
    public bool VerifyUserCredentials(string email, string password)
    {
        try{

            User user = verify_user.GetUserByEmail(email);

            if (user != null && email == user.Email && password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                return false;
        }
    }

}
