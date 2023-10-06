using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Academy
{
	internal class ReadWrite
	{
		private Human[] human;
		private string path;

		public ReadWrite(Human[] human, string path)
		{
			this.human = human;
			this.path = path;
		}
		public ReadWrite(string path)
		{
			this.path = path;
		}

		public void Write()
		{
			//.  - Ссылка на текущий каталог
			//.. - ссылка на родитльский катало

			Directory.SetCurrentDirectory("..\\.."); // Задание нового каталога для записи в файл.
			string currentDirectory = Directory.GetCurrentDirectory(); // Читает текущий каталог для записи файли.
			Console.WriteLine(currentDirectory);

			using (StreamWriter streamW = new StreamWriter(path, true))
			{
				for (int i = 0; i < human.Length; i++)
					streamW.WriteLine(human[i].WriteToFile());
				Console.WriteLine("File saved!");

				//Часть кода для автоматического открытия файла
				string cmd = $"{currentDirectory}\\{path}";
				System.Diagnostics.Process.Start("notepad", cmd);
			}
		}
		public Human[] Read()
		{
			int count_line = 0;
			int position = 0;
			string line;
			string[] obj;
			string[] element;
			using (StreamReader cnt = new StreamReader(path)) while (cnt.ReadLine() != null) count_line++;

			Human[] group = new Human[count_line];

			using (StreamReader streamR = new StreamReader(path))
			{
				while ((line = streamR.ReadLine()) != null)
				{
					obj = line.Split(':');
					element = obj[1].Split('|');
					switch (obj[0])
					{
						case "Academy.Student":
							Student student = new Student(element[0], element[1], Convert.ToInt32(element[2]), element[3], element[4], Convert.ToDouble(element[5]), Convert.ToDouble(element[5]));
							group[position] = student;
							position++;
							break;
						case "Academy.Teacher":
							Teacher teacher = new Teacher(element[0], element[1], Convert.ToInt32(element[2]), element[3], Convert.ToInt32(element[4]));
							group[position] = teacher;
							position++;
							break;
						case "Academy.Graduate":
							Graduate graduate = new Graduate(element[0], element[1], Convert.ToInt32(element[2]), element[3], element[4], Convert.ToDouble(element[5]), Convert.ToDouble(element[6]), element[7]);
							group[position] = graduate;
							position++;
							break;
					}
				}
			}
			Console.WriteLine("File loaded!\n");
			return group;
		}
	}
}
