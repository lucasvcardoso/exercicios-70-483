using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// When using PLINQ, we can use the ForAll() operator
    /// to iterate over a collection when the iteration can also
    /// be done in a parallel way.
    /// In contrast to foreach, ForAll() doesn't need all results
    /// before it starts executing. In this example, ForAll() does,
    /// however, remove any sort order that is specified.
    /// </summary>
    class Example1_26
    {
        void UsingForAll()
        {
            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));
        }
    }
}
