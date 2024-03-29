using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Combinatorics
    {
        public Combinatorics()
        {
        }

        public void GenerateAllTuples<T>(T[] alphabet, int tupleLength, Action<T[]> onTupleDone, Func<T, int, T[], bool> itemAddCheck) where T : IComparable
        {
            recurseTupleBuild(new T[tupleLength], 0, alphabet, tupleLength, onTupleDone, new Dictionary<T, bool>(), true, false, itemAddCheck);
        }
        internal void GeneratePermutations<T>(T[] items, int comboLength, Action<T[]> onCombinationFound, Func<T, int, T[], bool> itemAddCheck) where T : IComparable
        {
            recurseTupleBuild(new T[comboLength], 0, items, comboLength, onCombinationFound, items.ToDictionary(itm => itm, itm => false), false, false, itemAddCheck);
        }
        internal void GenerateCombinations<T>(T[] items, int comboLength, Action<T[]> onCombinationFound, Func<T, int, T[], bool> itemAddCheck) where T : IComparable
        {
            recurseTupleBuild(new T[comboLength], 0, items, comboLength, onCombinationFound, items.ToDictionary(itm => itm, itm => false), false, true, itemAddCheck);
        }
        private void recurseTupleBuild<T>(T[] workArea, int currentLength, T[] alphabet, int tupleLength, Action<T[]> onTupleDone, Dictionary<T, bool> usage, bool allowRepetition, bool enforceAscendingOrder, Func<T, int, T[], bool> itemAddCheck) where T : IComparable
        {
            if (currentLength == tupleLength)
            {
                onTupleDone(workArea);
            }
            else
            {
                foreach (var item in alphabet.Where(itm => currentLength == 0 || !enforceAscendingOrder || itm.CompareTo(workArea[currentLength - 1]) > 0).Where(itm => allowRepetition || !usage[itm]).Where(itm => itemAddCheck(itm, currentLength, workArea)))
                {
                    workArea[currentLength] = item;
                    usage[item] = true;
                    recurseTupleBuild(workArea, currentLength + 1, alphabet, tupleLength, onTupleDone, usage, allowRepetition, enforceAscendingOrder, itemAddCheck);
                    usage[item] = false;
                }
            }
        }
    }
}