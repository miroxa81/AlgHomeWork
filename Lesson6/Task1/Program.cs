using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
	
		static void Main(string[] args)
		{

			Queue<int> nodelist = new Queue<int>();
			string[] head = new string[9] {"", "A", "B", "C", "D", "E", "F", "G", "H", };
			int[,] matrix = new int[8, 8];

				for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (i != j)
					{
						matrix[i, j] = new Random().Next(0, 20);
					}
				}
			for (int i = 0; i <= matrix.GetLength(0); i++)
			{
				for (int j = 0; j <= matrix.GetLength(1); j++)
				{
					if (i == 0)
					{
						WriteColor($"{head[j],3}",ConsoleColor.Green);
					}
					else
					if (j == 0)
					{
						WriteColor($"{head[i],3}", ConsoleColor.Green);
					}
					else
					if (i == j)
					{
						WriteColor($"{matrix[i-1, j-1],3}", ConsoleColor.Yellow);
					}
					else
					{
						WriteColor($"{matrix[i-1, j-1],3}", ConsoleColor.Cyan);
					}
				}
				Console.WriteLine();
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
