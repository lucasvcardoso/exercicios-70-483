using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    /// <summary>
    /// The ContinueWith() method has a couple of overloads that you 
    /// can use to configure when the continuation will run. This way
    /// you can add different continuation methods that will run when an
    /// exception happens, the Task is canceled, or the Task completes
    /// successfully. This example shows how to do this.
    /// </summary>
    public static class Example1_11
    {
        public static void TMain()
        {
            Task t = Task.Run(()=>
            {
                return 42;
            });

            t.ContinueWith((firstTask)=>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((firstTask) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((fisrtTask) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
            Console.ReadKey();
        }
    }
}
