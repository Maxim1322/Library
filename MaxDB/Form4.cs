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
    public partial class Form4 : Form
    {
        int IdBook = 0;
        int IdReader = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            Query controller = new Query();
            dataGridView1.DataSource = controller.ReadBooksForIs();
            controller = new Query();
            dataGridView2.DataSource = controller.ReadReaders();
        }


        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdBook = e.RowIndex + 1;

            if (IdBook >= 1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                textBox1.Text = "Не обрана";
                textBox3.Text = "0";
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdReader = e.RowIndex + 1;

            if (IdReader >= 1)
            {
                textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                textBox2.Text = "Не обраний";
                textBox4.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "0" || textBox4.Text == "0")
                MessageBox.Show("Дані вказані не повністю");
            else
            {
                Query controller = new Query();
                if (controller.AddIssue(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text)))
                {
                    MessageBox.Show("Книга " + textBox1.Text + " видана. Абонент " + textBox2.Text + ".");
                    textBox1.Text = "Не обрана";
                    textBox3.Text = "0";
                    textBox2.Text = "Не обраний";
                    textBox4.Text = "0";
                }
                else
                    MessageBox.Show("Все экземпляры " + textBox1.Text + " на руках");
            }
        }
    }
}
