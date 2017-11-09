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

namespace async_await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = LongImportantMethod("John");

            //var task = Task.Factory.StartNew(() => LongImportantMethod("Sally"))
            //.ContinueWith((t) => label1.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());

            CallLongImportantMethod();
            label1.Text = "Loading ....";

        }

        private async void CallLongImportantMethod()
        {
            var result = await LongImportantMethodAsync("Andrew");
            label1.Text = result;
        }

        private Task<string> LongImportantMethodAsync(string name)
        {
            return Task.Factory.StartNew(() => LongImportantMethod(name));
        }

        private string LongImportantMethod(string name)
        {
            Thread.Sleep(2000);
            return "Hello " + name;
        }
    }
}
