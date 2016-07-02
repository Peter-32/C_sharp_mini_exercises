using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list9e = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            programLogic.insertionSort(list9e);
            list9e.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }
        public void insertionSort(List<int> list)
        {
            //// https://en.wikipedia.org/wiki/Insertion_sort has a graphical example of insertion sort
            // Work from left to right sorting as you go
            // When you reach a new element, first compare it with the previous element.  If higher then move on.
            // Otherwise take it out, move the previous one into its position,
            // then continue to compare it against the previous element until you find that the element taken out is higher
            // Then put it in place and continue outer loop.
            int listLength = list.Count();
            int temp = 0;

            for (var i = 1; i < listLength; i++) // start at i = 1
            {                
                if (list[i] > list[i - 1])  // If true, this element is in the right order.
                    continue;
                temp = list[i]; // create a temp to save the value
                list[i] = list[i - 1]; // overwrite list[i]
                if (i == 1) { list[0] = temp; } // This step is needed for i=1.  If i > 1 then the next loop takes care of this.
                for (var j = i; j > 1; j--)
                {
                    if (temp > list[j - 2])
                    {
                        list[j - 1] = temp;
                        break;
                    } else
                    {
                        list[j - 1] = list[j - 2];
                        if (j == 2) // this is a check to see if we went through all loops without a break being used.
                            list[0] = temp; // in that case add temp back into the list                           
                    }                    
                }
            }
        }
    }


}