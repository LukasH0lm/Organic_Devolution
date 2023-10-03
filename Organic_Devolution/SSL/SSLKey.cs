namespace Organic_Devolution;

public class SSLKey
{
    
    public KeyType Type { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    
    public SSLKey() // for json deserialize
    {
        
    }
    
    public SSLKey(KeyType keyType, string name, string key)
    {
        Type = keyType;
        Name = name;
        Key = key;
    }
    
}