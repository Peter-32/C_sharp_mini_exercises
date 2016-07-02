using System;
using System.Collections.Generic;
using for_while_recursion_sum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace For_While_Recursion_Sum_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();
            IEnumerable<int> list5 = new int[] { 1,2,3,4,5 };
            IEnumerable<int> list6 = new int[] { };

            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            list3.Add(1);
            list3.Add(2);
            list3.Add(3);
            list3.Add(4);
            list3.Add(5);

            int sum1 = programLogic.forLoopSum(list1);
            int sum2 = programLogic.forLoopSum(list2);
            int sum3 = programLogic.whileLoopSum(list3);
            int sum4 = programLogic.whileLoopSum(list4);
            int sum5 = programLogic.recursionSum(list5,0);
            int sum6 = programLogic.recursionSum(list6,0);

            Assert.AreEqual(sum1, 15);
            Assert.AreEqual(sum3, 15);
            Assert.AreEqual(sum5, 15);
        }
    }
}
