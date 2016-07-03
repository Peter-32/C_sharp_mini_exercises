using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merge_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list9d = new List<int> { 5, 6, 4, 7, 8, 9, 1, 2, 3 };
            programLogic.mergeSort(list9d);
            list9d.ForEach(Console.WriteLine);





            //            Console.WriteLine("list length is {0}", listLength);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public void mergeSort(List<int> list)
        {
            // base case
            int listLength = list.Count();
            if (listLength < 2) // if list is length 0 or 1 then leave the method, it is already sorted.
                return;

            // split up list into one element each
            List<List<int>> listOfLists = splitsListIntoIndividualElements(list); //splits into individual elements

            // Now merge them together
            while (listOfLists.Count() != 1)
            {
                listOfLists = mergeListOfListsIntoLargerVersion(listOfLists);
            }

            // Updated the original list
            for (var i = 0; i < listLength; i++)
            {
                list[i] = listOfLists[0][i];
            }
        }

        // splits the list into a smaller list
        public List<List<int>> splitsListIntoIndividualElements(List<int> list)
        {
            List<List<int>> newList = new List<List<int>>();
            int listLength = list.Count();
            for (var i = 0; i < listLength; i++)
            {
                newList.Add(new List<int> { list[i] });
            }
            return newList;
        }

        // calls mergeTwoSortedLists as many times as needed to finish 
        public List<List<int>> mergeListOfListsIntoLargerVersion(List<List<int>> listOfLists)
        {
            List<List<int>> newListOfLists = new List<List<int>>();
            int listLength = listOfLists.Count();

            for (var i = 0; i < listLength - 1; i += 2) // minus one because we are doing i+=2;
            {
                newListOfLists.Add(mergeTwoSortedLists(listOfLists[i], listOfLists[i + 1]));
            }
            if (listLength % 2 == 1) //odd length, so add the last one in.
            {
                newListOfLists.Add(listOfLists[listLength - 1]);
            }
            return newListOfLists;
        }


        // merges two lists into a larger list
        public List<int> mergeTwoSortedLists(List<int> list1, List<int> list2)
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
                }
                else
                {
                    newList.Add(list1[i]);
                    i++;
                }
            }
            if (i >= list1Length)
            {
                newList.AddRange(list2.Skip(j));
            }
            else
            {
                newList.AddRange(list1.Skip(i));
            }
            return newList;
        }

        // copies an array; called by the two helper functions
        public List<List<int>> copyListOfLists(List<List<int>> listOfLists)
        {
            return new List<List<int>>(listOfLists);
        }
    }
}