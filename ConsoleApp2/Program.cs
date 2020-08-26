using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //演示前台、后台线程
            BackGroundTest background = new BackGroundTest(10);
            //创建前台线程
            Thread fThread = new Thread(new ThreadStart(background.RunLoop));
            //给线程命名
            fThread.Name = "前台线程";


            BackGroundTest background1 = new BackGroundTest(20);
            //创建后台线程
            Thread bThread = new Thread(new ThreadStart(background1.RunLoop));
            bThread.Name = "后台线程";
            //设置为后台线程
            bThread.IsBackground = true;

            //启动线程
            fThread.Start();
            bThread.Start();

            Console.ReadKey();
        }
    }

    class BackGroundTest
    {
        private int Count;
        public BackGroundTest(int count)
        {
            this.Count = count;
        }
        public void RunLoop()
        {
            //获取当前线程的名称
            string threadName = Thread.CurrentThread.Name;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("{0}计数：{1}", threadName, i.ToString());
                //线程休眠500毫秒
                Thread.Sleep(1000);
            }
            Console.WriteLine("{0}完成计数", threadName);
        }
    }
}
