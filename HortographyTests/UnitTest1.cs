using Hortography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace HortographyTests
{
    [TestClass]
    public class UnitTest1
    {
        IHortography mockEnc;
        public byte[] encrypted;
        public string decrypted;
        public string cipherKey;

        [TestInitialize]
        public void TestInitialize()
        {
            mockEnc = new Hortography.Hortography();
        }

        [TestMethod]
        public void TestEncryptDecrypt()
        {
            using (Aes myAes = Aes.Create())
            {
                cipherKey = System.Guid.NewGuid().ToString();


                encrypted = mockEnc.EncryptStringtoBytes(cipherKey, myAes.Key, myAes.IV);
                decrypted = mockEnc.DecryptBytesToPlainTextString(encrypted, myAes.Key, myAes.IV);

                Assert.IsInstanceOfType(encrypted, typeof(byte[]));
                Assert.AreEqual(decrypted, cipherKey);


            }
        }
    }
}
