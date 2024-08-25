using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatStHafta1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            label1.Text = textBox1.Text + "amına goyum ";
            

            int a = 5;
            int b = 10;
            int c = a + b;

            textBox2.Text = text;
        }
    }
}
