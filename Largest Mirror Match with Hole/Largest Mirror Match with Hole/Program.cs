using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Mirror_Match_with_Hole
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "testabcdtset";
            Console.WriteLine(MirrorStringUtil.largestMirrorMatchWithHole(str));
            Console.ReadKey();
        }
    }

    public static class MirrorStringUtil
    {
        // Reverse the string
        // compare the two strings index by index
        // find the longest chain of indices matching
        // return the string of those indices
        public static string largestMirrorMatchWithHole(string str)
        {
            if (str.Length <= 1) { return str; }
            str = str.ToLower();
            IEnumerable<char> reverseStr = str.Reverse();
            int idxLongestChainMatching = 0;
            int longestChain = 1;
            int currentChainLength = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == reverseStr.ElementAt(i))
                {
                    currentChainLength++;
                }
                else
                {
                    if (currentChainLength > longestChain)
                    {
                        longestChain = currentChainLength;
                        idxLongestChainMatching = i - currentChainLength;
                    }
                    currentChainLength = 0;
                } // jaspsaj
            }
            if (currentChainLength > longestChain)
            {
                longestChain = currentChainLength;
                idxLongestChainMatching = str.Length - currentChainLength;
            }
            return str.Substring(idxLongestChainMatching, longestChain);
        }
    }
}
