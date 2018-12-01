using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordlistCombinder
{
    public partial class Form1 : Form
    {
        SortedSet<String> h = new SortedSet<String>();
        String filename = "";
        Thread hold;
        public Form1()
        {
            InitializeComponent();
        }
        public void Open_and_Load()
        {

            System.IO.StreamReader reader = new System.IO.StreamReader(filename);
            while (reader.Peek() != -1)
                {
                    String s = reader.ReadLine();
                    h.Add(s);
                label3.Invoke(new Action( () => label3.Text = s));
                }
            hold.Abort();
            reader.Close();
        }
        public void saver()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);
            foreach(String i in h)
            {
                writer.WriteLine(i);
                label3.Invoke(new Action(() => label3.Text = i));
            }
            writer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = o.FileName;
                filename = o.FileName;
                ThreadStart t = new ThreadStart(Open_and_Load);
                Thread ct = new Thread(t);
                hold = ct;
                ct.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog ss = new SaveFileDialog();
            ss.Filter = "txt files (*.txt)|*.txt";
            if(ss.ShowDialog() == DialogResult.OK)
            {
                filename = ss.FileName;
                ThreadStart t = new ThreadStart(saver);
                Thread ct = new Thread(t);
                hold = ct;
                ct.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = o.FileName;
                filename = o.FileName;
                ThreadStart t = new ThreadStart(Open_and_Load);
                Thread ct = new Thread(t);
                hold = ct;
                ct.Start();
            }
        }
    }
}
