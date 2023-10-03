namespace Organic_Devolution;

public class BodyPart
{
    
    bodyPartType BodyPartType { get; set; }
    
    int Health { get; set; }
    
    int Evasion { get; set; }
    
    Implant? Implant { get; set; }

    
    public BodyPart (bodyPartType bodyPartType,int health, int evasion,  Implant implant)
    {
        BodyPartType = bodyPartType;
        
        Health = health;
        
        Evasion = evasion;
        
        Implant = implant;
    }
    
    public BodyPart (bodyPartType bodyPartType,int health, int evasion)
    {
        BodyPartType = bodyPartType;
        
        Health = health;
        
        Evasion = evasion;
        
    }
    
    
    
    
    
    public BodyPart() // for json deserialize
    {
        
    }
    
}