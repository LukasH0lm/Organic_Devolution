namespace Organic_Devolution;

public class PDA : Interactable
{
    
    public SSLKey Key { get; set; }
    public Character Owner { get; set; }
    
    
    public PDA(SSLKey key, Character owner)
    {
        Key = key;
        Owner = owner;
    }
    
    public PDA()
    {
        
        
    }


  

    public SSLKey Interact()
    {
        return Key;
    }
    
    
}