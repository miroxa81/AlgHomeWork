using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{

			int caseMenu;
			int n;
			bool isOk = false;

			WriteLineColor("Здравствуй мой дорогой друг.", ConsoleColor.DarkYellow);
			WriteLineColor("Данная программа вычисляет число Фибоначчи разными методадами, рекурсией, и без рекурсии (циклом) .", ConsoleColor.DarkYellow);

			WriteColor("Какое число хотим найти?\nЧисло: ", ConsoleColor.Gray);
			n = ReadInt();

			WriteColor($"Решение рекурсией: F({n})={FibRec(n)}\n", ConsoleColor.Red);
			WriteColor($"Решение циклом:    F({n})={FibFor(n)}\n", ConsoleColor.Green);

			Console.ReadKey();
		}


		static int FibFor(int number)
		{
			int FibPrevios = 0;
			int FibLast = 1;
			int temp;

			if (number == 0) return FibPrevios;
			if (number == 1) return FibLast;

			for (int i = 0; i <= number - 2; i++)
			{
				temp = FibPrevios + FibLast;
				FibPrevios = FibLast;
				FibLast = temp;
			}
			return FibLast;
		}

		static int FibRec(int number)
		{
			if (number == 1 || number == 0)
			{
				return number;
			}
			else
			{
				return FibRec(number - 1) + FibRec(number - 2);
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

		static int ReadInt()
		{
			int IntNumber;
			while (!int.TryParse(Console.ReadLine(), out IntNumber))
			{
				WriteColor("Пожалуйста введите целое число", ConsoleColor.Gray);
				Console.WriteLine();
			}
			return IntNumber;
		}

	}
}
