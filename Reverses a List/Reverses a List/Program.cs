using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverses_a_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> reverseList(List<int> list)
        {
            int listLength = list.Count;
            if (listLength == 0)
            {
                return list;
            }
            int intHolder = list[listLength - 1];
            for (var i = 0; i < listLength / 2; i++)
            {
                int temp = list[i];
                list[i] = list[listLength - 1 - i];
                list[listLength - 1 - i] = temp;
            }
            return list;
        }
    }
}