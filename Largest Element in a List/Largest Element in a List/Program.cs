using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Element_in_a_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>(); // Empty list
            Console.WriteLine(programLogic.largestIntInList(list1));
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        int maxValue = 0;
        public int largestIntInList(List<int> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }
            foreach (int element in list)
                if (maxValue < element)
                {
                    maxValue = element;
                }
            return maxValue;
        }
    }
}