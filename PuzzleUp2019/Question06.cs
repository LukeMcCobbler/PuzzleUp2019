using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question06
    {
        public Question06()
        {
        }

        internal void Run()
        {
            int n = 32;
            var memo = new Dictionary<ulong, int>() { { 0, 1 } };
            //var cmb = new Combinatorics();
            //var alphabet = new char[] { 'a', 'b' };
            //var tuples = new List<string>();
            //cmb.GenerateAllTuples(alphabet, n, chars => {
            //    tuples.Add(new string(chars));
            //}, (candidate, count, partialSolution) => true);
            ulong count = Enumerable.Range(1, n).Aggregate<int, ulong>(1UL, (av, c) => av * 2);
            var max = 0;
            for (ulong cursor = 0; cursor < count; cursor++)
            {
                var sessionCount = getSessionCount(cursor, memo, n);
                if (max<sessionCount)
                {
                    max = sessionCount;
                }
            }
            //var x = Enumerable.Range(0, (UInt32)Math.Pow(2,n)).ToList();//.Select(initial => getSessionCount(initial, memo)).Max();
            return;
        }
        private int getSessionCount(ulong current, Dictionary<ulong, int> memo, int length)
        {
            if (memo.ContainsKey(current))
            {
                return memo[current];
            }
            else
            {
                var result = getSessionCount(runNextStep(current, length), memo, length) + 1;
                memo[current] = result;
                return result;
            }
        }

        private ulong runNextStep(ulong current, int length)
        {
            throw new NotImplementedException();
        }
    }
}