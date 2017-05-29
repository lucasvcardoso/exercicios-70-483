using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1.ParallelClass
{
    /// <summary>
    /// The methods Parallel.For() and Parallel.ForEach() make the iterations paralelized.
    /// </summary>
    public static class Example1_16
    {
        public static void PMain()
        {
            Parallel.For(0, 10, i => 
            {
                Thread.Sleep(1000);
            });

            //The method Enumerable.Range() generates an interval of integer numbers
            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers,i =>
            {
                Thread.Sleep(1000);
            });

        }
    }
}
