namespace Organic_Devolution;

public class Room
{
    
    public string Name { get; set; }
    
    public string FirstTimeDescription { get; set; }
    
    public string Description { get; set; }
    
    public List<Character> Characters { get; set; }
    
    public List<Interactable> Interactables { get; set; }

    public List<Passage> Passages { get; set; }

// for json deserialize
    public Room()
    {
        
    }
    
    public Room(string name, string description, string firstTimeDescription, List<Character> characters, List<Interactable> interactables, List<Passage> passages)
    {
        Name = name;
        FirstTimeDescription = firstTimeDescription;
        Description = description;
        Characters = characters;
        Interactables = interactables;
        Passages = passages;
    }
    
    
    public Room(string name, string description, List<Character> characters, List<Interactable> interactables, List<Passage> passages)
    {
        Name = name;
        FirstTimeDescription = description;
        Description = description;
        Characters = characters;
        Interactables = interactables;
        Passages = passages;
    }
    
    
    public Room(string name, string description, string firstTimeDescription)
    {
        Name = name;
        Description = description;
        FirstTimeDescription = firstTimeDescription;
        
        Characters = new List<Character>();
        Interactables = new List<Interactable>();
        Passages = new List<Passage>();
        

    }
    
    public Room(string name, string description)
    {
        Name = name;
        FirstTimeDescription = description;
        
        Characters = new List<Character>();
        Interactables = new List<Interactable>();
        Passages = new List<Passage>();

    }
    
    
}