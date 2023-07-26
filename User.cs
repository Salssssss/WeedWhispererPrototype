public class User
{

    private string username;
    private string email;
    private string password;
    private int Id;
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
    public int id
    {
        get { return Id; }
        set { Id = value; }
    }

    public User()
    {
        // Default constructor
    }

    public User(int Id,  string username, string email, string password)
    {
        this.Id = Id;
        Username = username;
        Email = email;
        Password = password;
    }
}
