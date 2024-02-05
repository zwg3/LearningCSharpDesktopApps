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

namespace WindowsFormsApp1{
    
    public partial class Form1 : Form
    {
        public string a;
        public Form1()
        {
            InitializeComponent();
        }
        public async Task<string> GoButt()
        {
            int maxValue = 0;
            StringBuilder resultText = new StringBuilder();
            if (int.TryParse(MaxValue.Text, out maxValue))
            {
                for (int trial = 2; trial <= maxValue; trial++)
                {
                    bool isPrime = true;
                    for (int divisor = 2; divisor <= Math.Sqrt(trial); divisor++)
                    {
                        if (trial % divisor == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        resultText.AppendFormat("{0} ", trial);
                    }
                }
            }

            else
            {
                resultText.Append("Unable to parse maximum value.");
            }
            return await Task.Run(() =>
            {
                string res = resultText.ToString();
                Thread.Sleep(5000);
                return res;
            }
 );
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = await GoButt();
        }
    }


    

}
