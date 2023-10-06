using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Program
	{
		public static readonly string delim = "\n----------------------------------------------------\n";
		static void Main(string[] args)
		{
			string file_name = "group.txt";

			Human human = new Human("Montana", "Antonio", 30);
			//Console.WriteLine(human);
			//Console.WriteLine(delim);

			Student student = new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 90, 99);
			//Console.WriteLine(student);
			//Console.WriteLine(delim);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			//Console.WriteLine(teacher);
			//Console.WriteLine(delim);

			Graduate graduate = new Graduate("Hank", "Schrader", 40, "Criminalistic", "OBN", 80, 70, "\"How to cath Heisenberg\"");
			//Console.WriteLine(graduate);
			//Console.WriteLine(delim);

			Human human1 = new Human("Vercetty", "Tommy", 30);
			//Console.WriteLine(human);
			//Console.WriteLine(delim);


			Student tommy = new Student(human1, "Theft", "Vice", 90, 99);
			//Console.WriteLine(tommy);
			//Console.WriteLine(delim);

			Human[] group = new Human[]
			{
				student, teacher, graduate, tommy,
				new Teacher("Diaz", "Ricardo", 50, "\"Weapons distribution\"", 25)
			};


			for (int i = 0; i < group.Length; i++)
			{

				//Console.WriteLine(group[i]);
				group[i].Print();
				Console.WriteLine(delim);
			}

			ReadWrite w = new ReadWrite(group, file_name);
			w.Write();
			ReadWrite r = new ReadWrite(file_name);
			Console.WriteLine(delim);

			Human[] load_group = r.Read();
			Console.WriteLine(delim);

			for (int i = 0; i < load_group.Length; i++)
			{
				load_group[i].Print();
				Console.WriteLine(delim);
			}
		}
	}
}
