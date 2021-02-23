using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			DoubleLinkedList MyList = new DoubleLinkedList();
			Node TestNode = new Node();
			MyList.AddNode(TestNode.Value = 22);
			






			//MyList.AddNode(rnd.Next(10));

			MyList.AddNodeAfter(TestNode, 3);
			int ListCount = MyList.GetCount();

			

			Console.WriteLine($"кол-во {ListCount}");

			


		}
	}
}
