using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question10
    {
        public Question10()
        {
        }
        private struct weigh
        {
            public char left { get; set; }
            public char right { get; set; }
            public weigh(char l, char r)
            {
                left = l;
                right = r;
            }
        }
        internal void Run()
        {
            var ballcount = 12;
            var targetInfo = (ballcount * (ballcount - 1)) / 2;
            var balls = Enumerable.Range(0, ballcount).Select(chrOffset => (char)('a' + chrOffset)).ToArray();
            var cmb = new Combinatorics();
            var picks = new Dictionary<string, char[]>();
            cmb.GenerateCombinations(balls, 4, result =>
            {
                var str = new string(result);
                picks[str] = result.Take(4).ToArray() ;
                }, (candidate, count, partialResult) => true);
            var knownInfo = new HashSet<weigh>();
            var counter = 1;
            while (knownInfo.Count < targetInfo)
            {
                var weighInfos = picks.ToDictionary(kvp => kvp.Key, kvp => getRevealedInfo(kvp.Value, knownInfo));
                var bestWeigh = picks[weighInfos.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key];
                markBestWeigh(bestWeigh, knownInfo);
                Console.WriteLine("{0}-{1}", counter, new string(bestWeigh));
                    counter++;
            }
            return;
        }

        private void markBestWeigh(char[] balls, HashSet<weigh> knownInfo)
        {
            for (int i = 0; i < balls.Length - 1; i++)
            {
                for (int j = i + 1; j < balls.Length; j++)
                {
                    knownInfo.Add(new weigh(balls[i], balls[j]));                    
                }
            }
        }
        private int getRevealedInfo(char[] balls, HashSet<weigh> knownInfo)
        {
            var result = 0;
            for(int i=0;i<balls.Length-1;i++)
            {
                for(int j=i+1;j<balls.Length;j++)
                {
                    if(!knownInfo.Contains( new weigh(balls[i],balls[j]) ))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}