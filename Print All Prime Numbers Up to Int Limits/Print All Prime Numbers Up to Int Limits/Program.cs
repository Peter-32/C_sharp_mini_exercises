using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_All_Prime_Numbers_Up_to_Int_Limits
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.execute();
            //Console.ReadKey();
        }
    }

    class ProgramLogic
    {
        public void execute()
        {
            returnPrimeListToFile();
        }

        public bool isPrime(int number)
        {
            for (var i = 2; i <= System.Math.Sqrt(number); i++)
            {
                if (number % i == 0) { return false; }
            }
            return true;
        }

        public void returnPrimeListToFile()
        {
            var primeList = new List<int>();
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Peter\Desktop\C_IO\file1.txt"))
                for (var i = 1; i < INT_LIMIT_DIVIDED_BY_100; i++)
            {
                if (isPrime(i))
                {
                    file.WriteLine(i);                    
                }
            }
        }

        private const int INT_LIMIT_DIVIDED_BY_100 = int.MaxValue / 100;
    }
}


