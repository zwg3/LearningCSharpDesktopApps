using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userControl11.TimeEnabled == false) 
                {userControl11.TimeEnabled = true;}
            else {userControl11.TimeEnabled = false;}
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
