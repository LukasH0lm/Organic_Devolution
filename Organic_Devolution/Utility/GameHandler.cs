using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Pastel;

namespace Organic_Devolution;

public class GameHandler
{

    public static Character Player { get; set; } = new Character("Player", "You are a human... at least you think so");

    public static Room CurrentRoom { get; set; } 

    public static Interactable CurrentInteractable { get; set; } 
    
    public static List<SSLKeyPair> SSLKeyPairs { get; set; }

    
    public GameHandler()
    {
        
        // this is where it should be done in production
        //but in development we generate them in program.cs
        /*
        SSLKeyGenerator sslKeyGenerator = new SSLKeyGenerator();

        for (int i = 0; i == 10; i++)
        {
           SSLKeyPairs.Add(sslKeyGenerator.GenerateKeyPair());
        }*/
        
        
    }
    
    public static void LoadRoom(string roomName)
    {
        
        Room room = RoomJsonHandler.loadRoom(roomName);
        
        CurrentRoom = room;
        
        CurrentInteractable = room.Interactables[0]; // we need to change this, currentinteractable means the character is interacting with it, they should be able to interact with multiple things at once
        
        string[] splitDescription = CurrentRoom.Description.Split(@";");
        foreach (string description in splitDescription)
        {
            Console.WriteLine(description);
            
            if (description == splitDescription[splitDescription.Length - 1])
            {
                continue;
            }
            
            Console.ReadKey();
        }
         
        
        
        commandLoop();
        
        
    }

    public static void commandLoop()
    {
        while (true)
        {
            
            string? command = Console.ReadLine();

            if (command == null || command.Trim() == "")
            {
                continue;
            }
        
            CommandInterpreter.Interpret(command, Player, CurrentRoom, CurrentInteractable);
            
            
        }
        
        
    }
    
    
    public static void displayText(string text)
    {
        
        string[] splitDescription = text.Split(@";");
        foreach (string description in splitDescription)
        {
            
            
            Console.WriteLine(description);
            
            if (description == splitDescription[splitDescription.Length - 1])
            {
                
                continue;
            }
            
            Console.ReadKey();
        }
        
        
    }
    
    public static void displayTextContainingGold(string text)
    {
        
        string[] splitDescription = text.Split(@";");
        foreach (string description in splitDescription)
        {
            
            string[] splitDescription2 = description.Split(" "); // bad way

            
            bool gold = false;
            
            foreach (string description2 in splitDescription2)
            {
                
                if (description2 == "GOLDSTART")
                {
                    gold = true;
                    continue;
                }
                if (description2 == "GOLDEND")
                {
                    gold = false;
                    continue;
                }
                
                if (gold)
                {
                    Console.Write(description2.Pastel(Color.Gold) + " ");
                }
                else
                {
                    Console.Write(description2 + " ");
                }


                
            }
            
            Console.WriteLine("\n");
            Console.ReadKey();
        }
        
        
    }
    
    
    
    
}