using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_exercise
{
    public class Results
    {
        public string Message { get; set; }

        public override string ToString()

        {
            return $"{Message}";
        }
    }
}
