using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.IO;

namespace webservice3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // These are global values that is used for encryption and these values can be changed.
        static readonly string HASHKEY = "P@@Sw0rd";
        static readonly string KEYsaltvalue = "S@LT&KEY";
        static readonly string KEYVIvalue = "@1B2c3D4e5F6g7H8";

        //this function is used for the purpose of encryting a given string.
        public string Encrypt(string plainText)
        {
            // First we are converting the given string into byte formatting
            byte[] BytesofText = Encoding.UTF8.GetBytes(plainText);

            //We converting the Hashkey into bytes.
            byte[] keybytz = new Rfc2898DeriveBytes(HASHKEY, Encoding.ASCII.GetBytes(KEYsaltvalue)).GetBytes(256 / 8);
            var symmetricKyaval = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKyaval.CreateEncryptor(keybytz, Encoding.ASCII.GetBytes(KEYVIvalue));

            byte[] TextBytesofcypher;

            // Then we creating the necessary streams and then using the given keys we are encoding the string.
            using (var memStr = new MemoryStream())
            {
                using (var cryptoStr = new CryptoStream(memStr, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStr.Write(BytesofText, 0, BytesofText.Length);
                    cryptoStr.FlushFinalBlock();
                    TextBytesofcypher = memStr.ToArray();
                    // After the processing is done we are closing the stream that where opened for processing.
                    cryptoStr.Close();
                }
                memStr.Close();
            }
            string str = Convert.ToBase64String(TextBytesofcypher);

            return str;
        }

        // This function is used for Decryptyphyng the encrypted string.
        public string Decrypt(string givenstr)
        {
            // As similar to the encryption we are converting into bytes the necessary encryption key values.
            byte[] TextBytesofcypher = Convert.FromBase64String(givenstr);
            byte[] keyBytz = new Rfc2898DeriveBytes(HASHKEY, Encoding.ASCII.GetBytes(KEYsaltvalue)).GetBytes(256 / 8);
            var symmKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            // Then we creating the neccesarry stream for bytes processing.
            var decryp = symmKey.CreateDecryptor(keyBytz, Encoding.ASCII.GetBytes(KEYVIvalue));
            var memstr = new MemoryStream(TextBytesofcypher);
            var crypstr = new CryptoStream(memstr, decryp, CryptoStreamMode.Read);
            byte[] BytesOftxt = new byte[TextBytesofcypher.Length];

            int decrypbyte = crypstr.Read(BytesOftxt, 0, BytesOftxt.Length);
            //we are closing the opened steam.
            memstr.Close();
            crypstr.Close();
            //returning the decoded value in a string format.
            string str = Encoding.UTF8.GetString(BytesOftxt, 0, decrypbyte).TrimEnd("\0".ToCharArray());
            return str;
        }
    }
}
