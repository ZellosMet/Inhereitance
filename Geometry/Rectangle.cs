using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Rectangle : Shape
	{
		static readonly int MAX_SIDE1 = 370;
		static readonly int MAX_SIDE2 = 440;
		int side1;
		int side2;

		public Rectangle(Graphics shape, int side1, int side2) : base(shape)
		{
			this.side1 = side1;
			this.side2 = side2;
		}

		public override double GetArea()
		{
			return (double)side1 * side2;
		}
		public override double GetPerimeter()
		{
			return (double)(side1 + side2) * 2;
		}
		public override void GetDraw()
		{
			shape.FillRectangle(brush, START_X, START_Y, (side1 > MAX_SIDE1 ? MAX_SIDE1 : side1), (side2 > MAX_SIDE2 ? MAX_SIDE2 : side2));
		}
		public override string Info()
		{
			return $"Сторона 1: {side1} см\nСторона 2: {side2} см\n" + base.Info();
		}
	}
}
