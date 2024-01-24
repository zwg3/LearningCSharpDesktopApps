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
    public partial class ParamInput : Form
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

        public ParamInput(Params p, Results r)
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
                r.Message = "Уравнение линейное";
            }

            else if (determinant > 0)
            {
                double root1 = (-B + Math.Sqrt(determinant)) / (2 * A);
                double root2 = (-B - Math.Sqrt(determinant)) / (2 * A);
                r.Message = "Уравнение имеет два корня: " + root1 + " и " + root2;
            }
            else if (determinant == 0)
            {
                double root1 = -B / (2 * A);
                r.Message = "Уравнение имеет один корень: " + root1;
            }

            else
            {
                r.Message = "Уравнение корней не имеет: ";

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
