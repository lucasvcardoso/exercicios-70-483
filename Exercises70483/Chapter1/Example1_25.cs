using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.ParallelLinq
{
    /// <summary>
    /// If we have a complex query that can benefit from parallel
    /// processing but also has some parts that should be done sequentially,
    /// we can use the AsSequential() method to stop the query
    /// from being procesed in parallel.
    /// One scenario where this is required is to preserve the ORDERING
    /// of the results.
    /// Obs.: the example from the book is horrible and hard to understand,
    /// so I'll add an example from MSDN to this class.
    /// </summary>
    class Example1_25
    {
        public static void PMain()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();
         
            foreach (int i in parallelResult.Take(5))//After some research, I've discovered that the Take() method can mess up
                                                     //the ordering of the results, so the AsSequential() was used in the book,
                                                     //but Take() only messes with the ordering if the results are in their original
                                                     //indexes.
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This is the example from MSDN.
        /// In this example we can see clearly how AsSequential()
        /// could be used to keep the ORDERING of the results,
        /// and keep Take() from messing them all up.
        /// </summary>
        void SequentialDemo()
        {
            /*
             var orders = GetOrders();
             var query = (from ord in orders.AsParallel()
                          orderby ord.CustomerID
                          select new
                          {
                            Details = ord.OrderID,
                            Date = ord.OrderDate,
                            Shipped = ord.ShippedDate
                          }).
                                AsSequential().Take(5);
             */           
        }
    
    }
}
