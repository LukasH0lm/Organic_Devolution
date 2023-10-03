namespace Organic_Devolution;

public class Passage
{
    
    public string Name { get; set; }
    
    String Description { get; set; }

    public string ToRoom { get; set; }
    
    public SSLKey SSLKey { get; set; }
    
    
    public Passage() // for json deserialize
    {
        
    }
    
    public Passage(string name, string description, string toRoom, SSLKey sslKey)
    {
        Name = name;
        Description = description;
        ToRoom = toRoom;
        SSLKey = sslKey;
    }
    
    
    public Passage(string name, string description, string toRoom)
    {
        Name = name;
        Description = description;
        ToRoom = toRoom;
    }
    
    
}