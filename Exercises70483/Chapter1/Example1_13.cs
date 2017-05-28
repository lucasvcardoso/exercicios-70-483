using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    /// <summary>
    /// In the previous example, we had to create three Tasks all with the
    /// same options. To make the process easier, we can use a TaskFactory.
    /// A TaskFactory is created with a certain configuration and can then
    /// be used to create Tasks with that configuration.
    /// </summary>
    public static class Example1_13
    {
        public static void TMain()
        {
            Task<Int32[]> parent = Task.Run(()=>
            {
                var results = new Int32[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

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
