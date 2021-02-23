using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	class DoubleLinkedList : ILinkedList
	{
		private Node FirstNode { get; set; }
		private Node LastNode { get; set; }


		public void AddNode(int value)
		{
			{
				if (LastNode == null && FirstNode == null)
				{
					var newNode = new Node { Value = value };
					FirstNode = newNode;
				}
				else
				if (LastNode == null && FirstNode != null)
				{
					var newNode = new Node { Value = value };
					LastNode = newNode;
					FirstNode.NextItem = LastNode;
					LastNode.PrevItem = FirstNode;
				}
				else
				if (LastNode != null && FirstNode != null)
				{
					var newNode = new Node { Value = value };
					LastNode.NextItem = newNode;
					newNode.PrevItem = LastNode;
					LastNode = newNode;
				}
			}
		}

		public void AddNodeAfter(Node node, int value)
		{
			var newNode = new Node { Value = value };
			var nextNode = node.NextItem;
			node.NextItem = newNode;
			newNode.NextItem = nextNode;
			nextNode.PrevItem = node;
			if (nextNode.NextItem == null) LastNode = nextNode;
		}

		public Node FindNode(int searchValue)
		{

			var node = FirstNode;
			while (node != LastNode)
			{
				if (node.Value == searchValue)
				{
					return node;
				}
				node = node.NextItem;
			}
			return null;
		}

		public int GetCount()
		{
			int Count = 0;
			var node = FirstNode;
			while (node != LastNode)
			{
				Count++;
				node = node.NextItem;
			}
			return Count;
		}


		public void OutAllList()
		{
			var node = FirstNode;
			while (true)
			{
				if (node.NextItem != null) Console.WriteLine($"{node.Value}");
				else return;
				node = node.NextItem;
			}

		}
		public void RemoveNode(int index)
		{
			throw new NotImplementedException();
		}

		public void RemoveNode(Node node)
		{
			throw new NotImplementedException();
		}

	}
}
