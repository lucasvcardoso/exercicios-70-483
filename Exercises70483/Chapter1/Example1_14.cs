using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    /// <summary>
    /// Next to calling Wait on a single Task, you can also use the method WaitAll() to wait
    /// for multiple Tasks to finish before continuing execution.
    /// Next to WaitAll(), we also have a WhenAll() method that we can use to schedule
    /// a continuation mehtod after all Tasks have finished.
    /// </summary>
    public static class Example1_14
    {
        public static void TMain()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
            Console.ReadKey();


        }
    }
}
