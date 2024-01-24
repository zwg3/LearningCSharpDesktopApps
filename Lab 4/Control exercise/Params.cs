using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_exercise
{
    public class Params
    {
        public int A { get; set; }
        public int B { get; set; }  
        public int C { get; set; }

        public override string ToString()
        {
            return Convert.ToString(A) + ' ' + Convert.ToString(B) + ' ' + Convert.ToString(C);
        }

    }
}
