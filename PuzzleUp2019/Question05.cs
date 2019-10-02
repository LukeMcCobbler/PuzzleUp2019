using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question05
    {
        public Question05()
        {
        }

        internal void Run()
        {
            List<int[]> combos = new List<int[]>();
            var cmb = new Combinatorics();
            var numbers = Enumerable.Range(1, 20).ToArray();
            cmb.GenerateCombinations(numbers, 9, combo =>
            {
                if (combo.Sum() == 51)
                {
                    combos.Add(combo.ToArray());
                }
            }, (itm, idx, partialCombo) => true);
            foreach (var combo in combos)
            {
                cmb.GeneratePermutations(combo, 9, result =>
                 {
                     return;
                 }
                , (candidate, position, partialSolution) =>
                 checkForSquareMagicSquare(candidate, position, partialSolution));
            }
            return;
        }
        HashSet<int> squares = new HashSet<int>() { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };
        private bool checkForSquareMagicSquare(int candidate, int position, int[] partialSolution)
        {
            if (position == 2 && !squares.Contains(partialSolution[0] + partialSolution[1] + candidate))
            {
                return false;
            }
            if(position==5 && !squares.Contains(partialSolution[3] + partialSolution[4] + candidate))
            {
                return false;
            }
            if (position == 6 && !squares.Contains(partialSolution[0] + partialSolution[3] + candidate))
            {
                return false;
            }
            if (position == 6 && !squares.Contains(partialSolution[2] + partialSolution[4] + candidate))
            {
                return false;
            }
            if (position == 7 && !squares.Contains(partialSolution[1] + partialSolution[4] + candidate))
            {
                return false;
            }
            if (position == 8 && !squares.Contains(partialSolution[2] + partialSolution[5] + candidate))
            {
                return false;
            }
            if (position == 8 && !squares.Contains(partialSolution[0] + partialSolution[4] + candidate))
            {
                return false;
            }
            if (position == 8 && !squares.Contains(partialSolution[6] + partialSolution[7] + candidate))
            {
                return false;
            }

            return true;
        }
    }
}