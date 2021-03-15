using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int n= 20; // кол-во вершин графа
			List<Node> Graph = new List<Node>();



			for (int i = 0; i <n; i++)
			{
				Node newNode = new Node();
				
				newNode.Name = new RandomString().Next(5);
				newNode.Edges.
			}
		}
	}
}
