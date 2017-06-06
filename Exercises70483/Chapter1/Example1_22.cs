using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// How to convert a query to a parallel query.
    /// The runtime determines whether it makes sense to turn
    /// your query into a parallel one. When doing this, it generates
    /// Task objexts and starts executing them. If you want to force PLINQ into 
    /// a parallel query, you can use the WithExecutionMode() method and specify
    /// that it should always execute the query in parallel.
    /// You can also limit the amount of parallelism that is used with the 
    /// WithDegreeOfParallelism() method. You pass that method an integer that 
    /// represents the number of processors that you want to use.
    /// </summary>
    class Example1_22
    {
        void ParallelQuery()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
        }
    }
}
