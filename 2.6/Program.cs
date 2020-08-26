﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace _2._6
{
    class Program
    {
        static void DoProcessing(IProgress<int> progress)
        {
            for (int i = 0; i <= 100; ++i)
            {
                Thread.Sleep(100);
                if (progress != null)
                {
                    progress.Report(i);
                }
            }
        }

        static async Task Display()
        {
            //当前线程
            var progress = new Progress<int>(percent =>
            {
                Console.Clear();
                Console.Write("{0}%", percent);
            });
            //线程池线程
            await Task.Run(() => DoProcessing(progress));
            Console.WriteLine("");
            Console.WriteLine("结束");
            Console.ReadKey();
        }

        public static void Main()
        {
            Task task = Display();
            task.Wait();
        }
    }
}
