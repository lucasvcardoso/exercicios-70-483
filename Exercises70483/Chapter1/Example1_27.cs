using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// When some operation in the parallel query throws an Exception
    /// the .NET Framework handles this by aggregating all exception into
    /// one AggregateException. This exception exposes a list of all exceptions
    /// that have happened during parallel execution.
    /// We can inspect those exceptions by looping through the InnerExceptions 
    /// property.
    /// </summary>
    class Example1_27
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel()
                    .Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
                Console.ReadKey();
            }
            catch(AggregateException e)
            {
                Console.WriteLine("There were {0} exceptions", e.InnerExceptions.Count);
                Console.ReadKey();
            }            
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }
}
