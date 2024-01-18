using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_exercise_2
{
    public partial class Form2 : Form
    {
        Form1 myF2;
        public Form2()
        {
            myF2 = new Form1();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myF2.Show();
                myF2.Activate();
            }
            catch (ObjectDisposedException ex)
            {
                myF2 = new Form1();
                myF2.Show();
                myF2.Activate();
            }

            myF2.Show();
        }
    }
}
