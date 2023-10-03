namespace Organic_Devolution;

public class Character 
{
    public string Name { get; set; }
    
    private string Description { get; set; }
    private int Attack { get; set; } 
    private int Defense { get; set; }
    private int NetWorth { get; set; }

    NeuralImplant NeuralImplant { get; set; }
    BodyPartSet BodyPartSet { get; set; }

    public bool IsAlive { get; set; }
    
    
    public List<Item> Items { get; set; }
    
    public List<SSLKey> SSLKeys { get; set; }

    public PDA Pda;


    public Character(string name, string description, int attack, int defense, int netWorth, NeuralImplant neuralImplant, BodyPartSet bodyPartSet, List<Item> items, List<SSLKey> sSlKeys)
    {
        Name = name;
        Description = description;
        Attack = attack;
        Defense = defense;
        NetWorth = netWorth;
        NeuralImplant = neuralImplant;
        BodyPartSet = bodyPartSet;
        Items = items;
        SSLKeys = sSlKeys;
    }


    public Character(string name, string description, List<Item> items)
    {
        
        Name = name;
        Description = description;
        Attack = 10;
        Defense = 10;
        NetWorth = 0;
        
        NeuralImplant = new NeuralImplant();
        BodyPartSet = new BodyPartSet();
        
        
        Items = items;
    }
    
    public Character(string name, string description)
    {
        
        Name = name;
        Description = description;
        Attack = 10;
        Defense = 10;
        NetWorth = 0;
        
        NeuralImplant = new NeuralImplant();
        BodyPartSet = new BodyPartSet();
        
        
        Items = new List<Item>();
        
        SSLKeys = new List<SSLKey>();
        
        IsAlive = true;
        
    }
    
    public Character(string name)
    {
        
        Name = name;
        Description = "Just some random ass dude";
        Attack = 10;
        Defense = 10;
        NetWorth = 0;
        
        NeuralImplant = new NeuralImplant();
        BodyPartSet = new BodyPartSet();
        Items = new List<Item>();
        
        IsAlive = true;

    }

    public Character()
    {
        
        
        
        
    }
    
}