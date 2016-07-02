using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convert_number_to_list;

namespace add_digit_list
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list1 = ListUtils.convertNumberToList(9999);
            List<int> list2 = ListUtils.convertNumberToList(32315321);
            List<int> newList = programLogic.addNumberList(list1, list2);
            newList.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> addNumberList(List<int> list1, List<int> list2)
        {
            List<int> newList = new List<int>();
            int list1Digits = list1.Count();
            int list2Digits = list2.Count();
            int mostDigits = Math.Max(list1Digits, list2Digits);

            int carryTheOne = 0;
            int additionOfElements = 0;
            int list1Element = 0;
            int list2Element = 0;

            for (var i = 0; i < mostDigits; i++)
            {
                // Use the ones digit first, then go from right to left in each loop
                // if the number is too small set that digit to zero
                if (list1Digits - i <= 0)
                    list1Element = 0;
                else
                    list1Element = list1[list1Digits - 1 - i];

                if (list2Digits - i <= 0)
                    list2Element = 0;
                else
                    list2Element = list2[list2Digits - 1 - i];

                // logging
                // Console.WriteLine("list1Element={0}, list2Element={1}, carryTheOne={2}", list1Element, list2Element, carryTheOne);

                // add the elements and if we're carrying the one from the last loop, use that as well
                additionOfElements = list1Element + list2Element + carryTheOne;
                // add the digit to the list, keep the ones digit only (ie. for 12 keep 2)
                newList.Add(additionOfElements % 10);
                // record the tens digit
                carryTheOne = additionOfElements / 10;
            }
            newList.Reverse();
            return newList;
        }
    }
}

