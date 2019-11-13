using System;
using System.Linq;

namespace PuzzleUp2019
{
    internal class Question13
    {
        public Question13()
        {
        }
        internal void Run()
        {
            var alphabet=new char[]{'A','B'};
            var cmb=new Combinatorics();
            for(int i=3;i<32;i++)
            {
                var win=0;
                var lose=0;
                var undecided=0;
                cmb.GenerateAllTuples(alphabet,i,prt=>{
                    var str=new string(prt);
                    var firstABA=str.IndexOf("ABA");                    
                    var firstBABA=str.IndexOf("BABA");
                    if(firstABA<0&&firstBABA<0)
                    {
                        undecided++;
                    }
                    else
                    {
                        if(firstABA>=0 && (firstBABA<0||firstABA<firstBABA) )
                        {
                            win++;
                        }
                        else
                        {
                            lose++;
                        }
                    }
                    
                    return;
                },(x,y,z)=>true);
                Console.WriteLine("W:{0} L:{1} U:{2} T:{3}",win,lose,undecided,win+lose+undecided);
            }
        }
        internal void AltRun()
        {
            double count=0.0;
            double win=0.0;
            var rand=new Random();
            while(true)
            {
                var letters=Enumerable.Range(0,65536*16).Select(c=>rand.NextDouble()<0.5?'A':'B').ToArray();
                var book=new string(letters);
                var firstABA=book.IndexOf("ABA");
                var firstBABA=book.IndexOf("BABA");
                if(firstABA>=0&&firstBABA>=0)
                {
                    count++;
                    if(firstBABA>firstABA)
                    {
                        win++;
                    }

                }
                Console.WriteLine(win/count);
            }
        }
    }
}