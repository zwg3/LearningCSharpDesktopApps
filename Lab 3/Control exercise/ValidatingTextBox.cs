using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Control_exercise
{
    public partial class ValidatingTextBox : UserControl
    {
        public ValidatingTextBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Поле не может содержать цифры");
            //}

        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                e.Cancel = false;
            }
            else
            {
                try
                {
                    double.Parse(textBox1.Text);
                    e.Cancel = true;
                    MessageBox.Show("Поле должно содержать только буквы");
                }
                catch
                {
                    e.Cancel = false;                    
                }
            }
        }
        public string TextContent
        {
            get { return textBox1.Text; }
        }
    }
}
