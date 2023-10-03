using System.Text.Json;

namespace Organic_Devolution;

public class CreateRoomsJson
{

    bool debug = false;
    
    public void InitializeRooms()
    {
        
        

        List<Room> rooms = new List<Room>();

        Room stasis = CreateStasisRoom();
        rooms.Add(stasis);
        
        Room Stasis_hallway = CreateStasisChamberHallway();
        rooms.Add(Stasis_hallway);
        
        Room Discard_room = CreateDiscardRoom();
        rooms.Add(Discard_room);

        saveRoomsToJson(rooms);
    }


    public void saveRoomsToJson(List<Room> rooms)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true // don't know wtf this does
        };

        foreach (Room room in rooms)
        {
            string jsonString = JsonSerializer.Serialize(room, options);

            if (debug)
            {

                Console.WriteLine(room.Name);

                Console.WriteLine(room.Passages[0].Name); // every room should have atleast one passage

                Console.WriteLine(jsonString);
            }

            RoomJsonHandler.saveRoom(room);
            
        }
    }


    public Room exampleRoom()
    {
        Room example = new Room(
            "example room",
            @"example room description",
            "example room first time description" //optional
        );


        Interactable exampleInteractable = new Interactable(
            "example interactable",
            "example interactable description",
            new List<Interactable>()
            
        );

        Interactable interactableInInteractableExample = new Interactable(
            "example interactable in interactable",
            "example interactable in interactable description"
            
            
        );

        example.Interactables.Add(exampleInteractable);
        exampleInteractable.Interactables[0].Interactables.Add(interactableInInteractableExample); //bit confusing


        Passage door = new Passage(
            "example passage",
            @"passage description",
            "toRoom example"
            , new SSLKey(KeyType.Public,"example", "-1") //locked, if the room is unlocked, no sslkey is needed
        );

        example.Passages.Add(door);

        Character exampleCharacter = new Character(
            "example character",
            "example character description"
        );
        
        example.Characters.Add(exampleCharacter);

        
        Character exampleDeadCharacter = new Character(
            "example dead character",
            "example dead character description"
        );
        
        exampleDeadCharacter.IsAlive = false;
        exampleCharacter.Pda = new PDA(
            GameHandler.SSLKeyPairs[-1].PrivateKey,
            exampleDeadCharacter
        );
        
        example.Characters.Add(exampleDeadCharacter);

        

        return example;
    }


    public Room CreateStasisRoom()
    {
        Interactable stasisTank = new Interactable(
            "stasis Tank",
            @"
Before you stands a shattered glass chamber, its frame constructed from gleaming metal. 
Fragments of the once-clear glass litter the floor around it. 
The remnants of a strange, pale fluid have pooled on the sterile surface. 
Thin, severed tubes and wires hang from the edges, and the chamber seems to have been designed for some unknown purpose. 
Its function remains a mystery in your hazy understanding of this unfamiliar world.
"
            
        );

        Passage door = new Passage(
            "metal door",
            @"The metal door is a plain and utilitarian feature within the laboratory.

", "Stasis Chamber Hallway"
            
        );

        Room stasis = new Room(
            "Stasis room",
            @"

In the center of the room, the shattered stasis chamber stands as a silent sentinel of the room's purpose.
The broken glass and the remnants of pale fluid create a stark contrast to the otherwise pristine environment.
At one end of the laboratory, a single metal door stands as the sole means of entry or exit.
It appears unremarkable, save for a small electronic panel next to it.
The room feels devoid of life, and the silence is punctuated only by the faint hum of machinery and your own confused thoughts.


",
            @"

The laboratory is a sterile and imposing space. Cold, gray metal surfaces stretch in all directions, illuminated by the harsh glow of overhead fluorescent lights. Shelves and cabinets line the walls, holding mysterious, esoteric equipment and vials of unknown substances.;
In the center of the room, the shattered stasis chamber stands as a silent sentinel of the room's purpose. The broken glass and the remnants of pale fluid create a stark contrast to the otherwise pristine environment.;
At one end of the laboratory, a single metal door stands as the sole means of entry or exit. It appears unremarkable, save for a small electronic panel next to it, hinting at the need for authorization or a keycard.;
The room feels devoid of life, and the silence is punctuated only by the faint hum of machinery and your own confused thoughts.;


",
            new List<Character>(),
            new List<Interactable>() { stasisTank },
            new List<Passage>() { door }
        );

        return stasis;
    }

    
    //Stasis Chamber Hallway
public Room CreateStasisChamberHallway()
{
    // Create a new room object for the hallway
    Room hallway = new Room(
        "Stasis Chamber Hallway",
        "You stand in a long, featureless corridor. Dim overhead lights cast a faint, eerie glow. Rows of closed doors line both sides of the hallway.",
        "This is your first time in the hallway. It feels cold and unfamiliar."
    );

    // Create a locked stasis chamber door
    Interactable lockedChamberDoor = new Interactable(
        "Locked Stasis Chamber Door",
        "Each door along the corridor appears identical, with a small rectangular window at eye level. They are all locked and sealed."
    );

    // Add the locked stasis chamber door to the hallway
    hallway.Interactables.Add(lockedChamberDoor);

    // Create a black door labeled "Discards"
    Passage discardsDoor = new Passage(
        "Discards",
        "At one end of the corridor stands a black door with the word 'Discards' crudely written on it in white. It stands out from the rest.",
        "Discard Room"
        
    );

    // Add the discards door to the hallway
    hallway.Passages.Add(discardsDoor);

    // Create an exit door
    Passage exitDoor = new Passage(
        "Exit Door",
        "At the opposite end of the corridor, there's a door with a symbol above it that you can't quite read, but it seems significant.",
        "ExitRoom",
        GameHandler.SSLKeyPairs[0].PublicKey
        
    );

    // Add the exit door (passage) to the hallway
    hallway.Passages.Add(exitDoor);
    


    return hallway;
}





// discard room
    public Room CreateDiscardRoom()
    {
        // Create a new room object for the Discard Room
        Room discardRoom = new Room(
            "Discard Room",
            "You find yourself in a small, cramped room. Harsh, flickering fluorescent lights reveal peeling paint and rusted metal surfaces.; A large, ominous garbage chute dominates one wall, a corpse is crumpled on the floor, and a small door leads back to the hallway.",
            "This is the Discard Room, a cramped and eerie space filled with the stench of decay."
        );

        // Create an interactable garbage chute in the room
        Interactable garbageChute = new Interactable(
            "Garbage Chute",
            "A massive, dark garbage chute looms ominously on one wall. It seems big enough to dispose of something significant."
        );

        // Add the garbage chute to the room
        discardRoom.Interactables.Add(garbageChute);

        // Create a dead character on the floor
        Character deadBody = new Character(
            "Lifeless Body",
            "A lifeless body lies crumpled on the floor. Tattered clothing barely conceals its identity."
        );

        // Set the dead character's status to indicate they are not alive
        deadBody.IsAlive = false;
        
        deadBody.SSLKeys.Add(GameHandler.SSLKeyPairs[0].PublicKey);

        // Add the dead character to the room
        discardRoom.Characters.Add(deadBody);

        // Create a passage leading back to the hallway connecting rooms
        Passage hallwayExit = new Passage(
            "Hallway Door",
            "A small door on the opposite wall leads to the hallway that connects the stasis room, exit room, and discard room with a symbol above it that you can't quite read.",
            "Stasis Chamber Hallway"
        );

        // Add the passage (hallway door) to the room
        discardRoom.Passages.Add(hallwayExit);

        return discardRoom;
    }











    
}