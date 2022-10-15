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

namespace WinPMS.Debug
{
    public partial class FrmDebugTaskDemo : Form
    {
        public FrmDebugTaskDemo()
        {
            InitializeComponent();
        }

        public delegate void MyDelegate1(int a, int b);

        #region 事件
        private void button1_Click(object sender, EventArgs e)
        {
            MyDelegate1 delegate1 = new MyDelegate1(Test2);
            delegate1.Invoke(1, 2);

            Action act1 = new Action(Test1);
            Action act2 = Test1;
            Action act11 = new Action(() => { });
            Action act3 = () =>
            {

            };

            Task.Run(new Action(Test1));
            Task.Run(act1);
            Task.Run(act2);
            Task.Run(act3);
            //Task.Run(async(await()=>{ }));
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            textBox1.Text = "";

            textBox1.Text = await Task.Run(() =>
            {
                Thread.Sleep(5000);
                
                return "await async";
            });

            button2.Enabled = true;
        }
        #endregion


        #region 方法
        private void Test1()
        {

        }

        private void Test2(int a, int b)
        {

        }

        private int Test3()
        {
            return new Random().Next(1, 10);
        }

        private int Test4(int a, int b)
        {
            return new Random().Next(1, 10);
        }
        #endregion

    }
}
