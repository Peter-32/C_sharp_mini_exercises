using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stooge_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list9e = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            programLogic.stoogeSort(list9e);
            list9e.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        // swap elements.  If length is > 2 then do stooge sort three times; first on the first 2/3
        // then on the last 2/3; then on the beginning 2/3

        public void stoogeSort(List<int> list)
        {
            int listLength = list.Count();
            stoogeSortLoop(list, 0, listLength - 1);
        }

        public void stoogeSortLoop(List<int> list, int startIdx, int endIdx)
        {
            int listLength = endIdx - startIdx + 1;
            if (listLength < 2)
                return;
            if (list[endIdx] < list[startIdx])
            {
                int temp = list[startIdx];
                list[startIdx] = list[endIdx];
                list[endIdx] = temp;
            }

            if (listLength > 2) // if size is at least 3
            {                
                int twoThirdLength = (listLength + 1) * 2 / 3; // the +1 will end up being +2 when multiplied by 2.  This rounds the divided by 3 up.
                stoogeSortLoop(list, startIdx, startIdx + twoThirdLength - 1);
                stoogeSortLoop(list, endIdx - twoThirdLength + 1 , endIdx);
                stoogeSortLoop(list, startIdx, startIdx + twoThirdLength - 1);
            }
        }
    }
}
