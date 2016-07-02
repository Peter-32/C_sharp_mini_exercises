using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alternatingly_combining_lists
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

        public List<object> alternatingly_combining_lists(List<object> list1, List<object> list2)
        {
            List<object> newList = new List<object>();
            int list1Length = list1.Count();
            int list2Length = list2.Count();
            int longestLength = Math.Max(list1Length, list2Length);
            int i = 0;
            while (i < longestLength)
            {
                if (i < list1Length)
                    newList.Add(list1[i]);
                if (i < list2Length)
                    newList.Add(list2[i]);
                i++;
            }
            return newList;
        }

    }
}