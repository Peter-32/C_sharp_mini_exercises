using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quick_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            var list = new List<int> { 6, 18, 4, 2, 15, 3, 9, 8, 7, 10, 11, 12, 5, 14, 13, 16, 17, 1 ,19, 20 };
            programLogic.quickSort(list);
            list.ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        int debugCalls
        {
            get;
            set;
        }

        public void execute()
        {

        }

        public void quickSort(List<int> list)
        {
            int listLength = list.Count();
            if (listLength < 2) // size 0 or size 1 lists are already sorted.
                return;
            int initialWallPosition = 0;

            int startIdx = 0;
            int endIdx = listLength - 1;


            initialWallPosition = executeAPivot(list, startIdx, endIdx); // First single call
            recursiveQuickSort(list, initialWallPosition, startIdx, endIdx); // begin making double calls


        }

        // recursive step of quick sort
        public void recursiveQuickSort(List<int> list, int center, int left, int right)
        {
            int newCenterOnRight = -1; // default -1 in case center is -1
            int newCenterOnLeft = -1; // default -1 in case center is -1
            if (center != -1)
            {
                newCenterOnRight = executeAPivot(list, center + 1, right); // right side call
                newCenterOnLeft = executeAPivot(list, left, center - 1); // left side call    

            }

            if (newCenterOnRight != -1) // right side
            {
                recursiveQuickSort(list, executeAPivot(list, newCenterOnRight + 1, right), newCenterOnRight + 1, right); // right side of right side
                
                recursiveQuickSort(list, executeAPivot(list, center, newCenterOnRight - 1), center, newCenterOnRight - 1); // left side of right side
                
            }

            if (newCenterOnLeft != -1) // left side
            {
                recursiveQuickSort(list, executeAPivot(list, newCenterOnLeft + 1, center), newCenterOnLeft + 1, center); // right side of left side
                recursiveQuickSort(list, executeAPivot(list, left, newCenterOnLeft - 1), left, newCenterOnLeft - 1); // left side of left side
            }
        }


        // returns an int of where the wall was found or lets it know it hit a base case
        public int executeAPivot(List<int> list, int startIdx, int endIdx) 
        {
            debugCalls += 1;

            int listLength = 1 + endIdx - startIdx;
            if (listLength < 2) // size 0 or size 1 lists are already sorted.
                return -1; // this code of -1 lets the computer know it has hit a base case.
            int pivot = list[endIdx];
            int wallIsLeftOfPosition = startIdx;
            int temp = 0;

            // Move elements less than pivot to the left side of the list.
            for (var i = startIdx; i <= endIdx; i++)
            {
                if (list[i] < pivot)
                {
                    temp = list[wallIsLeftOfPosition];
                    list[wallIsLeftOfPosition] = list[i];
                    list[i] = temp;
                    wallIsLeftOfPosition += 1;
                }
            }


            temp = list[wallIsLeftOfPosition];
            list[wallIsLeftOfPosition] = pivot;
            list[endIdx] = temp;
            return wallIsLeftOfPosition; // let the caller of the function know the wall position.
        }
    }
}