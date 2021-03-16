using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	class RandomFillGraph
	{
		private Node[] FillGraph(int[,] matrix)
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


		private int[,] RandomMatrix(int n)
		{
			int[,] matrix = new int[n, n];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < i; j++)
				{
					if (i != j)
					{
						matrix[i, j] = matrix[j, i] = new Random().Next(0, 9);
					}
				}
			return matrix;
		}
	}
}
