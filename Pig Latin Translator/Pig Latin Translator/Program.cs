using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Pig_Latin_Translator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            string pigLatin = programLogic.englishToPigLatin("the quick brown fox...");
            string english = programLogic.pigLatinToEnglish(pigLatin);
            Console.WriteLine(pigLatin);
            Console.WriteLine(english);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public string englishToPigLatin(string str)
        {
            string newStr;
            // splits the message into words, whitespaces, punctuation.            
            string[] stringSplit = Regex.Split(str, "\\b");
            int arrayLength = stringSplit.Count();
            // We are updating each word to use pig latin.
            for (var i = 0; i < arrayLength; i++)
            {
                if (stringSplit[i].Length == 0) // Skip strings of length 0
                    continue;
                if (Char.IsLetter(stringSplit[i][0]))  // If it is a word:
                {
                    stringSplit[i] = stringSplit[i] + Char.ToLower(stringSplit[i][0]) + "ay";    // word + first letter + "ay"
                    stringSplit[i] = stringSplit[i].Remove(0, 1);                  // remove the first letter
                }
            }

            newStr = String.Join("", stringSplit);
            return newStr;
        }

        public string pigLatinToEnglish(string str)
        {
            string newStr;
            // splits the message into words, whitespaces, punctuation.            
            string[] stringSplit = Regex.Split(str, "\\b");
            int arrayLength = stringSplit.Count();
            // We are updating each word to use pig latin.
            for (var i = 0; i < arrayLength; i++)
            {
                int stringLength = stringSplit[i].Length;
                if (stringLength == 0) // Skip strings of length 0
                    continue;
                if (Char.IsLetter(stringSplit[i][0]))  // If it is a word:
                {
                    char firstLetterOfEnglishWord = stringSplit[i][stringLength - 3];
                    stringSplit[i] = firstLetterOfEnglishWord + stringSplit[i].Substring(0, stringLength - 3);                    
                }
            }

            newStr = String.Join("", stringSplit);
            return newStr;
        }
    }
}