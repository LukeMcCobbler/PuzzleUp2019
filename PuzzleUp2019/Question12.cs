using System;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question12
    {
        public Question12()
        {
        }

        internal void Run()
        {
            var digits=Enumerable.Range(0,10).ToArray();
            var cmb=new Combinatorics();
            var maxSol=0L;
            cmb.GeneratePermutations(digits,10,arr=>{
                var number=new string(arr.Select(c=>(char)('0'+c) ).ToArray());
                var check=true;
                for(var i=0;i<arr.Length-1;i++)
                {
                    var neighborSum=(arr[i]+arr[i+1]).ToString();
                    if(!number.Contains(neighborSum) )
                    {
                        check=false;
                        break;
                    }
                }
                if(check)
                {
                    var sol=Int64.Parse(number);
                    if(sol>maxSol)
                    {
                        maxSol=sol;
                    }
                }
            },(candidate,countSoFar,partialSolution)=>{
                return countSoFar>0||candidate!=0;
            } );
            Console.WriteLine(maxSol);
            return;
        }
    }
}