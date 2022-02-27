using System;
using System.Security.Cryptography;
using System.Linq;
//using Microsoft.Owin.Security.DataHandler.Encoder;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            var key2 = new byte[64];
            RNGCryptoServiceProvider.Create().GetBytes(key2);
            var base64Secret = Convert.ToBase64String(key2);
            // make safe for url
            var urlEncoded = base64Secret.TrimEnd('=').Replace('+', '-').Replace('/', '_');

            Console.WriteLine($"key = { key2.ToString() }");
            Console.WriteLine($"base64Secret = { base64Secret.ToString() }");
            Console.WriteLine($"urlEncoded   = { urlEncoded.ToString() }");

            // urlEncoded.Dump();

            var key = new byte[64];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            //var base64Secret1 = TextEncodings.Base64Url.Encode(key);
            //Console.WriteLine($"base64Secret1 = { base64Secret1 }");

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
