using System;
using alternatingly_combining_lists;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace alternatingly_combining_lists_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assemble
            // This will create a list faster:
            // List<int> primes = new List<int>(new int[] { 19, 23, 29 });
            ProgramLogic programLogic = new ProgramLogic();
            List<object> list1 = new List<object>();
            List<object> list2 = new List<object>();
            List<object> list3 = new List<object>();
            List<object> list4 = new List<object>();
            List<object> list5 = new List<object>();
            List<object> assertEqualList = new List<object>();
            List<object> assertEqualList2 = new List<object>();
            list1.Add("a");
            list1.Add("b");
            list1.Add("c");
            list1.Add("d");
            list1.Add("e");
            list1.Add("f");
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list3.Add("a");
            list3.Add("b");
            list3.Add("c");
            list4.Add(1);
            list4.Add(2);
            list4.Add(3);
            list4.Add(4);
            list4.Add(5);
            list4.Add(6);
            list4.Add(7);
            list4.Add(8);
            assertEqualList.Add("a");
            assertEqualList.Add(1);
            assertEqualList.Add("b");
            assertEqualList.Add(2);
            assertEqualList.Add("c");
            assertEqualList.Add(3);
            assertEqualList.Add("d");
            assertEqualList.Add("e");
            assertEqualList.Add("f");
            assertEqualList2.Add("a");
            assertEqualList2.Add(1);
            assertEqualList2.Add("b");
            assertEqualList2.Add(2);
            assertEqualList2.Add("c");
            assertEqualList2.Add(3);            
            assertEqualList2.Add(4);
            assertEqualList2.Add(5);
            assertEqualList2.Add(6);
            assertEqualList2.Add(7);
            assertEqualList2.Add(8);           

            // Act
            List<object> newList1 = programLogic.alternatingly_combining_lists(list1, list2);
            List<object> newList2 = programLogic.alternatingly_combining_lists(list3, list4);
            List<object> newList3 = programLogic.alternatingly_combining_lists(list1, list5);
            List<object> newList4 = programLogic.alternatingly_combining_lists(list5, list1);

            // Assert
            CollectionAssert.AreEqual(newList1, assertEqualList);
            CollectionAssert.AreEqual(newList2, assertEqualList2);
        }
    }
}
