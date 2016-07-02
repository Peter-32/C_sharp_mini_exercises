using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using isPalindrome;

namespace isPalindromeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProgramLogic programLogic = new ProgramLogic();
            string str1 = "Hello World";
            string str2 = "palindromemordnilap";
            string str3 = "palindromeemordnilap";

            bool test1 = programLogic.isPalindrome(str1);
            bool test2 = programLogic.isPalindrome(str2);
            bool test3 = programLogic.isPalindrome(str3);

            Assert.AreEqual(test1, false);
            Assert.AreEqual(test2, true);
            Assert.AreEqual(test3, true);

        }
    }
}
