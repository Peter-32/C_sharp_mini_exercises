using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compute_Oscilating_Convergent_Series_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            // The computation is 4 * (1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11...)
            // This is the computation for Pi.
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.execute();
            Console.ReadKey();
        }
    }

    class ProgramLogic
    {
        public void execute()
        {
            double acc = 0;
            for (var i = 1; i < 1000001; i++) // an approximation using i from 1 to 1,000,000
            {
                // (System.Math.Pow(-1,((i % 2) + 1)));   when i is even result is -1, when i is odd result is 1
                acc += (System.Math.Pow(-1,((i % 2) + 1))) / ((2 * i) - 1);
            }
            Console.WriteLine(4 * acc);
        }
    }
}
