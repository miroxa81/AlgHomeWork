using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			DoubleLinkedList MyList = new DoubleLinkedList();
			MyList.AddNode(22);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(24);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(26);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(28);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(30);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(32);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(34);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();
			MyList.AddNode(36);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();


				var TestNode = MyList.FindNode(32);

				Console.WriteLine($"Тест нода:{TestNode.Value}");
				MyList.AddNodeAfter(TestNode, 44);
				Console.WriteLine($"Количество: {MyList.GetCount()}");
				MyList.OutAllList();

			MyList.RemoveNode(TestNode);
			Console.WriteLine($"Количество: {MyList.GetCount()}");
			MyList.OutAllList();


		}
	}
}
