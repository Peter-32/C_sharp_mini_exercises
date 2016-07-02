using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reverses_a_List;

namespace Reverses_a_List_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReverseListWithElements()
        {
            // Assemble
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

            List<int> list2 = new List<int>();
            list2.Add(5);
            list2.Add(32);
            list2.Add(5);
            list2.Add(2);
            list2.Add(1);
            list2.Add(5);
            list2.Add(8);
            list2.Add(1);
            list2.Add(7);

            // Act
            programLogic.reverseList(list1);

            // Assert
            CollectionAssert.AreEqual(list1, list2);
        }

        [TestMethod]
        public void TestReverseListWithNull()
        {
            // Assemble
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>();

            List<int> list2 = new List<int>();

            // Act
            programLogic.reverseList(list1);

            // Assert
            CollectionAssert.AreEqual(list1, list2);
        }
    }
}