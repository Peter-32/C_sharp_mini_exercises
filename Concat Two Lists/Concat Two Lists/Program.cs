using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat_Two_Lists
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            for (var i = 0; i < 11; i++)
            {
                list1.Add(i);
            }
            for (var i = 11; i < 21; i++)
            {
                list2.Add(i);
            }

            List<int> list3 = programLogic.concatLists(list1, list2);

            foreach (var element in list3)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> concatLists(List<int> list1, List<int> list2)
        {
            List<int> newList = new List<int>();
            foreach (var element in list1)
            {
                newList.Add(element);
            }
            foreach (var element in list2)
            {
                newList.Add(element);
            }
            return newList;
        }
    }
}
