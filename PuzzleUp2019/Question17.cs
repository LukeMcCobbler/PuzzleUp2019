using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question17
    {
        private class pawnPlacement
        {
            public int placement { get; set; }
            public bool[] bitMap { get; set; }
            public string representation { get; set; }
        }
        public Question17()
        {
        }

        internal void Run()
        {
            var solutions=new List<string>();
            int boardSize = 5;
            var rowPlacements = new int[] { 1, 2, 19, 4, 21, 22, 7, 8, 25, 26, 11, 28, 13, 14, 31, 16 };
            //var rowPlacements = new int[] { 8,1, 2, 11, 4, 13, 14, 7};
            //var rowPlacements = new int[] { 1, 2, 4, 7};
            var pawnPlacements = rowPlacements.Select(encoded => new pawnPlacement()
            {
                placement = encoded,
                bitMap = getBitmap(encoded, boardSize),
                representation = writeOut(getBitmap(encoded, boardSize))
            }).ToDictionary(pp=>pp.placement,pp=>pp);
            var cmb=new Combinatorics();
            cmb.GenerateAllTuples(rowPlacements,boardSize,partialSol=>{
                if(columnCheck(partialSol,boardSize,pawnPlacements))
                {
                    var board=string.Join("\n",partialSol.Select(row=>pawnPlacements[row].representation) );
                    solutions.Add(board);
                    Console.WriteLine(board);
                }
            },(x,y,z)=>true);

            return;
        }

        private bool columnCheck(int[] partialSol, int boardSize, Dictionary<int, pawnPlacement> pawnPlacements)
        {
            for(var cursor=0;cursor<boardSize;cursor++)
            {
                var pawnCount=partialSol.Select(row=>pawnPlacements[row].bitMap[cursor]).Count(c=>c);
                if(pawnCount%2==0)
                {
                    return false;
                }
            }
            return true;
        }

        private string writeOut(bool[] bitMap)
        {
            return string.Join("", bitMap.Select(bit => bit ? "1" : "0"));
        }

        private bool[] getBitmap(int encoded, int fieldSize)
        {
            var retval = Enumerable.Range(0, fieldSize).Select(pos => ((encoded >> pos) % 2) != 0).ToArray();
            return retval;
        }
    }
}