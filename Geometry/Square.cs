using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Square : Rectangle
	{
		public Square(Graphics shape, int size) : base(shape, size, size){}
	}
}
