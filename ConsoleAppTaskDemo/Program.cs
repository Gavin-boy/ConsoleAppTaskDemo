using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(() =>
              {
                  Console.WriteLine("任务开始工作......");
                //模拟工作过程
                Thread.Sleep(3000);
              });
            t.Start();
            t.ContinueWith((task) =>
            {
                Console.WriteLine("任务完成，完成时的状态为：");
                Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
            });
            Console.ReadKey();
        }
    }
}
