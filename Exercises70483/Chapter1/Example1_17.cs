using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter1.ParallelClass
{
    /// <summary>
    /// We can cancel the loop by using the ParallelLoopState object. We
    /// have two options to do this: Break or Stop. Break ensures that all 
    /// iterations that are currently running will be finished. Stop just 
    /// terminates everything.
    /// When breaking the parallel loop, the result variable has an IsCompleted value of False
    /// and a LowestBreakIteration of 500, in this example. When using the Stop() method,
    /// the LowestBreakIteration if null.
    /// </summary>
    public static class Example1_17
    {
        public static void PMain()
        {
            ParallelLoopResult result = Parallel.
                For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking Loop");
                        loopState.Break();
                        //loopState.Stop();
                    }
                    return;
                });
            Console.WriteLine("IsCompleted: {0}", result.IsCompleted);
            Console.WriteLine("LowestBreakIteration: {0}", result.LowestBreakIteration);
            Console.ReadKey();
        }
    }
}
