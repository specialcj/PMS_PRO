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

        public delegate void MyDelegate1(int a);

        #region 事件
        private void button1_Click(object sender, EventArgs e)
        {
            MyDelegate1 delegate1 = new MyDelegate1(Test2);
            delegate1.Invoke(1);

            Action act1_1 = Test1;
            Action act1_2 = new Action(Test1);

            Action<int> act2_1 = new Action<int>(Test2);

            Action act3_1 = new Action(() => { });
            Action act3_2 = () =>
            {

            };

            Task.Run(Test1);
            Task.Run(new Action(Test1));
            Task.Run(new Action(() => { }));

            Task.Run(act1_1);
            Task.Run(act1_2);

            Task.Run(act3_1);
            Task.Run(act3_2);
            Task.Run(() =>
            {

            });



            Task.Run(() =>
            {
                Test3(new Action<int>(Test2), 1, 2);
            });







            //Task.Run(async (await ()=> { }));
        }

        private void Test3(Action<int> action)
        {
            throw new NotImplementedException();
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

        private void Test2(int a)
        {

        }

        private void Test3(Action<int> act, int a, int b)
        {
            act.Invoke(0);
        }



        #endregion

    }
}
