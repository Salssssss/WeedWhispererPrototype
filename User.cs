public class User
{

    private string username;
    private string email;
    private string password;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public User()
    {
        // Default constructor
    }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}
