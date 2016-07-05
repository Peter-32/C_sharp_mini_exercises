using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Year_Foreign_Planet_Leap_Year_Calc
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 101;  i+=2)
            {
                var fraction = ((double)i / 100) + .002193403 ;
                ForeignPlanetCalculations.printCalendarYearSolarYear(365 + fraction);
            }
            
            Console.ReadKey();
        }
    }

    static class FractionMathUtils
    {
        public static double keepOnlyFractionPart(double number)
        {
            // Using multiple statements so it will be more efficient with large numbers to run number % 1
            number = number % 1000000;
            number = number % 10000;
            number = number % 100;
            number = number % 1;
            return number;
        }

        public static bool withinIntervalOfANaturalNumber(double number, double interval)
        {
            // natural numbers are integers starting with 1
            if (number < 1 - interval)
                return false;
            return (number % 1 < interval) || (number % 1 > (1 - interval));
        }

        public static double differenceOfNumberWithTheClosestNaturalNumber(double number)
        {
            // natural numbers are integers starting with 1
            if (number < 1)
                return 1 - number;
            return Math.Min(number % 1, Math.Abs(number % 1 - 1));               
        }

        public static string lowerOrHigherThanClosestNaturalNumber(double number, double interval)
        {
            // natural numbers are integers starting with 1
            if (number < 1 - interval)
                return "lower";
            if (keepOnlyFractionPart(number) >= .5)
                return "lower";
            else
                return "higher";
        }

    }

    static class ForeignPlanetCalculations
    {

        public static void printCalendarYearSolarYear(double fractionalSolarYear)
        {
            Console.WriteLine("For a solar year of {0}", fractionalSolarYear);
            List<int> calendarYear = new List<int> ();
            List<double> solarYear = new List<double> ();
            fractionalSolarYear = FractionMathUtils.keepOnlyFractionPart(fractionalSolarYear);
            int firstRuleYearsPerLeapYear = ForeignPlanetCalculations.calendarYearsToBeCloseToIntSolarYear(fractionalSolarYear,1);
            // We've found the number of years each leap year
            Console.WriteLine("Have a leap Year Every {0} years", firstRuleYearsPerLeapYear);
            
            // If it is close enough we are done
            if (FractionMathUtils.withinIntervalOfANaturalNumber(firstRuleYearsPerLeapYear * fractionalSolarYear, secondInterval))
            {
                Console.WriteLine("These are all the rules");
                Console.WriteLine();
                return;
            }
            // We follow the pattern of having a leap year every period.  we the make adjustments from there.
            // adjustment every X years; which is a multiple of the leap years.
            int secondRuleAdjustmentXYears = ForeignPlanetCalculations.calendarYearsToBeCloseToIntSolarYear(firstRuleYearsPerLeapYear * fractionalSolarYear,2);
            double eachLeapYearTheDifferenceFromANaturalNumber = FractionMathUtils.differenceOfNumberWithTheClosestNaturalNumber(fractionalSolarYear * firstRuleYearsPerLeapYear);
            if (FractionMathUtils.lowerOrHigherThanClosestNaturalNumber(firstRuleYearsPerLeapYear * fractionalSolarYear, firstInterval) == "lower")
            {
                Console.WriteLine("Except every {0} years do not have your next {1} leap years", Math.Round((double)secondRuleAdjustmentXYears * firstRuleYearsPerLeapYear), Math.Round(secondRuleAdjustmentXYears * eachLeapYearTheDifferenceFromANaturalNumber));
            }
            else
            {
                Console.WriteLine("Every {0} years have two leap days instead of one for the next {1} leap years", Math.Round((double)secondRuleAdjustmentXYears * firstRuleYearsPerLeapYear), Math.Round(secondRuleAdjustmentXYears * eachLeapYearTheDifferenceFromANaturalNumber));
            }

            // If close enough we are done
            if (FractionMathUtils.withinIntervalOfANaturalNumber(firstRuleYearsPerLeapYear * secondRuleAdjustmentXYears * fractionalSolarYear, thirdInterval))
            {
                Console.WriteLine("These are all the rules");
                Console.WriteLine();
                return;
            }
            // We follow the pattern of having a leap year every period and making an adjustment, we also make a further adjustment.
            int thirdRuleAdjustment = ForeignPlanetCalculations.calendarYearsToBeCloseToIntSolarYear(eachLeapYearTheDifferenceFromANaturalNumber * secondRuleAdjustmentXYears, 3);
            double each2ndRuleAdjustmentTheDifferenceFromANaturalNumber = FractionMathUtils.differenceOfNumberWithTheClosestNaturalNumber(eachLeapYearTheDifferenceFromANaturalNumber * secondRuleAdjustmentXYears);
            if (FractionMathUtils.lowerOrHigherThanClosestNaturalNumber(secondRuleAdjustmentXYears * eachLeapYearTheDifferenceFromANaturalNumber, firstInterval) == "lower")
            {
                Console.WriteLine("Except every {0} years do not have your next {1} leap years", Math.Round((double)thirdRuleAdjustment * secondRuleAdjustmentXYears), Math.Round(thirdRuleAdjustment * each2ndRuleAdjustmentTheDifferenceFromANaturalNumber));
                Console.WriteLine("These are all the rules");
            }
           else
            {
                Console.WriteLine("Every {0} years have two leap days instead of one for the next {1} leap years", Math.Round((double)thirdRuleAdjustment * secondRuleAdjustmentXYears), Math.Round(thirdRuleAdjustment * each2ndRuleAdjustmentTheDifferenceFromANaturalNumber));
                Console.WriteLine("These are all the rules");
            }
            Console.WriteLine();
        }


        public static int calendarYearsToBeCloseToIntSolarYear(double fractionalSolarYear, int ruleNumber)
        {
            double changingInterval;
            if (ruleNumber == 1)
                changingInterval = firstInterval;
            else if (ruleNumber == 2)
                changingInterval = secondInterval;            
            else
                changingInterval = thirdInterval;

            fractionalSolarYear = FractionMathUtils.keepOnlyFractionPart(fractionalSolarYear);
            if (fractionalSolarYear >= 1 - changingInterval) // if a high number, then use a leap year.
                return 1;
            if (fractionalSolarYear <= .00001) // no leap year required
                return 0;


            double differenceFromNaturalNumber = 0.0;
            double lowestDifference = 2.0; // this will be reassigned later
            int calendarYearsWithLowestDifference = 0;
            double additionalDays = 0;
            int calendarYears = 1;
            while (!FractionMathUtils.withinIntervalOfANaturalNumber(additionalDays, changingInterval))
            {
                calendarYears++;
                additionalDays = fractionalSolarYear * calendarYears;                
            }
            // find all numbers within the interval to this integer;  Use the smallest difference
            while (FractionMathUtils.withinIntervalOfANaturalNumber(additionalDays, changingInterval))
            {
                
                differenceFromNaturalNumber = FractionMathUtils.differenceOfNumberWithTheClosestNaturalNumber(additionalDays);
                if (differenceFromNaturalNumber < lowestDifference)
                {
                    lowestDifference = differenceFromNaturalNumber;
                    calendarYearsWithLowestDifference = calendarYears;
                }
                calendarYears++;
                additionalDays = fractionalSolarYear * calendarYears;
            }
            return calendarYearsWithLowestDifference;
        }

        private const double firstInterval = .15;
        private const double secondInterval = .005;  // this is 1/200.  Anything smaller is not too consequential for us.
        private const double thirdInterval = .002;  // this is 1/500.  Anything smaller is not too consequential for us.






















        // Don't use this below:

        /*
        public static void printLeapYearRules2(double fractionalSolarYear)
        {
            int rulesSoFar = 0;
            List<int> multiplierRules = new List<int>();
            List<string> leapYearrules = new List<string>();
            if (true)
            {
                leapYearrules = generateLeapYearRulesFromMultiplierRules(multiplierRules);
            }
            else
            {

            }
            leapYearrules.ForEach(Console.WriteLine);
        }

        // .03 -> 


        private static List<string> generateLeapYearRulesFromMultiplierRules2(List<int> multiplierRules)
        {

        }


        //Stopping rules based on number of rules:
        //0	.0003
        //1	.001
        //2	.003
        //3	.01
        //4	.03
        //5	.1
        //6	.3
        //7+	.01
        // Don't use this; probably delete it

        private static bool printLeapYearRulesIsGoodEnough(double fractionalSolarYear, int rulesSoFar)
        {
            // Keep only the decimal
            fractionalSolarYear = FractionMathUtils.keepOnlyFractionPart(fractionalSolarYear);
            switch (rulesSoFar)
            {
                case 0:
                    return (fractionalSolarYear < .000003);
                case 1:
                    return (fractionalSolarYear < .00001);
                case 2:
                    return (fractionalSolarYear < .00003);
                case 3:
                    return (fractionalSolarYear < .0001);
                case 4:
                    return (fractionalSolarYear < .0003);
                case 5:
                    return (fractionalSolarYear < .001);
                case 6:
                    return (fractionalSolarYear < .003);
                default:
                    return (fractionalSolarYear < .01);
            }
        } */
    }
}