using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_the_Next_20_Leap_Years
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.execute();
            Console.ReadKey();
        }
    }

    class ProgramLogic
    {
        public int nextYear
        {
            get;
            set; 
        } = DateTime.Now.Year + 1;

        public int leapYearCount
        {
            get;
            set;
        }

        public void execute()
        {
            int i = nextYear;
            while (leapYearCount < 21) // We only want to find the next 20 leap years.
            {
                if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0) // divisible by 4 and not by 100, but divisible by 400 is always allowed.
                {
                    Console.WriteLine(i);
                    leapYearCount++;  // We found a leap year.
                }
                i++; // the next year.
            }
        }
    }
}
