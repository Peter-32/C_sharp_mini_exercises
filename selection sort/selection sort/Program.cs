using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list = new List<int> { 1, 512, 23, 123, 5231, 124, 743, 31 };
            programLogic.selectionSort(list);
            list.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public void selectionSort(List<int> list)
        {
            // Loop through remainder and find current min by comaring current to current min.  
            // Move current min to new location
            int listLength = list.Count();
            int minValuePosition = 0;
            int minValue = 0;
            int temp = 0;

            for (var i = 0; i < listLength; i++) // updates one list per iteration
            {
                minValue = list[i];
                minValuePosition = i;
                for (var j = i; j < listLength; j++) // finds the index with the lowest number in the remaining entries
                {
                    if (minValue > list[j])
                    {
                        minValuePosition = j;
                        minValue = list[j];
                    }
                }
                // swap the position
                temp = list[i];
                list[i] = minValue;
                list[minValuePosition] = temp;
            }


        }
    }
}