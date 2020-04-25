using Microsoft.VisualStudio.TestTools.UnitTesting;
using VigenereCipher.WPF.Models.Cipher;

namespace VigenereCipher.WPF.Test
{
    [TestClass]
    public class CipherTest
    {
        [TestMethod]
        public void DecryptTest()
        {
            string encryptedText = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";
            string decryptionKey = "скорпион";

            string expectedDecryptedText = "поздравляю, ты получил исходный текст!!!";

            string recievedDecryptedText = Cipher.Decrypt(encryptedText, decryptionKey);

            Assert.AreEqual(expectedDecryptedText, recievedDecryptedText);
        }

        [TestMethod]
        public void EncryptTest()
        {
            string decryptedText = "поздравляю, ты получил исходный текст!!!";
            string decryptionKey = "скорпион";

            string expectedEncryptedText = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";

            string recievedEncryptedText = Cipher.Encrypt(decryptedText, decryptionKey);

            Assert.AreEqual(expectedEncryptedText, recievedEncryptedText);
        }

        [TestMethod]
        public void DecryptTestWithUppercase()
        {
            string encryptedText = "Гкзвиок, FirstLineSoftware! Сжмыснйхл, ЩААЯЕТЙ!";
            string decryptionKey = "сызрань";

            string expectedDecryptedText = "Спасибо, FirstLineSoftware! Александр, СПАСИБО!";

            string recievedDecryptedText = Cipher.Decrypt(encryptedText, decryptionKey);

            Assert.AreEqual(expectedDecryptedText, recievedDecryptedText);
        }

        [TestMethod]
        public void EnryptTestWithUppercase()
        {
            string decryptedText = "Спасибо, FirstLineSoftware! Александр, СПАСИБО!";
            string decryptionKey = "сызрань";

            string expectedEncryptedText = "Гкзвиок, FirstLineSoftware! Сжмыснйхл, ЩААЯЕТЙ!";

            string recievedEncryptedText = Cipher.Encrypt(decryptedText, decryptionKey);

            Assert.AreEqual(expectedEncryptedText, recievedEncryptedText);
        }

        [TestMethod]
        public void DecryptTestWithEmptyString()
        {
            string encryptedText = "";
            string decryptionKey = "мирамистин";

            string expectedDecryptedText = "";

            string recievedDecryptedText = Cipher.Decrypt(encryptedText, decryptionKey);

            Assert.AreEqual(expectedDecryptedText, recievedDecryptedText);
        }

        [TestMethod]
        public void EnryptTestWitEmptyString()
        {
            string decryptedText = "";
            string decryptionKey = "сызрань";

            string expectedEncryptedText = "";

            string recievedEncryptedText = Cipher.Encrypt(decryptedText, decryptionKey);

            Assert.AreEqual(expectedEncryptedText, recievedEncryptedText);
        }

        [TestMethod]
        public void DecryptTestWithSymbols()
        {
            string encryptedText = "!\"№;%:?*()_+,./|~`-№@$%^&";
            string decryptionKey = "яхта";

            string expectedDecryptedText = "!\"№;%:?*()_+,./|~`-№@$%^&";

            string recievedDecryptedText = Cipher.Decrypt(encryptedText, decryptionKey);

            Assert.AreEqual(expectedDecryptedText, recievedDecryptedText);
        }

        [TestMethod]
        public void EnryptTestWitSymbols()
        {
            string decryptedText = "!\"№;%:?*()_+,./|~`-№@$%^&";
            string decryptionKey = "море";

            string expectedEncryptedText = "!\"№;%:?*()_+,./|~`-№@$%^&";

            string recievedEncryptedText = Cipher.Encrypt(decryptedText, decryptionKey);

            Assert.AreEqual(expectedEncryptedText, recievedEncryptedText);
        }

        [TestMethod]
        public void DecryptTestWithOneSymKey()
        {
            string encryptedText = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";
            string decryptionKey = "а";

            string expectedDecryptedText = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";

            string recievedDecryptedText = Cipher.Decrypt(encryptedText, decryptionKey);

            Assert.AreEqual(expectedDecryptedText, recievedDecryptedText);
        }

        [TestMethod]
        public void EncryptTestWithOneSymKey()
        {
            string decryptedText = "поздравляю, ты получил исходный текст!!!";
            string decryptionKey = "а";

            string expectedEncryptedText = "поздравляю, ты получил исходный текст!!!";

            string recievedEncryptedText = Cipher.Encrypt(decryptedText, decryptionKey);

            Assert.AreEqual(expectedEncryptedText, recievedEncryptedText);
        }
    }
}
