namespace Organic_Devolution;

public class CommandInterpreter
{
    public static void Interpret(string command, Character currentCharacter, Room currentRoom,
        Interactable currentInteratable)
    {
        List<Item> items = currentCharacter.Items;


        List<Interactable> interactables = new List<Interactable>();


        List<Passage> passages = currentRoom.Passages;


        foreach (Item item in items)
        {
            item.Name = item.Name.ToLower();
        }


        //interactables.AddRange(currentInteratable.Interactables); // don't remember why i did this

        foreach (Interactable interactable in currentRoom.Interactables)
        {
            interactable.Name = interactable.Name.ToLower();
        }

        foreach (Passage passage in passages)
        {
            passage.Name = passage.Name.ToLower();
        }


        String[] splitCommandtemp = command.Split(" ");

        String[] splitCommand = new String[splitCommandtemp.Length];

        for (int i = 0; i < splitCommandtemp.Length; i++)
        {
            splitCommand[i] = splitCommandtemp[i].ToLower();
        }

        splitCommandtemp = splitCommand;

        for (int i = 0; i < splitCommandtemp.Length; i++)
        {
            splitCommand[i] = splitCommandtemp[i].Replace(" ", "");
        }


        if (splitCommand.Length > 5)
        {
            Console.WriteLine("Too many words");
        }

        if (splitCommand.Length < 1)
        {
            Console.WriteLine("Too few words");
        }

        //for debugging
        /*
        foreach (string word in splitCommand)
        {
            Console.WriteLine("word: \"" + word + "\"");
        }
        */


        //examine
        if (splitCommand[0] == "examine" | splitCommand[0] == "look")
        {
            if (splitCommand.Length == 1)
            {
                Console.WriteLine(currentRoom.Description);

                Console.WriteLine("You can see:");

                foreach (Interactable interactable in interactables)
                {
                    Console.WriteLine(interactable.Name);
                }

                foreach (Character character in currentRoom.Characters)
                {
                    Console.WriteLine(character.Name);
                }
            }

            if (splitCommand.Length == 2)
            {
                if (splitCommand[1] == "room")
                {
                    Console.WriteLine(currentRoom.Description);
                    return;
                }

                foreach (Interactable interactable in interactables)
                {
                    if (interactable.Name == splitCommand[1])
                    {
                        GameHandler.displayText(interactable.Description);
                        currentInteratable = interactable;
                        return;
                    }
                }
            }
        }
        //take
        else if (splitCommand[0] == "take")
        {
            if (splitCommand.Length == 2)
            {
                foreach (Interactable interactable in interactables)
                {
                    if (interactable.Name == splitCommand[1])
                    {
                        if (interactable.IsPickupable)
                        {
                            currentCharacter.Items.Add(new Item(interactable.Name, interactable.Description));
                            interactables.Remove(interactable);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("You can't take that");
                            return;
                        }
                    }
                }
            }
        }

        //use
        else if (splitCommand[0] == "use")
        {
            if (splitCommand.Length == 2)
            {
                foreach (Item item in items)
                {
                    if (item.Name == splitCommand[1])
                    {
                        Console.WriteLine("You use the " + item.Name); //create logic to use single items
                        return;
                    }
                }
            }

            if (splitCommand.Length == 3)
            {
                foreach (Item item in items)
                {
                    if (item.Name == splitCommand[1])
                    {
                        foreach (Item item2 in items)
                        {
                            if (item2.Name == splitCommand[2])
                            {
                                Console.WriteLine("You use the " + item.Name + " on the " +
                                                  item2.Name); //create logic to use two items

                                return;
                            }
                        }
                    }
                }
            }
        }

        else if (splitCommand[0].ToLower() == "go" || splitCommand[0].ToLower() == "walk")
        {
            if (splitCommand.Length >= 2)
            {
                if (splitCommand.Length == 3)
                {
                    splitCommand[1] = splitCommand[1] + " " + splitCommand[2];
                }

                if (splitCommand[1] == "where")
                {
                    Console.WriteLine("You can go:");
                    foreach (Passage passage in currentRoom.Passages)
                    {
                        Console.WriteLine(passage.Name);
                    }

                    return;
                }

                foreach (Passage passage in currentRoom.Passages)
                {
                    if (passage.Name == splitCommand[1] || passage.ToRoom == splitCommand[1])
                    {
                        if (passage.SSLKey == null)
                        {
                            GameHandler.LoadRoom(passage.ToRoom);
                            return;
                        }
                        else
                        {
                            foreach (SSLKeyPair sslKeyPair in GameHandler.SSLKeyPairs)
                            {
                                if (sslKeyPair.PublicKey == passage.SSLKey)
                                {
                                    GameHandler.LoadRoom(passage.ToRoom);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("You don't have the SSL key for that door");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That passage doesn't exist");
                        return;
                    }
                }
            }
        }
        else if (splitCommand[0].ToLower() == "loot")
        {
            
            if (splitCommand.Length == 1)
            {
                Console.WriteLine("Loot what?");
                return;
            }
            
            if (splitCommand.Length == 3)
            {
                splitCommand[1] = splitCommand[1] + " " + splitCommand[2];
            }
            
            
                foreach (Interactable interactable in interactables)
                {
                    if (interactable.Name == splitCommand[1])
                    {
                        foreach (Interactable interactable2 in interactable.Interactables)
                        {
                            if (interactable2.IsPickupable)
                            {
                                currentCharacter.Items.Add(new Item(interactable2.Name, interactable2.Description));
                                currentRoom.Interactables.Remove(interactable2); // may cause errors
                                return;
                            }

                            {
                                Console.WriteLine("You can't loot that");
                                return;
                            }


                            return;
                        }
                    }
                }

                foreach (Character character in currentRoom.Characters)
                {
                    if (character.Name.ToLower() == splitCommand[1])
                    {
                        if (character.IsAlive)
                        {
                            Console.WriteLine("You can't loot alive people"); // initiates combat
                            return;
                        }

                        if (!character.Items.Any() && !character.SSLKeys.Any())
                        {
                            Console.WriteLine("you find nothing of interest");
                            return;
                        }


                        foreach (Item item in character.Items)
                        {
                            currentCharacter.Items.Add(item);
                            Console.WriteLine("You loot the " + item.Name);
                        }

                        foreach (SSLKey sslKey in character.SSLKeys) //should probably belong to the pdas
                        {
                            currentCharacter.SSLKeys.Add(sslKey);
                            Console.WriteLine("You download the " + sslKey.Name);
                        }


                        character.Items.Clear();
                        character.SSLKeys.Clear();
                        return;
                    }
                }
            
        
    

    Console.WriteLine("You can't loot that");
                return;
            }
        
    else

    {
        Console.WriteLine("That command doesn't exist");
    }

    // new command
}

}