using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// We can use the method AsOrdered() to buffer
    /// and order the results of the query.
    /// </summary>
    class Example1_24
    {
        public static void PMain()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();


            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
