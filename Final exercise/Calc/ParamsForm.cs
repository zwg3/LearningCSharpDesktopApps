using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace SimpleCalculator
{
    public partial class ParamsForm : Form
    {
        Params p;
        Results r;
        public int A
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        public int B
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }
        public int C
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }

        public ParamsForm(Params p, Results r)
        {
            InitializeComponent();
            this.p = p;
            this.r = r;
            this.A = p.A;
            this.B = p.B;
            this.C = p.C;
        }

        public void Calc(int A, int B, int C)
        {
            double determinant = (B * B) - (4 * A * C);

            if (A == 0)
            {
                r.Message = "This is a linear equation";
            }

            else if (determinant > 0)
            {
                double root1 = Math.Round((-B + Math.Sqrt(determinant)) / (2 * A), 2);
                double root2 = Math.Round((-B - Math.Sqrt(determinant)) / (2 * A), 2);
                r.Message = "Results: " + root1 + " and " + root2;
            }
            else if (determinant == 0)
            {
                double root1 = Math.Round(Convert.ToDouble(-B / (2 * A)), 2);
                r.Message = "Result: " + root1;
            }

            else
            {
                r.Message = "No results possible";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            p.A = this.A;
            p.B = this.B;
            p.C = this.C;
            Calc(A, B, C);
        }


    }
}

