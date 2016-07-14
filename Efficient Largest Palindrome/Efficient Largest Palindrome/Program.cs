using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efficient_Largest_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "search for a palindrome in a sentence";
            Console.WriteLine("\"" + PalindromeUtil.largestPalindrome(str) + "\"");
            Console.ReadKey();
        }
    }
    public static class PalindromeUtil
    {
        // work with double letters first, find the locations
        // check around each one for more palindrome letters
        // afterwards look for patterns like ete (single letter in middle); 
        // then with those search the letters around them
        public static string largestPalindrome(string str)
        {
            if (str.Length < 2) { return str; }
            str = str.ToLower();

            // The Tuple represents startIdx, length
            int idxLargestPalindromeStart = 0;
            int largestPalindromeSize = 1;
            // DOUBLE LETTER CENTER
            for (var i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    for (var j = 1; ; j++)
                    {
                        // check for out of bound exception
                        if (i + j >= str.Length || i - 1 - j < 0)
                        {
                            // check if largest palindrome so far
                            if (2 * j > largestPalindromeSize)
                            {
                                largestPalindromeSize = 2 * j;
                                idxLargestPalindromeStart = i - j;
                            }
                            break;
                        }
                        // Can't combine these because of out of bound exception
                        if (str[i + j] != str[i - 1 - j])
                        {
                            // check if largest palindrome so far
                            if (2 * j > largestPalindromeSize)
                            {
                                largestPalindromeSize = 2 * j;
                                idxLargestPalindromeStart = i - j;
                            }
                            break;
                        }
                        // Do nothing here
                    }
                }
            }

            // SINGLE LETTER CENTER
            for (var i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == str[i + 2])
                {
                    for (var j = 1; ; j++)
                    {
                        // check for out of bound exception
                        if (i + 2 + j >= str.Length || i - j < 0)
                        {
                            // check if largest palindrome so far
                            if (1 + 2 * j > largestPalindromeSize)
                            {
                                largestPalindromeSize = 1 + 2 * j;
                                idxLargestPalindromeStart = i + 1 - j;
                            }
                            break;
                        }
                        // Can't combine these because of out of bound exception
                        if (str[i + 2 + j] != str[i - j])
                        {
                            // check if largest palindrome so far
                            if (1 + 2 * j > largestPalindromeSize)
                            {
                                largestPalindromeSize = 1 + 2 * j;
                                idxLargestPalindromeStart = i + 1 - j;
                            }
                            break;
                        }
                        // Do nothing here
                    }
                }
            }
            return str.Substring(idxLargestPalindromeStart,largestPalindromeSize);
        }
    }

}
