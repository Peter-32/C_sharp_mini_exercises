using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element_Occurs_in_a_List
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

        public bool contains(List<int> list, int number)
        {
            foreach (var element in list)
            {
                if (element == number) { return true; }
            }
            return false;
        }
    }
}
