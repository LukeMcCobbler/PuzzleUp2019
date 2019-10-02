using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question04
    {
        public Question04()
        {
        }

        internal void Run()
        {
            //ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE
            var vowelStarters = new HashSet<int>() { 1, 8 };
            var consonantEnders = new HashSet<int>() { 4, 6, 7, 8 };
            var digits = Enumerable.Range(0, 10).ToArray();
            var results = new List<int>();
            new Combinatorics().GeneratePermutations(digits, 10, result => { return; }, (addCandidate, position, partialSolution) =>
                   {
                       var candidate = new int[] { addCandidate };
                       if (position >= 2 && !checkVowelStarters(partialSolution.Skip(position - 2).Take(2).Concat(candidate), vowelStarters))
                       {
                           return false;
                       }
                       if (position >= 1 && !checkConsonantEnders(partialSolution.Skip(position - 1).Take(1).Concat(candidate), consonantEnders))
                       {
                           return false;
                       }
                       var retval = position > 0 || addCandidate != 0;
                       if (retval)
                       {
                           var writeOut = string.Join("", partialSolution.Take(position).Concat(candidate).Select(c => c.ToString()));
                           //Console.WriteLine(writeOut);
                           results.Add(Int32.Parse(writeOut));
                       }
                       return retval;
                   });
            Console.WriteLine(results.Max());
        }

        private bool checkConsonantEnders(IEnumerable<int> enumerable, HashSet<int> consonantEnders)
        {
            return enumerable.Where(i => consonantEnders.Contains(i)).Count() == 1;
        }

        private bool checkVowelStarters(IEnumerable<int> enumerable, HashSet<int> vowelStarters)
        {
            return enumerable.Where(i => vowelStarters.Contains(i)).Count() == 1;
        }
    }
}