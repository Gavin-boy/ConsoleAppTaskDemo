using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2._4
{
    class Node 
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Text { get; set; }
    }
    class Program
    {
        static Node GetNode()
        {
            Node root = new Node
            {
                Left = new Node
                {
                    Left = new Node
                    {
                        Text = "L-L"
                    },
                    Right = new Node
                    {
                        Text = "L-r"
                    },
                    Text = "L"
                },
                Right = new Node
                {
                    Left = new Node
                    {
                        Text = "R-L"
                    },
                    Right = new Node
                    {
                        Text = "R-R"
                    },
                    Text = "R"
                },
                Text = "Root"
            };
            return root;
        }
        static void Main(string[] args)
        {
            Node root = GetNode();
            DisplayTree(root);
        }
        static void DisplayTree(Node root)
        {
            var task = Task.Factory.StartNew(() => DisplayTree(root), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
            task.Wait();
        }

        static void DisplayNode(Node current)
        {
            if (current.Left!=null)
            {
                Task.Factory.StartNew(() => DisplayNode(current.Left), CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                if (current.Right!=null)
                {
                    Task.Factory.StartNew(() => DisplayNode(current.Right), CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
                    Console.WriteLine("当前节点的值为{0}；处理的Thread={1}",current.Text,Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }
}
