// See https://aka.ms/new-console-template for more information


using System.Drawing;
using System.Text.Json;
using Organic_Devolution;
using Pastel;



CreateRoomsJson createRoomsJson = new CreateRoomsJson();

GameHandler.SSLKeyPairs = SSLKeyGenerator.GenerateKeyPairs(10); // not OOP

createRoomsJson.InitializeRooms();

bool showIntro = true;

if (showIntro)
{

 String taag1 = @"
   ___                       _      
  /___\_ __ __ _  __ _ _ __ (_) ___ 
 //  // '__/ _` |/ _` | '_ \| |/ __|
/ \_//| | | (_| | (_| | | | | | (__ 
\___/ |_|  \__, |\__,_|_| |_|_|\___|
           |___/                    ";

 String taag2 = @"    ___                _       _   _             
   /   \_____   _____ | |_   _| |_(_) ___  _ __  
  / /\ / _ \ \ / / _ \| | | | | __| |/ _ \| '_ \ 
 / /_//  __/\ V / (_) | | |_| | |_| | (_) | | | |
/___,' \___| \_/ \___/|_|\__,_|\__|_|\___/|_| |_|
                                                 
";

 Console.WriteLine(taag1.Pastel(Color.Firebrick));
 Console.WriteLine(taag2.Pastel(Color.Firebrick));




 Console.ReadKey(true);

 Console.Clear();

 string introduction = File.ReadAllText(@"../../../\introduction.txt");

 GameHandler.displayTextContainingGold(introduction);

}

GameHandler.LoadRoom("stasis room");

Console.WriteLine("TERMINATING".Pastel(Color.Firebrick));