using System.Security.Cryptography;
using System.Text;

namespace Honamic.SepidarApi.Helper;
static class CryptoHelper
{
    public static AesEncryptionResult AesEncrypt(string key, string plainText)
    {
        var keyBytes = Encoding.ASCII.GetBytes(key);

        string iv;
        string cipher;

        using (var aes = Aes.Create())
        {
            aes.Mode = CipherMode.CBC;
            aes.Key = keyBytes;
            aes.GenerateIV();
            iv = Convert.ToBase64String(aes.IV);

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted;

            // Create the streams used for encryption.
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            cipher = Convert.ToBase64String(encrypted);
        }

        return new AesEncryptionResult(iv, cipher);
    }

    public static string AesDecrypt(string key, string cipher, string iv)
    {
        var keyBytes = Encoding.ASCII.GetBytes(key);
        var cipherBytes = Convert.FromBase64String(cipher);
        var ivBytes = Convert.FromBase64String(iv);

        string plaintext;
        using (var aes = Aes.Create())
        {
            aes.Mode = CipherMode.CBC;
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (var msDecrypt = new MemoryStream(cipherBytes))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }

    public static string RsaEncrypt(string publicKey, byte[] plainText)
    {
        if (BitConverter.IsLittleEndian)
        {
            // fix endianness https://stackoverflow.com/a/10191075/317212
            Swap(plainText, 0, 3);
            Swap(plainText, 1, 2);
            Swap(plainText, 4, 5);
            Swap(plainText, 6, 7);
        }

        try
        {
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                encryptedData = rsa.Encrypt(plainText, false);
            }
            return Convert.ToBase64String(encryptedData);
        }
        //Catch and display a CryptographicException  
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return null;
        }
    }

    private static void Swap(byte[] buffer, int idx1, int idx2)
    {
        var c = buffer[idx1];
        buffer[idx1] = buffer[idx2];
        buffer[idx2] = c;
    }

    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

struct AesEncryptionResult
{
    public string IV { get; }
    public string Cipher { get; }

    public AesEncryptionResult(string iv, string cipher)
    {
        IV = iv;
        Cipher = cipher;
    }
}