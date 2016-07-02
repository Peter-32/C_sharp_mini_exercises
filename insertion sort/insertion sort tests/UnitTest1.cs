using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using insertion_sort;
using System.Collections.Generic;
namespace insertion_sort_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assemble
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list2a = new List<int> { 2, 1 };
            List<int> list2b = new List<int> { 1, 2 };
            List<int> list9a = new List<int> { 1, 2, 3, 4, 5, 6 ,7 ,8 ,9 };
            List<int> list9b = new List<int> { 5,6,4,7,3,8,2,9,1 };
            List<int> list9c = new List<int> { 7, 3, 2, 1, 5, 4, 6, 8, 9 };
            List<int> list9d = new List<int> { 5,6,4,7,8,9,1,2,3 };
            List<int> list9e = new List<int> { 9,8,7,6,5,4,3,2,1 };
            List<int> list9f = new List<int> { 1,3,5,7,9,2,4,6,8 };
            List<int> list9g = new List<int> { 9,7,5,3,1,2,4,6,8 };
            List<int> listEmpty = new List<int>();
            List<int> list1a = new List<int> { 1 };

            // Act
            programLogic.insertionSort(list2a);
            programLogic.insertionSort(list2b);
            programLogic.insertionSort(list9a);
            programLogic.insertionSort(list9b);
            programLogic.insertionSort(list9c);
            programLogic.insertionSort(list9d);
            programLogic.insertionSort(list9e);
            programLogic.insertionSort(list9f);
            programLogic.insertionSort(list9g);
            programLogic.insertionSort(listEmpty);
            programLogic.insertionSort(list1a);

            // Assert
            CollectionAssert.AreEqual(list2a, new List<int> { 1, 2 });
            CollectionAssert.AreEqual(list2b, new List<int> { 1, 2 });
            CollectionAssert.AreEqual(list9a, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9b, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9c, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9d, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9e, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9f, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(list9g, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(listEmpty, new List<int> {  });
            CollectionAssert.AreEqual(list1a, new List<int> { 1 });
        }
    }
}
