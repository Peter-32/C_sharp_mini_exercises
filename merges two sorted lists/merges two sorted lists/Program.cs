using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merges_two_sorted_lists
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();

            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> mergeTwoSortedAscListsKeepingSort(List<int> list1, List<int> list2)
        {
            List<int> newList = new List<int>();
            int list1Length = list1.Count();
            int list2Length = list2.Count();
            int i = 0;
            int j = 0;
            while (i < list1Length && j < list2Length)
            {
                if (list1[i] > list2[j])
                {
                    newList.Add(list2[j]);
                    j++;
                } else
                {
                    newList.Add(list1[i]);
                    i++;
                }
            }
            if (i >= list1Length)
            {
                newList.AddRange(list2.Skip(j));
            } else
            {
                newList.AddRange(list1.Skip(i));
            }              
            return newList;
        }
    }
}