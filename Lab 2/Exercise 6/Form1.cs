using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_6
{
    public partial class Form1 : Form
    {
        List<Item> its = new List<Item>();

        public Form1()
        {            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /********************BOOK GET/SET***********************************/
        public string Author 
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Title 
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string PublishHouse 
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public int Page 
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        public int Year 
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown2.Value = value; }
        }
        public int InvNumber 
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown3.Value = value; }
        }
        public bool Existence 
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool SortInvNumber 
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }
        public bool ReturnTime 
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value; }
        }
        public int PeriodUse 
        {
            get { return (int)numericUpDown4.Value; }
            set { numericUpDown4.Value = value; }
        }
        /********************MAGAZINE GET/SET***********************************/
        public string Volume
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public int Number
        {
            get { return (int)numericUpDown10.Value; }
            set { numericUpDown10.Value = value; }
        }

        public string MTitle
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public int MYear
        {
            get { return (int)numericUpDown8.Value; }
            set { numericUpDown8.Value = value; }
        }

        public int MInvnumber
        {
            get { return (int)numericUpDown7.Value; }
            set { numericUpDown7.Value = value; }
        }

        public bool Sub
        {
            get { return checkBox5.Checked; }
            set { checkBox5.Checked = value; }
        }
        /*******************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book(Author, Title, PublishHouse,
            Page, Year, InvNumber, Existence);

            if (ReturnTime)
                b.ReturnSrok();

            b.PriceBook(PeriodUse);

            its.Add(b);

            Author = Title = PublishHouse = "";
            Page = InvNumber = PeriodUse = 0;
            Year = 0;
            Existence = ReturnTime = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SortInvNumber)
                its.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox1.Text = sb.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Magazine m = new Magazine(Volume, Number, MTitle, MYear, MInvnumber, Sub);

            if (Sub)
            {
                m.IfSubs = true;
            }

            its.Add(m);

            Volume = MTitle = "";
            Number = MYear = MInvnumber = 0;
            Sub = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
