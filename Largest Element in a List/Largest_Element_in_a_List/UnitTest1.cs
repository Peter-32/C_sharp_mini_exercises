using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Largest_Element_in_a_List
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>();
            list1.Add(7);
            list1.Add(1);
            list1.Add(8);
            list1.Add(5);
            list1.Add(1);
            list1.Add(2);
            list1.Add(5);
            list1.Add(32);
            list1.Add(5);

            // Act
            int maxValue = programLogic.largestIntInList(list1);

            // Assert
            Assert.AreEqual(32, maxValue);
        }
    }
}
