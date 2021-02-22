using System;

namespace Task1
{
	class Program

	{


		static void Main(string[] args)
		{


			int[] TestNumbers = { 2, 3, 5, 7, 8, 10, 13, 17 };
			string[] ExpectValue = { "простое", "простое", "простое", "простое", "составное", "составное", "простое", "простое" };


			/*					WriteColor($"Пожалуйста введите любое натуральное число:", ConsoleColor.Gray);
								do
									if (!int.TryParse(Console.ReadLine(), out n)||n<0)
									{
										WriteColor($"Пожалуйста введите натуральное число:", ConsoleColor.DarkRed);
									}
									else break;
								while (true);
								if (n != 1)
								{
									if (SimpleNumber(n))
									{

										WriteColor($"Число {n} простое.", ConsoleColor.DarkGreen);
									}
									else
									{
										WriteColor($"Число {n} не являеться простым.", ConsoleColor.DarkYellow);
									}
								}
								else WriteColor($"" +
									$"   В настоящее время в математике принято не относить единицу \n" +
									$"ни к простым,  ни  к  составным числам,  так как это нарушает \n" +
									$"важную  для теории чисел единственность разложения на простые \n" +
									$"множители.  Последним  из  профессиональных  математиков, кто \n" +
									$"рассматривал 1 как простое число, был Анри Лебег в 1899 году. \n", ConsoleColor.Yellow);


								Console.ReadKey();


		*/

			for (int t = 1; t < TestNumbers.Length; t++)
			{
				var result = SimpleNumber(t) ? "простое" : "составное";
				var expected = ExpectValue[t];
				WriteLineColor($"Число {TestNumbers[t]} {result}, {"ожидалось - "}{expected} ", ConsoleColor.DarkYellow);

			};
		}


		static bool SimpleNumber(int number)
		{
			int d = 0;
			int i = 2;


			while (i < number)
			{
				if (number % i == 0)
				{ d++; i++; }
				else
					i++;
			}

			return d == 0 ? true : false;

		}

		static void WriteColor(string txt, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(txt);
			Console.ResetColor();
		}
		static void WriteLineColor(string txt, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(txt);
			Console.ResetColor();
		}
	}
}
