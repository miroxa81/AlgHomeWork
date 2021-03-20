using System;
using System.Collections.Generic;
using System.Drawing;

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
			Node root = FilledGraph[0]; //new Random().Next(FilledGraph.Length)
			List<Node> DFS = WalkDFS(root);

			foreach (var node in DFS)
			{
				WriteColor($"{node.Name}, ",ConsoleColor.Green);
			}

		}


		static Node[] FillGraph(int[,] matrix)
		{
			Node[] Graph = new Node[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				Graph[i] = new Node();
				Graph[i].Name = Convert.ToString(i + 1);
				Graph[i].Edges = new List<Edge>();
			}
			//

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(0); j++)
					if (matrix[i, j] != 0)
					{
						Graph[i].Edges.Add(new Edge { Weight = matrix[i, j], Node = Graph[j] });
					}
			}
			return Graph;
		}


		static int[,] RandomMatrix(int n)
		{
			int[,] matrix = new int[n, n];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < i; j++)
				{
					if (i != j)
					{
						matrix[i, j] = matrix[j, i] = new Random().Next(0, 5);
					}
				}
			return matrix;
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

		static List<Node> WalkDFS(Node root)//Lesson 5 
		{
			List<Node> DFSlist = new List<Node>();
			var GraphStack = new Stack<Node>();

			GraphStack.Push(root);

			while (GraphStack.Count > 0)
			{
				var element = GraphStack.Peek();

				if (element.status == Status.white)
				{
					element.status = Status.gray;


					foreach (var currentEdge in element.Edges )

						
					{
						if (currentEdge.Node.status == Status.white)
						{
							GraphStack.Push(currentEdge.Node);
						}
					}
				}
				if (element.status == Status.gray)
				{
					element.status = Status.black;
					DFSlist.Add(GraphStack.Pop());
				}
				if (element.status == Status.black)
				{
	
					DFSlist.Add(GraphStack.Pop());
				}
				

			}
			DFSlist.Reverse();
			return DFSlist;
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
