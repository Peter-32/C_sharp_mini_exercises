using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Table
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
        public void execute()
        {
            for (var i = 1; i < 13; i++)
            {
                for (var j = 1; j < 13; j++)
                {
                    Console.Write("{0,4}", j*i);
                }
                Console.WriteLine("");
            }                        
        }
    }
}
