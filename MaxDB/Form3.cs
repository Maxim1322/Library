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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
                MessageBox.Show("Дані вказані не повністю");
            else
            {
                Query controller = new Query();
                int i = 1;
                try
                {
                    i = Convert.ToInt32(textBox3.Text);
                    controller.AddBook(textBox1.Text, textBox2.Text, i, comboBox1.Text);
                    MessageBox.Show("Книга " + textBox1.Text + " зареєстрована");
                    textBox1.Text = ""; textBox2.Text = "";
                }
                catch
                {
                    MessageBox.Show("Кількість примірників не є ціле число");
                }
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
