using System;
using merges_two_sorted_lists;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace merges_two_sorted_lists_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int> { 1, 2, 32, 41, 52, 523 };
            List<int> list2 = new List<int> { 3, 4, 31, 46, 51, 101, 102, 1010 ,4646 , 6000};
            List<int> assertList = new List<int> { 1, 2, 3, 4, 31, 32, 41, 46, 51, 52, 101, 102, 523, 1010, 4646, 6000 };

            List<int> newList = programLogic.mergeTwoSortedAscListsKeepingSort(list1, list2);
            List<int> newList2 = programLogic.mergeTwoSortedAscListsKeepingSort(list2, list1);

            CollectionAssert.AreEqual(newList, assertList);
            CollectionAssert.AreEqual(newList2, assertList);
        }
    }
}
