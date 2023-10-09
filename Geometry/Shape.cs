using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geometry
{
	abstract class Shape
	{
		protected static readonly int START_X = 210;
		protected static readonly int START_Y = 20;
		protected Color color;
		protected Graphics shape;
		protected SolidBrush brush;
		public Shape(Graphics shape)
		{			
			this.shape = shape;
			Random rand = new Random();
			color = Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
			brush = new SolidBrush(color);
		}
		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void GetDraw();
		public virtual string Info()
		{
			return $"Площать фигуры: {GetArea()} см2\nПериметр фигуры: {GetPerimeter()} см\n";
		}
	}
}
