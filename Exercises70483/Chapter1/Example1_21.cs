using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.AsyncAwait
{
    /// <summary>
    /// Continuing on a thread pool instead of the UI thread.
    /// Both awaits use the ConfigurAwait(false) method because
    /// if the first method is already finished before the awaiter
    /// checks, the second method still runs on the UI thread.
    /// </summary>
    public class Example1_21
    {
        private async void Button_Click(object sender, object routedEventArgs)
        {
            HttpClient httpClient = new HttpClient();

            string content = await httpClient
                .GetStringAsync("http://www.microsoft.com")
                .ConfigureAwait(false);

            using (FileStream sourceStream = new FileStream("temp.html",
                FileMode.Create, FileAccess.Write, FileShare.None,
                4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                    .ConfigureAwait(false);
            }
        }
    }
}
