using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;

			WriteColor($"Пожалуйста введите число:", ConsoleColor.Gray);
			do
				if (!int.TryParse(Console.ReadLine(), out n))
				{
					WriteColor($"Пожалуйста введите число:", ConsoleColor.DarkRed);
				}
				else break;
			while (true);


			if (PrimeNumber(n))
			{

				WriteColor($"Число {n} простое", ConsoleColor.DarkGreen);
			}
			else
			{
				WriteColor($"Число {n} не являеться простым", ConsoleColor.DarkYellow);
			}

			Console.ReadKey();
		}


		static bool PrimeNumber(int number)
		{
			int d = 0;
			int i = 2;
	

			while (i < number)
			{
				if (number % i == 0) d++;
				i++;
			}

			if (d == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
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
