using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1.AsyncAwait
{
    /// <summary>
    /// Scalability versus responsiveness.
    /// The SleepAsyncA method uses a thread from the thread pool while sleeping.
    /// The second method, however, which has a ocmpletely different implementation,
    /// does not occupy a thread while waiting for the timer to run. The second method gives us scalability.
    /// </summary>
    public static class Example1_19
    {
        public static Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public static Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}
