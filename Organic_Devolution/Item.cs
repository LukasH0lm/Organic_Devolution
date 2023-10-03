namespace Organic_Devolution;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    string Description { get; set; }

    public Item(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Item() // for json deserialize
    {
    }
}