using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Element_Occurs_in_a_List;

namespace Element_Occurs_in_a_List_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assemble
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>();
            list1.Add(4);
            list1.Add(32);
            list1.Add(4);
            list1.Add(4);
            list1.Add(4);

            List<int> list2 = new List<int>();

            // Act
            bool result1 = programLogic.contains(list1, 32);
            bool result2 = programLogic.contains(list1, 28);
            bool result3 = programLogic.contains(list1, 3);

            // Assert
            Assert.AreEqual(result1, true);
            Assert.AreEqual(result2, false);
            Assert.AreEqual(result3, false);
        }
    }
}
