using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Triangle : Shape
	{
		static readonly int MAX_SIDE1 = 270;
		static readonly int MIN_SIDE2 = 100;
		static readonly int START_T_X = 580;
		static readonly int START_T_Y = 260;
		int side1;
		int side2;
		double side3;
		int angle;
		static readonly int NUMBER_OF_POINTS = 3;
		Point[] pt = new Point[NUMBER_OF_POINTS];

		public Triangle(Graphics shape, int side1, int side2, int angle) : base(shape) 
		{
			this.side1 = side1;
			this.side2 = side2;
			this.angle = (angle > 180 ? 180 : angle < 1 ? 1 : angle);
			this.side3 = (Math.Sqrt(Math.Pow((double)side1, (double)2) + Math.Pow((double)side2, (double)2) - (double)2 * (double)side1 * (double)side2 * (Math.Cos((double)this.angle * 0.0175))));
			
			
			pt[0].X = START_T_X;
			pt[0].Y = START_T_Y;

			if (this.angle == 90)
			{
				pt[1].X = START_T_X - (side1 >= MIN_SIDE2 ? MIN_SIDE2 : side1);
				pt[1].Y = START_T_Y;
				pt[2].X = pt[1].X;
				pt[2].Y = pt[1].Y - (side2 >= MAX_SIDE1 ? MAX_SIDE1 : side2);
			}
			else if (this.angle > 90)
			{
				pt[1].X = START_T_X - (side1 >= MIN_SIDE2 ? MIN_SIDE2 : side1);
				pt[1].Y = START_T_Y;
				pt[2].X = pt[1].X - (side2 >= MAX_SIDE1 ? MAX_SIDE1 : side2);
				pt[2].Y = pt[1].Y - (side2 >= MAX_SIDE1 ? MAX_SIDE1 : side2);
			}
			else
			{
				pt[1].X = pt[0].X - (side1 >= MIN_SIDE2 ? MIN_SIDE2 : side1);
				pt[1].Y = pt[0].Y;
				pt[2].X = pt[0].X - (side2 >= MAX_SIDE1 ? MAX_SIDE1 : side2) / 2;
				pt[2].Y = pt[0].Y - (side2 >= MAX_SIDE1 ? MAX_SIDE1 : side2);
			}
		}
		public override double GetArea()
		{
			double p = GetPerimeter() / 2;
			return Math.Sqrt(Math.Abs(p * (p - side1) * (p - side2) * (p - side3)));
		}
		public override double GetPerimeter()
		{
			return side1 + side2 + side3;
		}
		public override void GetDraw()
		{
			shape.FillPolygon(brush, pt);
		}
		public override string Info()
		{
			return $"Сторона 1: {side1} см\nСторона 2: {side2} см\nСторона 3: {side3}\nУгол: {angle}  градусов\n" + base.Info();
		}
	}
}
