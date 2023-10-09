using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	public partial class Form1 : Form
	{
		Graphics shape;
		public Form1()
		{
			InitializeComponent();
			comboBox1.Items.AddRange(new string[] { "Квадрат", "Прямоугольник", "Круг", "Треугольник" });
			button1.Enabled = false;
			textBox1.Enabled = false;
			textBox2.Enabled = false;
			textBox3.Enabled = false;
		}
		private void Form1_Paint(object sender, PaintEventArgs e)
		{ 
			shape = CreateGraphics();
			shape.DrawRectangle(Pens.Black, 200, 10, 390, 460);
			shape.DrawRectangle(Pens.Black, 12, 240, 170, 230);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			shape = CreateGraphics();
			int side1 = 0;
			int side2 = 0;
			int angle = 0;
			side1 = Convert.ToInt32(textBox1.Text);
			if(textBox2.Text != "") side2 = Convert.ToInt32(textBox2.Text);
			if(textBox3.Text != "") angle = Convert.ToInt32(textBox3.Text);

			switch (comboBox1.SelectedItem)
			{
				case "Квадрат":
					Refresh();					
					Square square = new Square(shape, side1);
					square.GetDraw();
					label2.Text = square.Info();
				break;

				case "Прямоугольник":
					Refresh();					
					Rectangle rectangle = new Rectangle(shape, side1, side2);
					rectangle.GetDraw();
					label2.Text = rectangle.Info();
				break;

				case "Круг":
					Refresh();
					Circl circl = new Circl(shape, side1);
					circl.GetDraw();
					label2.Text = circl.Info();
				break;

				case "Треугольник":
					Refresh();
					Triangle triangle = new Triangle(shape, side1, side2, angle);
					triangle.GetDraw();
					label2.Text = triangle.Info();
				break;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
			if (Char.IsControl(e.KeyChar)) return;
			e.Handled = true;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == "Квадрат" || comboBox1.SelectedItem == "Круг")
			{
				if (textBox1.Text.Length == 0) button1.Enabled = false;
				else button1.Enabled = true;
			}
			else if (comboBox1.SelectedItem == "Прямоугольник")
			{
				if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) button1.Enabled = false;
				else button1.Enabled = true;
			}
			else 
			{
				if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0) button1.Enabled = false;
				else button1.Enabled = true;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == "Квадрат" || comboBox1.SelectedItem == "Круг")
			{
				textBox1.Text = textBox2.Text = textBox3.Text = "";
				textBox1.Enabled = true;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				if (comboBox1.SelectedItem == "Квадрат") label8.Text = "Длина стороны";
				else label8.Text = "Диаметр";
			}
			else if (comboBox1.SelectedItem == "Прямоугольник")
			{
				textBox1.Text = textBox2.Text = textBox3.Text = "";
				label8.Text = "Ширина";
				label7.Text = "Высота";
				textBox1.Enabled = textBox2.Enabled = true;
			}
			else
			{
				textBox1.Text = textBox2.Text = textBox3.Text = "";
				label8.Text = "Длина катета А";
				label7.Text = "Длина катета В";
				label6.Text = "Угол";
				textBox1.Enabled = true;
				textBox2.Enabled = true;
				textBox3.Enabled = true;
			}
		}
	}
}
