using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		const int n = 8;
		static void Main(string[] args)
		{
			Queue<Node> nodelist = new Queue<Node>();
			
			int[] peaks = new int[n];
			int[,] matrix = RandomMatrix(n);

					
			OutMatrix(matrix);
			Node[] FilledGraph = FillGraph(matrix);
		}



		static void OutMatrix(int[,] matrix)
		{
			string[] head = new string[9] { "", "A", "B", "C", "D", "E", "F", "G", "H" };

			for (int i = 0; i <= matrix.GetLength(0); i++)
			{
				for (int j = 0; j <= matrix.GetLength(1); j++)
				{
					if (i == 0)
					{
						WriteColor($"{head[j],3}", ConsoleColor.Green);
					}
					else
					if (j == 0)
					{
						WriteColor($"{head[i],3}", ConsoleColor.Green);
					}
					else
					if (i == j)
					{
						WriteColor($"{matrix[i - 1, j - 1],3}", ConsoleColor.Yellow);
					}
					else
					{
						WriteColor($"{matrix[i - 1, j - 1],3}", ConsoleColor.Cyan);
					}
				}
				Console.WriteLine();
			}

		}


		/*public List<int> WalkDFS()//Lesson 5 
		{
			List<int> DFSlist = new List<int>();


			var TreeStack = new Stack<TreeNode>();
			TreeStack.Push(root);

			while (TreeStack.Count > 0)
			{
				var element = TreeStack.Pop();
				DFSlist.Add(element.Data);

				if (element.RightChild != null) TreeStack.Push(element.RightChild);
				if (element.LeftChild != null) TreeStack.Push(element.LeftChild);
			}

			return DFSlist;
		}
		public List<int> WalkBFS()//Lesson 5 
		{
			List<int> BFSlist = new List<int>();
			var TreeQueue = new Queue<TreeNode>();
			TreeQueue.Enqueue(root);

			while (TreeQueue.Count > 0)
			{
				var element = TreeQueue.Dequeue();
				BFSlist.Add(element.Data);
				if (element.LeftChild != null) TreeQueue.Enqueue(element.LeftChild);
				if (element.RightChild != null) TreeQueue.Enqueue(element.RightChild);

			}
			return BFSlist;
		}*/


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
