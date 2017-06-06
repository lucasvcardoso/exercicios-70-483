using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// One thing to keep in mind is that parallel processing does 
    /// not guarantee any particular order. This shows what can happen:
    /// </summary>
    class Example1_23
    {
        public static void PMain()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach(int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
