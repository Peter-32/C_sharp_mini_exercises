using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_All_Perfect_Squares
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list = new List<int>();
            for (var i = 1; i < 21; i++)
            {
                list.Add(i);
            }
            programLogic.on_all(list, programLogic.square);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public double square(double x)
        {
            Console.WriteLine(Math.Pow(x, 2.0));
            return Math.Pow(x, 2.0);
        }

        public void on_all(List<int> list, Func<double, double> f)
        {
            foreach (var element in list)
            {
                f(element);
            }
        }
    }
}