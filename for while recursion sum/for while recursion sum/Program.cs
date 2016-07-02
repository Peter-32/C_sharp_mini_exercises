using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_while_recursion_sum
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

        public int forLoopSum(List<int> list)
        {
            int acc = 0;
            for (var i = 0; i < list.Count(); i++)
            {
                acc += list[i];
            }
            return acc;
        }

        public int whileLoopSum(List<int> list)
        {
            int acc = 0;
            int i = 0;
            while (i < list.Count())
            {
                acc += list[i];
                i++;
            }
            return acc;
        }

        public int recursionSum(IEnumerable<int> list, int count)
        {
            if (list.Count() == 0)
            {
                return count;
            }            
                return recursionSum(list.Skip(1), count + list.ElementAt(0));
        }
    }
}