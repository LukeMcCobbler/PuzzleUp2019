using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question11
    {
        public Question11()
        {
        }
        private struct coord:IComparable
        {
            public int x;
            public int y;
            public coord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int CompareTo(object obj)
            {
                var target = (coord)obj;
                return y.CompareTo(target.y) == 0 ? x.CompareTo(target.x) : y.CompareTo(target.y);
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return String.Format("{0},{1}", x, y);
            }
        }
        internal void Run()
        {
            var boardSize = 4;
            var squares = Enumerable.Range(0, boardSize * boardSize).Select(ordinal => getCoord(ordinal, boardSize)).ToArray();
            var cmb = new Combinatorics();
            var solutions = new List<coord[]>();
            cmb.GenerateCombinations(squares, 8, result => solutions.Add(result.ToArray()), (candidate, countSoFar, partialSolution) => checkCandidate(candidate,partialSolution.Take(countSoFar).ToArray() ));
            foreach(var solution in solutions)
            {
                printSolution(solution, boardSize);
                Console.WriteLine("----");
            }
            return;
        }

        private void printSolution(coord[] solution, int boardSize)
        {
            var checker = new HashSet<coord>(solution);
            for(var row=0;row<boardSize;row++)
            {
                for(var col=0;col<boardSize;col++)
                {
                    Console.Write(checker.Contains(new coord(col, row)) ? "o" : ".");
                }
                Console.WriteLine();
            }
        }

        private bool checkCandidate(coord candidateQueen, coord[] existingQueens)
        {
            if(existingQueens.Where(exist=>exist.x==candidateQueen.x).Count()>1)
            {
                return false;
            }
            if (existingQueens.Where(exist => exist.y == candidateQueen.y).Count() > 1)
            {
                return false;
            }
            if (existingQueens.Where(exist => exist.y+exist.x == candidateQueen.y+candidateQueen.x).Count() > 1)
            {
                return false;
            }
            if (existingQueens.Where(exist => exist.y - exist.x == candidateQueen.y - candidateQueen.x).Count() > 1)
            {
                return false;
            }

            return true;

        }

        private coord getCoord(int ordinal, int boardSize)
        {
            var col = ordinal % boardSize;
            var row = (ordinal - col) / boardSize;
            return new coord(col, row);
        }
    }
}