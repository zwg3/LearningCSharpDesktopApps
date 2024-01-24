using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_exercise
{
    public partial class Form1 : Form
    {
        List <Params> paramList = new List <Params> ();
        List <Results> resultsList = new List <Results> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Params p = new Params();
            Results r = new Results();
            ParamInput input = new ParamInput(p, r);
            paramList.Add(p);
            resultsList.Add(r);
            if (input.ShowDialog() != DialogResult.OK)
                return;
            
            label2.Text = "A: " + Convert.ToString(paramList.Last().A) + "\nB: " + Convert.ToString(paramList.Last().B) + "\nC: " + Convert.ToString(paramList.Last().C);
            
            StringBuilder sb = new StringBuilder();           
            foreach (Results item in resultsList)
            {
                sb.Append("Результат вычислений: \n" + item.ToString() + '\n'+'\n');
            }
            richTextBox1.Text = sb.ToString();
        }
    }
}
