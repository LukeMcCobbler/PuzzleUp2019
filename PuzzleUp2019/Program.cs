using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Combinatorics();
            var envelopments = new List<string>();
            c.GenerateCombinations(new char[] { 'A', 'B', 'C' }, 3, tuple =>
            {
                var x = new string(tuple);
                envelopments.Add(x);
            },(item,count,partial)=>true);
            //Console.WriteLine(String.Join("\r\n", envelopments));
            c.GenerateCombinations(envelopments.ToArray(), 3, tuple =>
            {
                var y = string.Join(",",tuple );
                Console.WriteLine(y);
            },checkEnvelopePosition);
            return;
        }
        private static int AChar='A';

        private static bool checkEnvelopePosition(string item, int position, string[] partial)
        {
            if ( item[0]!= (char) AChar+position)
            {
                return false;
            }
            var doubleUse=partial.Take(position).Any(partialElement=>partialElement[1]==item[1] || partialElement[2]==item[2] );
            return !doubleUse;
        }
    }
}
