using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Circl : Shape
	{
		static readonly int MAX_DIAMETER = 370;
		static readonly double PI = 3.14;
		int diameter;

		public Circl(Graphics shape, int diameter) : base(shape)
		{
			this.diameter = diameter;
		}

		public override double GetArea()
		{
			return (double)PI * diameter;
		}
		public override double GetPerimeter()
		{
			return GetArea() * 2;
		}
		public override void GetDraw()
		{
			shape.FillEllipse(brush, CENTER_X - (diameter > MAX_DIAMETER ? MAX_DIAMETER : diameter) / 2, CENTER_Y - (diameter > MAX_DIAMETER ? MAX_DIAMETER : diameter) / 2, (diameter > MAX_DIAMETER ? MAX_DIAMETER : diameter), (diameter > MAX_DIAMETER ? MAX_DIAMETER : diameter));
		}
		public override string Info()
		{
			return $"Диаметр: {diameter} см\n" + base.Info();
		}
	}
}
