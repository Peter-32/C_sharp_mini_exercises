using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace risk_better_to_attack_or_defend
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.simulation(100);
            programLogic.simulation(1000);
            programLogic.simulation(10000);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {

        int blueDead
        {
            get;
            set;
        } = 0;

        int redDead
        {
            get;
            set;
        } = 0;

        public void simulation(int iterations)
        {
            Random r = new Random();

            int i = 0;
            while (i < iterations)
            {

                List<int> blueRolls = new List<int> { r.Next(1, 7), r.Next(1, 7), r.Next(1, 7) };
                List<int> redRolls = new List<int> { r.Next(1, 7), r.Next(1, 7) };

                blueRolls.Sort();
                redRolls.Sort();

                //blueRolls.ForEach(Console.WriteLine);
                //Console.WriteLine();
                //redRolls.ForEach(Console.WriteLine);

                if (blueRolls[2] > redRolls[1])
                    redDead += 1;
                else
                    blueDead += 1;

                if (blueRolls[1] > redRolls[0])
                    redDead += 1;
                else
                    blueDead += 1;
                i++;
            }
            Console.WriteLine("In a simulation of {0} battles, the number of blue dead are {1} \n and the number of red dead are {2}", iterations, blueDead, redDead);
            blueDead = 0;
            redDead = 0;




        }
    }
}