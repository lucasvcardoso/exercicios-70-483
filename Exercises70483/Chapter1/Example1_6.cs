using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// Using the <i>ThreadLocal<T></i> class/>
    /// </summary>
    class Example1_6
    {
        //In this example the ThreadLocal<T> type is used to create a global field
        //that can be initialized in each thread that it is used separately
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                //Thread.CurrentThread can be used to get many information from the current thread,
                //like de Current Culture (CultureInfo: currency, date formats, time formats, number formats, etc.),
                //principal (current secutiry context), priority, and other info.
                return Thread.CurrentThread.ManagedThreadId;
            });
        public static void TMain()
        {
            //When a new thread is created, the runtime ensures that the initiaing thread's execution context is flowed to the new thread.
            //This way the new thread has the same privileges as the parent thread.
            //The ExecutionContext.SuppressFlow() method can be used to disable this behavior, saving system resources in the thread creation.
            new Thread(() =>
                {
                    Console.WriteLine("Value for A: {0}", _field.Value);
                    for (int x = 0; x < _field.Value; x++)
                    {
                        Console.WriteLine("Thread A: {0}", x);
                    }
                }
            ).Start();

            new Thread(() =>
                {
                    Console.WriteLine("Value for B: {0}", _field.Value);
                    for (int x = 0; x < _field.Value; x++)
                    {
                        Console.WriteLine("Thread B: {0}", x);
                    }
                }
            ).Start();

            Console.ReadKey();
        }
    }
}
