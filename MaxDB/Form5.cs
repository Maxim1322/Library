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
    public partial class Form5 : Form
    {
        int IdBook = 0;
        int IdReader = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdBook = e.RowIndex + 1;
            

            if (IdBook >= 1)
            {
                
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                textBox1.Text = "Не обрана";
                textBox3.Text = "0";
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "0")
                MessageBox.Show("Дані вказані не повністю");
            else
            {
                Query controller = new Query();
                controller.ReturnBook(Int32.Parse(textBox3.Text));
                    MessageBox.Show("Книга " + textBox1.Text + " возвращена ");
                    textBox1.Text = "Не обрана";
                    textBox3.Text = "0";

            
            }
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            Query controller = new Query();
            dataGridView1.DataSource = controller.ReadBooksOnHands();
            controller = new Query();
           
        }
    }
}
