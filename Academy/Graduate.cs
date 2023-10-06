using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate : Student
	{
		public string ThesisTopic { get; set; }


		public Graduate(string lastName, string firstName, int age, string speciality, string group, double rating, double attendance, string thesisTopic) : 
			base(lastName, firstName, age, speciality, group, rating, attendance)
		{
			ThesisTopic = thesisTopic;
			Console.WriteLine($"GConstructor:\t {this.GetHashCode()}");
		}
		public Graduate(Graduate other) : base(other)
		{
			this.ThesisTopic = other.ThesisTopic;
			Console.WriteLine($"GCopyConstructor: {this.GetHashCode()}");
		}
		~Graduate()
		{
			Console.WriteLine($"SDestructor:\t {this.GetHashCode()}");
		}
		public override string ToString()
		{
			return base.ToString() + $" {ThesisTopic}";
		}
		public override void Print()
		{
			base.Print();
			Console.WriteLine("ThesisTopic:\t" + ThesisTopic);
		}
		public override string WriteToFile()
		{
			return base.WriteToFile() + $"|{ThesisTopic}";
		}
	}
}
