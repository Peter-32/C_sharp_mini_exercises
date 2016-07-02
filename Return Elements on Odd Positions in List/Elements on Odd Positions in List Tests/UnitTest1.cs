using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Return_Elements_on_Odd_Positions_in_List;

namespace Elements_on_Odd_Positions_in_List_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assemble
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(3);
            list.Add(64);
            list.Add(32);
            list.Add(12);
            list.Add(77);
            list.Add(23);
            list.Add(101);

            List<int> list2 = new List<int>();
            list2.Add(1);            
            list2.Add(64);            
            list2.Add(12);           
            list2.Add(23);

            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();

            List<int> list5 = new List<int>();
            list5.Add(12);
            list5.Add(32);
            List<int> list6 = new List<int>();
            list6.Add(12);
            

            // Act
            List<int> listNew = programLogic.returnElementsOnOddPositions(list);
            List<int> listNew3 = programLogic.returnElementsOnOddPositions(list3);
            List<int> listNew5 = programLogic.returnElementsOnOddPositions(list5);

            // Assert
            CollectionAssert.AreEqual(listNew, list2);
            CollectionAssert.AreEqual(listNew3, list4);
            CollectionAssert.AreEqual(listNew5, list6);




        }
    }
}
