using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Organic_Devolution;

public class SSLKeyGenerator
{
    private static int id;


    //0 discard room body -> exit room
    
    public static List<SSLKeyPair> GenerateKeyPairs(int ammountOfSSLKeys)
    {
        List<SSLKeyPair> SSLKeyPairs = new List<SSLKeyPair>();
        
        for (int i = ammountOfSSLKeys; i >= 0; i--)
        {
            SSLKeyPairs.Add(GenerateKeyPair());
        }

        return SSLKeyPairs;

    }


    public static SSLKeyPair GenerateKeyPair()
    {
        var ecdsa = ECDsa.Create(); // generate asymmetric key pair
        var req = new CertificateRequest("cn=foobar", ecdsa, HashAlgorithmName.SHA256);
        var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));

        // Create PFX (PKCS #12) with private key
        string privatekey = Convert.ToBase64String(cert.Export(X509ContentType.Pfx));

        // Create Base 64 encoded CER (public key only)
        string publickey =
            "-----BEGIN CERTIFICATE-----\r\n"
            + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
            + "\r\n-----END CERTIFICATE-----";
        
        
        SSLKey publicKey = new SSLKey(KeyType.Public, "public", publickey);
        
        SSLKey privateKey = new SSLKey(KeyType.Private, "private", privatekey);
        
        
        return new SSLKeyPair(id, publicKey, privateKey);
        
    }



}