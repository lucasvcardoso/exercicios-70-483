using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    public static class Example1_9
    {
        public static void TMain()
        {
            //Using the Task<T> class, we can create a Task that returns a value.
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            //We use the Result property of the Task to read the value returned.
            //Attempting to read the Result on a Task will force the thread that's trying to read the result
            //to wait until the Task is finished before continuing. As long as the Task has not finished, it is
            //impossible to give the result. If the Task if not finished, this call will block the current thread.
            Console.WriteLine(t.Result);//Displays 42
            Console.ReadLine();
        }

    }
}
