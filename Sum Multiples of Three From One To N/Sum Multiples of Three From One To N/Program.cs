using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Multiples_of_Three_From_One_To_N
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            while (true)
            {
                programLogic.execute();
            }
        }
    }

    public class ProgramLogic
    {
        public int PromptMessageForInt()
        {
            // Contract.Ensures(Contract.Result<int>() >= 1);
            Console.WriteLine("Please enter an integer and the program will sum the numbers 1 to n.");
            int n = Convert.ToInt32(Console.ReadLine());

            return n;
        }

        public int SumNumbersOneToN(int n)
        {
            var acc = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    acc += i;
                }
            }
            return acc;
        }

        public void OutputMessage(int acc)
        {
            Console.WriteLine("When considering only multiples of three, the sum from 1 to n is {0}", acc);
        }

        public void execute()
        {
            var n = PromptMessageForInt();
            var acc = SumNumbersOneToN(n);
            OutputMessage(acc);
            Console.WriteLine();
            Console.WriteLine();
        }

    }


}