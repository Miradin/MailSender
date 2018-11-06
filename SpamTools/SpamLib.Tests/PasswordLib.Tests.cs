using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using PasswordLib;

namespace SpamLib.Tests
{
    [TestClass]
    public class PasswordLibTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Инициализация теста");
        }
        [TestMethod]
        public void DLLEncode_abc_bcd_key1()
        {
            // A A A
            // arrange
            var str = "abc";
            var expected = "bcd";
            var key = 1;

            //act
            var actual = PasswordLib.PasswordEncoder.Encode(str, key);

            // assert 
            Assert.AreEqual(expected, actual);
            //StringAssert.Contains();
            //CollectionAssert.AreEqual();
        }

        [TestMethod]
        public void DLLDecodeTest()
        {
            // A A A
            // arrange
            var str = "bcd";
            var expected = "abc";
            var key = 1;

            //act
            var actual = PasswordLib.PasswordEncoder.Decode(str, key);

            // assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
