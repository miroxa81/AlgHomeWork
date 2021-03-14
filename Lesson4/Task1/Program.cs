using System;
using System.Threading;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			Console.Title = "AVL - дерево";
			BalancedTree mytree = new BalancedTree();
			
			Console.SetCursorPosition(0, 0);
			WriteLineColor("        ******  **             **  **                         							", ConsoleColor.Yellow);
			WriteLineColor("       **   **   **           **   **                 *       * ****    *****   *****	", ConsoleColor.Yellow);
			WriteLineColor("      **    **    **         **    **                 *       **    *   *       *		", ConsoleColor.Yellow);
			WriteLineColor("     **     **     **       **     **        *****    *       *         *       *		", ConsoleColor.Yellow);
			WriteLineColor("    **********      **     **      **               *****     *         ****    ****	", ConsoleColor.Yellow);
			WriteLineColor("   **       **       **   **       **                 *       *         *       *		", ConsoleColor.Yellow);
			WriteLineColor("  **        **        ** **        **    **           *       *         *       *		", ConsoleColor.Yellow);
			WriteLineColor(" **         **         ***         ********           *****   *         *****   *****	", ConsoleColor.Yellow);


			ShowMenu();
			Console.SetCursorPosition(0, 27);
			WriteColor($"{"Ваш выбор:"}", ConsoleColor.Gray);

			while (true)
			{
				var kp = GetKey();
				MenuCase(kp, mytree);
				if (kp.Key == ConsoleKey.D0 || kp.Key == ConsoleKey.NumPad0) { break; }
			}
		}

		static void ClearTreeInConsole()
		{
			string str = "";
			Console.SetCursorPosition(0, 0);
			for (int i = 0; i < Console.WindowWidth; i++)
			{ str += " "; }


			for (int j = 0; j < 18; j++)
			{
				Console.SetCursorPosition(0, j);
				Console.Write(str);
			}
			Console.SetCursorPosition(14, 17);
		}
		static ConsoleKeyInfo GetKey()
		{
			ConsoleKeyInfo kp;
			kp = Console.ReadKey(true);

			if (kp.Key == ConsoleKey.D1 || kp.Key == ConsoleKey.D2 || kp.Key == ConsoleKey.D3 || kp.Key == ConsoleKey.D4 || kp.Key == ConsoleKey.D5 || kp.Key == ConsoleKey.D6 || kp.Key == ConsoleKey.D0 ||
				kp.Key == ConsoleKey.NumPad1 || kp.Key == ConsoleKey.NumPad2 || kp.Key == ConsoleKey.NumPad3 || kp.Key == ConsoleKey.NumPad4 || kp.Key == ConsoleKey.NumPad6 || kp.Key == ConsoleKey.NumPad5 || kp.Key == ConsoleKey.NumPad0)
			{
				ClearTreeInConsole();
				ShowMenu();
				Console.SetCursorPosition(0, 27);
				WriteColor($"{"Ваш выбор:"}", ConsoleColor.Gray);
				WriteColor($"{kp.KeyChar}", ConsoleColor.Gray);
			}
			return kp;
		}
		static void ShowMenu()
		{
			Console.SetCursorPosition(0, 18);
			WriteLineColor($"===================================", ConsoleColor.Green);
			WriteLineColor($"{"1:",-5}{"Создать случайное дерево"}", ConsoleColor.Gray);
			WriteLineColor($"{"2:",-5}{"Добавть элемент дерева"}", ConsoleColor.Gray);
			WriteLineColor($"{"3:",-5}{"Удалить элемент дерева"}", ConsoleColor.Gray);
			WriteLineColor($"{"4:",-5}{"Вывести DFS"}", ConsoleColor.Gray);
			WriteLineColor($"{"5:",-5}{"Вывести BFS"}", ConsoleColor.Gray);
			WriteLineColor($"{"6:",-5}{"Удалить дерево полностью"}", ConsoleColor.Gray);
			WriteLineColor($"{"0:",-5}{"Выйти из программы"}", ConsoleColor.Gray);
			WriteLineColor($"===================================", ConsoleColor.Green);
		}

		static void MenuCase(ConsoleKeyInfo kp, BalancedTree mytree)
		{
			switch (kp.Key)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1:
					{
						mytree.ClearTree();
						var rnd = new Random();
						for (int i = 0; i < rnd.Next(1, 32); i++)
						{
							int value = new Random().Next(9999);
							if (mytree.GetNodeByValue(value) == null)
							{
								mytree.AddValue(value);
							}
							else i--;
						}
						mytree.PrintTree();
						break;
					}
				case ConsoleKey.D2:
				case ConsoleKey.NumPad2:
					{
						int value;
						if (mytree.GetRoot() != null)
						{
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor("Введите число:", ConsoleColor.Green);
						}
						else
						{
							Console.SetCursorPosition(0, 17);
							WriteColor("Введите число:", ConsoleColor.Green);
						}

						while (!int.TryParse(Console.ReadLine(), out value))
						{
							ClearTreeInConsole();
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor("Введите число:", ConsoleColor.Green);
						}
						if (mytree.GetNodeByValue(value) == null)
						{
							mytree.AddValue(value);
							ClearTreeInConsole();
							mytree.PrintTree();
						}
						else
						{
							ClearTreeInConsole();
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor($"Число {value} уже существует в данном дереве", ConsoleColor.Red);
							Thread.Sleep(1500);
							ClearTreeInConsole();
							mytree.PrintTree();
						}
						break;
					}

				case ConsoleKey.D3:
				case ConsoleKey.NumPad3:
					{
						int value;
						if (mytree.GetRoot() != null)
						{
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor("Введите число:", ConsoleColor.Green);
						}
						else
						{
							Console.SetCursorPosition(0, 17);
							WriteColor("Дерево пустое", ConsoleColor.Red);
							Thread.Sleep(1500);
							ClearTreeInConsole();
							break;
						}

						while (!int.TryParse(Console.ReadLine(), out value))
						{
							ClearTreeInConsole();
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor("Введите число:", ConsoleColor.Green);
						}
						if (mytree.GetNodeByValue(value) != null)
						{
							mytree.RemoveByValue(value);
							ClearTreeInConsole();
							mytree.PrintTree();
						}
						else
						{
							ClearTreeInConsole();
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							WriteColor($"Число {value} не существует в данном дереве", ConsoleColor.Red);
							Thread.Sleep(1500);
							ClearTreeInConsole();
							mytree.PrintTree();
						}
						break;
					}
				case ConsoleKey.D4:
				case ConsoleKey.NumPad4:
					{
						if (mytree.GetRoot() != null)
						{
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							var DFS = mytree.WalkDFS();
							var c = DFS.Count;
							WriteColor($"DFS:", ConsoleColor.Cyan);
							foreach (var i in DFS)
							{
								WriteColor($"{i}", ConsoleColor.Yellow);
								c--;
								if (c > 0) { WriteColor($"=>", ConsoleColor.DarkYellow); }
							}
						}
						else
						{
							Console.SetCursorPosition(0, 17);
							WriteColor("Дерево пустое", ConsoleColor.Red);
							Thread.Sleep(1500);
							ClearTreeInConsole();
						}
						break;
					}
				case ConsoleKey.D5:
				case ConsoleKey.NumPad5:
					{
						if (mytree.GetRoot() != null)
						{
							ClearTreeInConsole();
							mytree.PrintTree();
							Console.SetCursorPosition(0, 17);
							var BFS = mytree.WalkBFS();
							var c = BFS.Count;
							WriteColor($"BFS:", ConsoleColor.Cyan);
							foreach (var i in BFS)
							{
								WriteColor($"{i}", ConsoleColor.Yellow);
								c--;
								if (c > 0) { WriteColor($"=>", ConsoleColor.DarkYellow); }
							}
						}
						else
						{
							Console.SetCursorPosition(0, 17);
							WriteColor("Дерево пустое", ConsoleColor.Red);
							Thread.Sleep(1500);
							ClearTreeInConsole();

						}
						break;
					}
				case ConsoleKey.D6:
				case ConsoleKey.NumPad6:
					{
						if (mytree.GetRoot() != null) { mytree.ClearTree(); }
						break;
					}
				case ConsoleKey.D0:
				case ConsoleKey.NumPad0:
					{
						Console.SetCursorPosition(0, 17);
						WriteColor("До свидания!", ConsoleColor.Green);
						Thread.Sleep(1500);
						Console.Clear();
						break;
					}
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