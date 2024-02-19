using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public int GetBaseLength()
        {
            if (int.TryParse(textBox1.Text, out int baseLength))
                return baseLength;
            else
                return -1;
        }

        public int GetSideLength()
        {
            if (int.TryParse(textBox2.Text, out int sideLength))
                return sideLength;
            else
                return -1;
        }



        private void ContinueButton(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны треугольника.");
            }
            else
            {
                if (!int.TryParse(textBox1.Text, out int baseLength) || !int.TryParse(textBox2.Text, out int sideLength))
                {
                    MessageBox.Show("Значения должны быть целыми числами.");
                    return;
                }

                if (baseLength <= 0 || sideLength <= 0)
                {
                    MessageBox.Show("Значения должны быть положительными.");
                    return;
                }

                if (baseLength >= sideLength + sideLength || sideLength >= baseLength + baseLength)
                {
                    MessageBox.Show("Значения не могут образовать стороны треугольника.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void CancelButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
