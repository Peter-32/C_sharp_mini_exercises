using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Sum_List;

namespace Sum_List_Tests
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
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);

            List<int> list2 = new List<int>();

            // Act
            var x = programLogic.sumList(list1);
            programLogic.sumList(list2);

            // Assert
            Assert.AreEqual(x,21);

        }
    }
}
