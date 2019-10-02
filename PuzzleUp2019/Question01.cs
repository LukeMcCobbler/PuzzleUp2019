using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question01
    {
        public Question01()
        {
        }
        private static int AChar = 'A';

        private static bool checkWrongEnvelope(char item, int position, char[] partial)
        {
            return position <1 || partial[0]!=item;
        }
        private static bool checkEnvelopePosition(string item, int position, string[] partial)
        {
            if (item[0] != (char)AChar + position)
            {
                return false;
            }
            var doubleUse = partial.Take(position).Any(partialElement => partialElement[1] == item[1] || partialElement[2] == item[2]);
            return !doubleUse;
        }
        internal void Run()
        {
                        int counter=0;
            var c = new Combinatorics();
            int letterCount=7;
            var letters=Enumerable.Range(0,letterCount).Select(offset=>(char)(AChar+offset)).ToArray();
            
            var envelopments = new List<string>();
            c.GenerateAllTuples(letters, 3, tuple =>
            {
                var x = new string(tuple);
                envelopments.Add(x);
            }, checkWrongEnvelope);
            //Console.WriteLine(String.Join("\r\n", envelopments));
            c.GeneratePermutations(envelopments.ToArray(), letterCount, tuple =>
            {
                var y = string.Join(",", tuple);
                //Console.WriteLine(y);
                counter++;
                Debug .Assert(counter<=3437316);
            }, checkEnvelopePosition);
            Console.WriteLine(counter);

        }
    }
}