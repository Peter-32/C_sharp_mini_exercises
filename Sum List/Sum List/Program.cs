using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_List
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

        public int sumList(List<int> list)
        {
            int acc = 0;
            foreach (var element in list)
            {
                acc += element;
            }
            return acc;
        }
    }
}