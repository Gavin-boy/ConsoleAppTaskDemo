using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._7._1
{
    class Program
    {
        private delegate string AsynchronousTask(string threadName);

        private static string Test(string threadName)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Is thread pool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Thread.CurrentThread.Name = threadName;
            return string.Format("Thread name: {0}", Thread.CurrentThread.Name);
        }

        private static void Callback(IAsyncResult ar)
        {
            Console.WriteLine("Starting a callback...");
            Console.WriteLine("State passed to a callbak: {0}", ar.AsyncState);
            Console.WriteLine("Is thread pool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Thread pool worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        //执行的流程是 先执行Test--->Callback--->task.ContinueWith
        static void Main(string[] args)
        {
            AsynchronousTask d = Test;
            Console.WriteLine("Option 1");
            Task<string> task = Task<string>.Factory.FromAsync(
                d.BeginInvoke("AsyncTaskThread", Callback, "a delegate asynchronous call"), d.EndInvoke);

            task.ContinueWith(t => Console.WriteLine("Callback is finished, now running a continuation! Result: {0}",
                t.Result));

            while (!task.IsCompleted)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine(task.Status);
            Console.ReadKey();
        }
    }
}
