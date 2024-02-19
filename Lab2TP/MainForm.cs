using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    public partial class MainForm : Form

    {
        public MainForm()
        {
            InitializeComponent();
        }

        isoscelesTriangle triangle1 = new isoscelesTriangle(10, 12);
       
        private void InputButton(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            
            DialogResult result = inputForm.ShowDialog();

            
            if (result == DialogResult.OK)
            {
                
                int baseLength = inputForm.GetBaseLength();
                int sideLength = inputForm.GetSideLength();

                
                triangle1 = new isoscelesTriangle(baseLength, sideLength);
            }
        }
        private void OutputButton(object sender, EventArgs e)
        {
            if (triangle1 != null)
            {
                
                ResultForm resultForm = new ResultForm();

                
                int perimeter = triangle1.calcutePerimetr();
                int square = triangle1.calcuteSquare();

                
                resultForm.SetResults(perimeter, square);

                resultForm.ShowDialog();
            }
        }
        private void calculateAreaNPerimetr(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                
                if (int.TryParse(textBox1.Text, out int baseLength) && int.TryParse(textBox2.Text, out int sideLength))
                {
                    
                    if (baseLength > 0 && sideLength > 0)
                    {
                        if (baseLength < sideLength + sideLength && sideLength < baseLength + sideLength)
                        {
                            isoscelesTriangle triangle = new isoscelesTriangle(baseLength, sideLength);

                            ResultForm resultForm = new ResultForm();
                            resultForm.SetResults(triangle.calcutePerimetr(), triangle.calcuteSquare());
                            resultForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Стороны должны соответсвовать правилу треугольника");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите положительные значения для длины основания и длины стороны");
                    }
                }
                else
                {
                    MessageBox.Show("Введите числовые значения для длины основания и длины стороны");
                }
            }
            else
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны");
            }
        }
        /// <summary>
        /// Ru: Класс для расчёта периметра и площади равнобедренного треугольника.<br/>
        /// En: A class for calculating the perimeter and area of an isosceles triangle.
        /// </summary>

        class isoscelesTriangle
        {
            private int baseLength;
            private int sideLength;

            public isoscelesTriangle(int baseLength, int sideLength)
            {
                this.baseLength = baseLength;
                this.sideLength = sideLength;
            }

            public int calcutePerimetr()
            {
                return baseLength + 2 * sideLength;
            }

            public int calcuteSquare()
            {
                return baseLength * sideLength / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            triangle1 = new isoscelesTriangle(10, 12);
        }

      
    }
}
