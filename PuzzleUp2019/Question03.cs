using System;
using System.Linq;
using System.Collections.Generic;

namespace PuzzleUp2019
{
    internal class Question03
    {
        public Question03()
        {
        }
        private Dictionary<int, int> rotDigits = new Dictionary<int, int>() { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 5, 5 }, { 6, 9 }, { 8, 8 }, { 9, 6 } };

        private List<int> getReverse(List<int> source)
        {
            var retval = Enumerable.Range(0, source.Count).Select(ord => rotDigits[source[source.Count - 1 - ord]]).ToList();
            return retval;
        }
        private long asNumber(IEnumerable<int> source)
        {
            var retval = Int64.Parse(string.Join("", source.Select(digit => digit.ToString())));
            return retval;
        }
        private bool isRotational(long source)
        {
            if(source<0)
             {
                 return false;
             }
            var rep = source.ToString();
            var retval = rep.All(chr => rotDigits.ContainsKey(Int32.Parse(chr.ToString())));
            return retval;
        }
        internal void Run()
        {
            var allDistinctRots = new List<List<int>>();
            new Combinatorics().GenerateCombinations(rotDigits.Keys.ToArray(), 7, partialSolution => { return; },
            (item, partialSolLength, partialSol) =>
            {
                if (partialSolLength > 0 && !partialSol.Take(partialSolLength).Any(dgt => dgt == item))
                {
                    var lng = partialSol.Take(partialSolLength).Concat(new int[] { item }).ToList();
                    allDistinctRots.Add(lng);
                }
                return partialSolLength > 1 || item != 0;
            }
             );
             var longs=allDistinctRots.Select(seq=>asNumber(seq) ).ToList();
            var x = allDistinctRots.Where(lng =>isRotational(asNumber(lng) - asNumber(getReverse(lng))) ).Select(lng=>asNumber(lng)).ToList();
            var check=longs.Contains(9862501);

            return;
        }
    }
}