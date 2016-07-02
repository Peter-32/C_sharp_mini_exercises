using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace shift_list_by_k_elements
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            programLogic.shift_k_elements_left(list, 2);
            foreach ( var element in list)
            { Console.WriteLine(element); }
            Console.WriteLine();
            programLogic.shift_k_elements_left(list, 4);
            foreach (var element in list)
            { Console.WriteLine(element); }
            Console.WriteLine();
            programLogic.shift_k_elements_left(list, 6);
            foreach (var element in list)
            { Console.WriteLine(element); }
            Console.WriteLine();
            programLogic.shift_k_elements_left(list, -1);
            foreach (var element in list)
            { Console.WriteLine(element); }
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public void shift_k_elements_left(List<int> list, int k)
        {
            Contract.Requires(k > 0);
            int listLength = list.Count();
            int shift = k % listLength;  // A shift longer than the list can be reduced.

            while (shift != 0)
            {
                int first_value = list[0];
                for (var j = 1; j < listLength; j++)
                {
                    list[j - 1] = list[j];
                }
                list[listLength - 1] = first_value;
                shift--;
            }
        }
    }
}