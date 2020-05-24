using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Дані вказані не повністю");
            else
            {
              Query  controller = new Query();
                controller.AddReader(textBox1.Text, textBox2.Text);
                MessageBox.Show("Абонент "+ textBox1.Text+" "+ textBox2.Text+" зареєстрований");
                textBox1.Text = "";  textBox2.Text = "";
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
