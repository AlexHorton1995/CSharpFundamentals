using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

[assembly: InternalsVisibleTo("HortographyTests")]
[assembly: InternalsVisibleTo("HelloWorld")]
namespace Hortography
{
    public interface IHortography
    {
        string EncryptionKey { get; set; }
        byte[] Hash { get; set; }
        string Hex { get; set; }

        //methods for hashing
        string ComputeHash(string plainText);

        //methods for encrypting and decrypting:
        byte[] EncryptStringtoBytes(string plainText, byte[] key, byte[] IV);
        string DecryptBytesToPlainTextString(byte[] encryptedText, byte[] key, byte[] IV);
    }

    internal sealed class Hortography : IHortography
    {
        public string EncryptionKey { get; set; }
        public byte[] Hash { get; set; }
        public string Hex { get; set; }
        internal SHA512 _hashSvc = new SHA512Managed();


        public string ComputeHash(string plainText)
        {
            var hash = _hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            string hex = BitConverter.ToString(hash).Replace("-", "");

            return hex;
        }

        public byte[] EncryptStringtoBytes(string plainText, byte[] key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncryptIt = new MemoryStream();
                using CryptoStream cStream = new CryptoStream(msEncryptIt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swWrite = new StreamWriter(cStream))
                {
                    swWrite.WriteLine(plainText);
                }
                encrypted = msEncryptIt.ToArray();
            }

            return encrypted;
        }

        public string DecryptBytesToPlainTextString(byte[] encryptedText, byte[] key, byte[] IV)
        {
            // Check arguments.
            if (encryptedText == null || encryptedText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            using (Aes aesAlg2 = Aes.Create())
            {
                aesAlg2.Key = key;
                aesAlg2.IV = IV;

                ICryptoTransform decrypter = aesAlg2.CreateDecryptor(aesAlg2.Key, aesAlg2.IV);

                using MemoryStream msDecrypt = new MemoryStream(encryptedText);
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read);
                using StreamReader srdecrypt = new StreamReader(csDecrypt);
                plaintext = srdecrypt.ReadLine();
            }

            return plaintext;

        }

    }
}
