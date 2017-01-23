using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    class Example1_7
    {
        /// <summary>
        /// Queueing some work to the thread pool
        /// </summary>
        public static void Main()
        {
            //Because the thread pool limits the available number of threads, we do get a lesser degree of 
            //parallelism than using the regular Thread class.
            //It is important to note that when a thread is reused, it also reuses its local state. We may not rely on state that can potentially
            //be shared between multiple operations.
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }
    }
}
