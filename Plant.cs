using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Plant
{
    private int id;
    private string name;
    private string type;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Plant()
    {
        // Default constructor
    }

    public Plant(int id, string name, string type)
    {
        Id = id;
        Name = name;
        Type = type;
    }
}
