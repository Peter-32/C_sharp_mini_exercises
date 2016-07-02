using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_Elements_on_Odd_Positions_in_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> returnElementsOnOddPositions(List<int> list)
        {
            List<int> newList = new List<int>();
            int i = 0;
            foreach (var element in list)
            {
                if (i % 2 == 0) // We use even index numbers because they have odd positions (Index 0 is first which is an odd position)
                {
                    newList.Add(element);
                }
                i++;
            }
            return newList;
        }
    }
}