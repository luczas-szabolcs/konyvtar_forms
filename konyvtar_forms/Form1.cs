using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace konyvtar_forms
{
    public partial class Form1 : Form
    {
        List<Books> books_list = new List<Books>();
        int osszdb = 0;

        public Form1()
        {
            InitializeComponent();
            
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }
            
            foreach (var item in books_list)
            {
                osszdb += item.db;
            }
            textBox2.Text = osszdb.ToString();

            List<Books> legdragabbak = new List<Books>(); 
            Books legdragabb = books_list[0];
            legdragabbak.Add(legdragabb); 

            foreach (var termek in books_list)
            {
                if (termek.ar > legdragabb.ar)
                {
                    legdragabb = termek;
                    legdragabbak.Clear();
                    legdragabbak.Add(legdragabb);
                }
                else if (termek.ar == legdragabb.ar)
                {
                    legdragabbak.Add(termek);
                }
            }
            foreach (var legdragabbTermek in legdragabbak)
            {
                dataGridView1.Rows.Add(legdragabbTermek.kategoria, legdragabbTermek.konyv, legdragabbTermek.ar);
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kategoria1 = comboBox1.Text;
            foreach (var book in books_list)
            {
                if (book.kategoria.Equals(kategoria1))
                {
                    textBox3.Text += book.kategoria + " " + book.konyv + " " + book.ar + Environment.NewLine;
                }
            }
        }
    }
}
