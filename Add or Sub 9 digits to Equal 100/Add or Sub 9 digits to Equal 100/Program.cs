using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_or_Sub_9_digits_to_Equal_100
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.printCombinationsThatEqual100ByPlacingAddOrSubtractSignInBetween123456789();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

     
        public void printCombinationsThatEqual100ByPlacingAddOrSubtractSignInBetween123456789()
        {
            List<List<int>> choices = createAllValidExpressionsForTesting();
            List<string> validExpressions = filterForValidExpressionsAddingTo100(choices); // These equal 100
            validExpressions.ForEach(Console.WriteLine);
        }

        // The expression is expression = "1?2?3?4?5?6?7?8?9"
        // replace ? with either +, -, or _.  Where _ is a combiner 8_9 is 89.
        // let 0 be _; 1 be +; 2 be -
        // there are 8 spots with 3 choices possible for each.  Therefor 3^8 = 6561 possibilities.   
        public List<List<int>> createAllValidExpressionsForTesting()
        {
            List<List<int>> choices = new List<List<int>>();

            for (var i = 0; i < 6561; i++) // 6561 is 3^8
            {
                choices.Add(new List<int> { i / (int)Math.Pow(3,7), (i / (int)Math.Pow(3, 6)) % 3,
                                            (i / (int)Math.Pow(3,5)) % 3, (i / (int)Math.Pow(3,4)) % 3,
                                            (i / (int)Math.Pow(3,3)) % 3, (i / (int)Math.Pow(3,2)) % 3,
                                            (i / 3) % 3, i % 3});
            }


            /* var j = 0;
            while(j < 6561)
            {
                for (var k = 0; k < 8; k++)
                {
                    Console.Write(" " + choices[j][k]);
                }
                Console.WriteLine();
                j++;
            } */



            return choices;
        }

        // pass in an choices which is a length 8 array of choices 0, 1, 2
        // where 0 be _; 1 be +; 2 be -; and _ means combine the numbers
        // this returns true if it equals 100 and false otherwise
        public bool doesExpressionEqual100(string expressionString)
        {

            List<int> numberList = new List<int>();
            List<char> orderOfOperators = new List<char>();
            char[] delimiterChars = { '+', '-' };
            string[] numbersAsString = expressionString.Split(delimiterChars);
            foreach (var element in numbersAsString)
            {
                numberList.Add(Int32.Parse(element));
            }

            // Find the order of operators so we know to add or subtract each number
            for (var i = 0; i < expressionString.Length; i++)
            {
                if (expressionString[i] == '+')
                    orderOfOperators.Add('+');
                if (expressionString[i] == '-')
                    orderOfOperators.Add('-');
            }

            // Now we loop across the operators and add/subtract            
            var acc = numberList[0]; // running accumulator of the expression
            var j = 1; // the index of the number list
            for (var i = 0; i < orderOfOperators.Count(); i++)
            {
                if (orderOfOperators[i] == '+')
                    acc += numberList[j];          
                else
                    acc -= numberList[j];
                    
                j++;
            }

            return acc == 100;
        }       

        // filters for valid expressions only based on whether they equal 100
        public List<string> filterForValidExpressionsAddingTo100(List<List<int>> choices)
        {
            List<string> validExpressions = new List<string>();
            int listLength = choices.Count;
            string expressionString;

            for (var i = 0; i < listLength; i++)
            {
                expressionString = buildStringExpressionFromChoices(choices[i]);
                if (doesExpressionEqual100(expressionString))
                {
                    validExpressions.Add(expressionString);
                }
            }
            return validExpressions;
        }

        // given choices build a string expression for it
        public string buildStringExpressionFromChoices(List<int> choice)
        {
            if (choice.Count() != 8)
                throw new Exception("choices array isn't length 8");

            List<string> choicesString = new List<string>();
            foreach (var element in choice)
            {
                if (element == 0)
                    choicesString.Add("");
                else if (element == 1)
                    choicesString.Add("+");
                else
                    choicesString.Add("-");
            }
            return String.Concat("1", choicesString[0], "2", choicesString[1], "3", choicesString[2],
                "4", choicesString[3], "5" + choicesString[4], "6" + choicesString[5], "7",
                choicesString[6], "8", choicesString[7], "9");
        }

        //// EXTRA UNUSED FUNCTION ////
        public int combineIntegers(params int[] numbers)
        {
            int arrayLength = numbers.Length;
            int acc = 0;
            for (var i = 0; i < arrayLength; i++)
            {
                acc += numbers[i] * (int)Math.Pow(10, arrayLength - i - 1);
            }
            return acc;
        }

        //// EXTRA UNUSED FUNCTION ////
        // Returns true if there are 2 or 4 odd numbers
        // find all digits with a + or - after them.
        // Add one for the 9 at the end.
        public bool expressionHas2Or4OddNumbers(string expression)
        {
            int expressionLength = expression.Length;
            int acc = 0;
            for (var i = 1; i < expressionLength; i++)
            {
                if (expression[i] == '+' || expression[i] == '-')
                {
                    if (expression[i - 1] == '1' || expression[i - 1] == '3' ||
                        expression[i - 1] == '5' || expression[i - 1] == '7')
                        acc++;
                }
            }
            acc++; // add one for nine
            return (acc == 2 || acc == 4);
        }

    }
}