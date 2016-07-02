using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_or_Product_From_One_To_N
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
            Console.WriteLine("Please enter an integer and the program will find the summation or product of the numbers 1 to n.");
            int n = Convert.ToInt32(Console.ReadLine());

            return n;
        }

        public string PromptMessageForReduction()
        {
            Console.WriteLine("Which type would you like the program to calculate?  Type product or sum.");
            string input = Console.ReadLine();

            return input;
        }

        public int SumNumbersOneToN(int n, string choice)
        {
            var acc = 0;
            if (choice == "product") { acc = 1; }
            for (int i = 1; i <= n; i++)
            {
                if (choice == "product")
                {
                    acc *= i;
                } else if (choice == "sum")
                {
                    acc += i;
                }
            }
            return acc;
        }

        public void OutputMessage(int acc)
        {
            Console.WriteLine("The result is {0}", acc);
        }

        public void execute()
        {
            var n = PromptMessageForInt();
            var choice = PromptMessageForReduction();
            var acc = SumNumbersOneToN(n, choice);
            OutputMessage(acc);
            Console.WriteLine();
            Console.WriteLine();
        }

    }


}
