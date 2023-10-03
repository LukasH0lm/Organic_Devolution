namespace Organic_Devolution;

public class SSLKeyPair
{
    
    int id { get; set; }
    public SSLKey PublicKey { get; set; }
    public SSLKey PrivateKey { get; set; }
    
    public SSLKeyPair(int id, SSLKey publicKey, SSLKey privateKey)
    {
        PublicKey = publicKey;
        PrivateKey = privateKey;
    }
    
}