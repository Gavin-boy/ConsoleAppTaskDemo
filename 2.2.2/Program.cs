using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            //t1先串行
            var t1 = Task.Factory.StartNew(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });

            //t2,t3并行执行
            var t2 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
                Console.WriteLine("Task 2 result={0},Thread id {1}",result,Thread.CurrentThread.ManagedThreadId);
            });

            //t2,t3并行执行 
            var t3 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
                Console.WriteLine("Task 3 result={0},Thread id {1}",result,Thread.CurrentThread.ManagedThreadId);
            });

            //等待t2和t3执行完
            Task.WaitAll(t2, t3);

            //t4串行执行
            var t4 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("当前集合元素个数：{0},Thread id {1}",stack.Count,Thread.CurrentThread.ManagedThreadId);
            });
            t4.Wait();
            Console.ReadLine();
        }
    }
}
