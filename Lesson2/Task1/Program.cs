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
			Node TestNode = new Node { Value = 22};
			MyList.AddNode(22);
			
			






			//MyList.AddNode(rnd.Next(10));

			MyList.AddNodeAfter(MyList.Equals, 3);
			int ListCount = MyList.GetCount();

			

			Console.WriteLine($"кол-во {ListCount}");

			


		}
	}
}
