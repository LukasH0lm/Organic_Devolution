using System.Text.Json;

namespace Organic_Devolution;

public class RoomJsonHandler
{
    public static void saveRoom(Room room)
    {
        
        string path = @"../../../\Rooms\" ;

        
        string fileName = path + room.Name + ".json";; 
        string jsonString = JsonSerializer.Serialize(room);
        File.WriteAllText(fileName, jsonString);
        
        
    }

    public static Room loadRoom(string roomName)
    {
        string path = @"../../../\Rooms\" ;
        
        string file = path + roomName + ".json";
        
        string json = File.ReadAllText(file);
        
        Room? room = JsonSerializer.Deserialize<Room>(json);

        if (room != null)
        {
            return room;
        }
        else
        {
            throw new Exception("Room not found");
            
        }
        
    }
}