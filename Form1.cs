using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Generate_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox1.Text, out int n))
            {
                MessageBox.Show("Invalid input","Invalid number input",MessageBoxButtons.OK);
                return;
            }
            Task generateTask = Task.Run(() => GenerateFibonacci(n));

            await generateTask;

            listBox1.Items.Clear();
        }

        public async void GenerateFibonacci(int n)
        {
            int a = 0, b = 1, c = 0;
            for (int i = 0; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                AddToFibonacciListBox(c);


                await Task.Delay(100);
            }
        }

        public void AddToFibonacciListBox(int value)
        {
            Invoke(new Action(() =>
            {
                listBox1.Items.Add(value);
            }));
        }

    }
}
