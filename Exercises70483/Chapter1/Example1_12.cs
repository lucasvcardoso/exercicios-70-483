using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    /// <summary>
    /// Next to continuation Tasks, a Task can also have several child Tasks.
    /// The parent Task finishes when all the child tasks are ready.
    /// </summary>
    public static class Example1_12
    {
        public static void TMain()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine(i);
                    }
                });
            finalTask.Wait();
            Console.ReadKey();
        }
    }
}
