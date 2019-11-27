using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question19
    {
        private List<char[]> scores;
        public Question19()
        {
            scores = new List<char[]>();
        }

        internal void Run()
        {
            var alphabet = new char[] { 'A', 'B' };
            var cmb = new Combinatorics();
            int neverLostCount=0;
            cmb.GenerateAllTuples(alphabet, 14, registerScore, (canddidate, count, partialSolution) => true);
            foreach (var score in scores)
            {
                var neverLost = testLoss(score);
                if(neverLost)
                {
                    neverLostCount++;
                    
                }
                Console.WriteLine("{0}:{1}", new string(score),neverLost?"GOOD":"BAD");
            }
            return;
        }

        private bool testLoss(char[] score)
        {
            var counts = new int[2];

            for (var cursor = 0; cursor < score.Length; cursor++)
            {
                counts[score[cursor] == 'A' ? 0 : 1]++;
                if (counts[0] < counts[1])
                {
                    return false;
                }
            }
            return true;
        }

        private void registerScore(char[] scoreArray)
        {
            if (scoreArray.Count(chr => chr == 'A') == 9)
            {
                scores.Add(scoreArray.ToArray());
            }
            //var writeOut=new string(scoreArray);
            //Console.WriteLine(writeOut);
            return;
        }
    }
}