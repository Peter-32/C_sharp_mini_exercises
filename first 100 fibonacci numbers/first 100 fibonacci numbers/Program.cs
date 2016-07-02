using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_100_fibonacci_numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<decimal> fibList = programLogic.firstFibonacciNumbers(138); // Any higher should give stack overflow
            List<decimal> fibList = programLogic.firstFibonacciNumbers(100);
            fibList.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }
        
        public List<decimal> firstFibonacciNumbers(int length)
        {
            switch (length)
            {
                case 0:
                    return new List<decimal>();
                case 1:
                    return new List<decimal> { 1 };
                case 2:
                    return new List<decimal> { 1, 1 };
            }
            List<decimal> list = new List<decimal> { 1, 1 };
            int i = 2; // i represents the list position of the next new element
            while (i < length)
            {
                list.Add( list[i - 1] + list[i - 2] );
                i++;
            }
            return list;
        }
    }
}