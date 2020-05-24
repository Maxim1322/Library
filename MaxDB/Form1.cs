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
    public partial class Form1 : Form
    {
        Query controller;
        public Form1()
        {
            InitializeComponent();
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string query = "SELECT Title FROM Books WHERE IdBook=1";
          //  OleDbCommand command = new OleDbCommand(query, myConnection);
          //  textBox1.Text = command.ExecuteScalar().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller = new Query();
            dataGridView1.DataSource = controller.ReadBooks();

        }

       private void button4_Click(object sender, EventArgs e)
        {
            //string query = "UPDATE Books SET Autor ='Энгельс, Каутский'  WHERE IdBook=1"; // VALUES ('Капитал','Маркс')";
            //OleDbCommand command = new OleDbCommand(query, myConnection);
            //command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controller = new Query();
            dataGridView1.DataSource = controller.ReadBooksOnHands();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            controller = new Query();
            dataGridView1.DataSource = controller.ReadBooksByAutor(textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controller = new Query();
            dataGridView1.DataSource = controller.ReadBooksByGenre(comboBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
