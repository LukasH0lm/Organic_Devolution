namespace Organic_Devolution;

public class Interactable
{
    
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Interactable> Interactables { get; set; }

    public bool IsPickupable { get; set; }
    
    public List<int> InteractableItemIds { get; set; }
    
    
    
    
    public Interactable (string name, string description, List<Interactable> interactables, List<int> interactableItemIds, bool isPickupable)
    {
        Name = name;
        Description = description;
        Interactables = interactables;
        InteractableItemIds = interactableItemIds;
        IsPickupable = isPickupable;
    }
    
    public Interactable (string name, string description, List<Interactable> interactables, int interactableItemId, bool isPickupable)
    {
        Name = name;
        Description = description;
        Interactables = interactables;
        InteractableItemIds = new List<int>() {interactableItemId};
        IsPickupable = isPickupable;
    }
    
    public Interactable (string name, string description, List<Interactable> interactables)
    {
        Name = name;
        Description = description;
        Interactables = interactables;
        InteractableItemIds = new List<int>();
        IsPickupable = false;
    }
    
    
    public Interactable (string name, string description)
    {
        Name = name;
        Description = description;
        Interactables = new List<Interactable>();
        InteractableItemIds = new List<int>();
        IsPickupable = false;
    }

    public Interactable()// for json deserialize
    {
        
    }


    public void unlock()
    {
        
    }
    
    public virtual void Interact()
    {
        Console.WriteLine(Description);
        
    }
    
    
}