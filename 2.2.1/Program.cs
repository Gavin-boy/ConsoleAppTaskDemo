using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //创建一个任务
            Task<int> task = new Task<int>(() =>
              {
                  int sum = 0;
                  Console.WriteLine("使用Task执行异步操作");
                  for (int i = 0; i < 100; i++)
                  {
                      sum += i;
                  }
                  return sum;
              });
            //启动任务，并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其她处理");
            //任务完成时执行处理
            Task cwt = task.ContinueWith(t =>
            {
                task.Start();
                Console.WriteLine("任务完成后的执行结果：{0}", t.Result.ToString());
            });
            task.Wait();
            cwt.Wait();
        }
    }
}
