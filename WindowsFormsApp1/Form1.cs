using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个线程去执行这个方法:创建的线程默认是前台线程
            Thread thread = new Thread(new ThreadStart(Test));
            //Start方法标记这个线程就绪了，可以随时被执行，具体什么时候执行这个线程，由CPU决定
            //将线程设置为后台线程
            thread.IsBackground = true;
            thread.Start();
        }
        private void Test()
        {
            for (int i = 0; i <= 1000; i++)
            {
                this.textBox1.Text = i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程的访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
