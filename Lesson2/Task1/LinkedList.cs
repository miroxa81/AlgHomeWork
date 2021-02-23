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

		public void AddNodeAfter(Node currentNode, int value)
		{
			var newNode = new Node { Value = value };
			var nextNode = currentNode.NextItem;

			currentNode.NextItem = newNode;
			newNode.NextItem = nextNode;
			nextNode.PrevItem = currentNode;

			if (nextNode.NextItem == null)
			{
				LastNode = nextNode; 
			}
		}

		public Node FindNode(int searchValue)
		{
			var currentNode = FirstNode;
			while (currentNode != LastNode)
			{
				if (currentNode.Value == searchValue)
				{
					return currentNode;
				}
				currentNode = currentNode.NextItem;
			}
			return null;
		}
		public int GetCount()
		{
			int Count = 0;
			var currentNode = FirstNode;
			while (currentNode != LastNode)
			{
				Count++;
				currentNode = currentNode.NextItem;
			}
			return Count;
		}

		public void OutAllList()
		{
			var currentNode = FirstNode;
			while (currentNode != LastNode)
			{
				Console.WriteLine($"{currentNode.Value}");
				currentNode = currentNode.NextItem;
			}

		}
		public void RemoveNode(int index)
		{
			if (index < 0 || index > GetCount() - 1)
			{
				Console.WriteLine($"Нет элемента с таким индексом");
			}
			else
			if (index == 0)
			{
				var currentNode = FirstNode.NextItem;
				FirstNode = currentNode;
			}
			else
			if (index == GetCount() - 1)
			{
				var currentNode = LastNode.PrevItem;
				LastNode = currentNode;
			}
			else
			if (index != 1 && index != GetCount() - 1)
			{
				var currentNode = FirstNode;
				for (int i = 0; i < index - 1; i++)
				{
					currentNode = currentNode.NextItem;
				}
				var nextNode = currentNode.NextItem;
				var prevNode = currentNode.PrevItem;

				nextNode.PrevItem = prevNode;
				prevNode.NextItem = nextNode;
			}
		}

		public void RemoveNode(Node node)
		{
			int index = 0;
			var currentNode = FirstNode;
			while (currentNode != node)
			{
				index++;
				currentNode = currentNode.NextItem;
			}
			RemoveNode(index+1);
		}

	}
}
