using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.PasswordHashingUtils;

namespace lab3
{
    [TestClass]
    public class PasswordHashingUtilsTest
    {
        [TestMethod]
        public void TestInitSameToGetHashResults()
        {
            string password = "abcdefgh";
            string salt = "hgfedcba";
            uint adlerMod32 = 13;
            PasswordHasher.Init(salt, adlerMod32);
            string initResult = PasswordHasher.GetHash(password);
            string getHashResult = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.AreEqual(initResult, getHashResult);
        }
        // Init and GetHash return the same result, so we can test Init variant of execution with GetHash 
        [TestMethod]
        public void TestInitValidInput()
        {
            string password = "abcdefgh";
            string salt = "hgfedcba";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestInitOverflowException()
        {
            string password = "abcdefgh";
            string salt = "абвгдеёж";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestInitEmptySalt()
        {
            string password = "abcdefgh";
            string salt = "";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestInitNullSalt()
        {
            string password = "abcdefgh";
            string salt = null;
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestInitEmptySaltZeroAdlerMod32()
        {
            string password = "abcdefgh";
            string salt = "";
            uint adlerMod32 = 0;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestInitNullSaltZeroAdlerMod32()
        {
            string password = "abcdefgh";
            string salt = null;
            uint adlerMod32 = 0;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetHashValidInput()
        {
            string password = "abcdefgh";
            string salt = "hgfedcba";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetHashPasswordNull()
        {
            string password = null;
            string salt = "hgfedcba";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestGetHashOverflowException()
        {
            string password = "abcdefgh";
            string salt = "абвгдеёж";
            uint adlerMod32 = 13;
            string result = PasswordHasher.GetHash(password, salt, adlerMod32);
            Assert.IsNotNull(result);
        }
    }
}
