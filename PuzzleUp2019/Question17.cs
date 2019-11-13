using System;
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
            int boardSize = 5;
            var rowPlacements = new int[] { 1, 2, 19, 4, 21, 22, 7, 8, 25, 26, 11, 28, 13, 14, 31, 16 };
            var pawnPlacements = rowPlacements.Select(encoded => new pawnPlacement()
            {
                placement = encoded,
                bitMap = getBitmap(encoded, boardSize),
                representation = writeOut(getBitmap(encoded, boardSize))
            }).ToList();

            return;
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