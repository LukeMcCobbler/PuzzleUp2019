using System;
using System.Collections.Generic;

namespace PuzzleUp2019
{
    internal class Question02
    {
        public Question02()
        {
        }

        internal void Run()
        {
            var memo=new Dictionary<int,int>(){{1,0}};
            var x=getCoinCost(100,memo);
            Console.WriteLine(x);
        }

        private int getCoinCost(int totalCoins,Dictionary<int,int> memo) 
        { 
            if(memo.ContainsKey(totalCoins) )
            {
                return memo[totalCoins];
            }
            int bestCost=Int32.MaxValue;
            int bestShow=0;
            int bestHide=0;
            for(int showCount=1;showCount<totalCoins;showCount++)
            {
                var hideCount=totalCoins-showCount;
                var partitionCost=Math.Max(3+getCoinCost(showCount,memo),2+getCoinCost(hideCount,memo)  );
                if(partitionCost<bestCost)
                {
                    bestHide=hideCount;
                    bestCost=partitionCost;
                    bestShow=showCount;
                }
            }
            memo[totalCoins]=bestCost;
            Console.WriteLine("Best way to split {0} coins is to show {1} and hide {2} and it costs ${3}",totalCoins,bestShow,bestHide,bestCost);
            return bestCost;
        }
    }
}