using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	class DoubleLinkedList : ILinkedList
	{
		Node FirstNode = new Node();
		Node LastNode = new Node();
		public void AddNode(int value)
		{
			{
	
				if (LastNode.PrevItem == null)
				{
					FirstNode.Value = value;
					FirstNode.NextItem = LastNode;
					LastNode.PrevItem = FirstNode;
				}
				else
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
			if (nextNode.NextItem == null) LastNode = nextNode;
			LastNode.PrevItem = node;

		}

		public Node FindNode(int searchValue)
		{
			throw new NotImplementedException();
		}

		public int GetCount()
		{
			int Count = 0;
			Node node = FirstNode;
			while (node.NextItem != null)
			{
				node = node.NextItem;
				Count += 1;
			}
			return Count;
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
