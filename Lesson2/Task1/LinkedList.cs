using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public class DoubleLinkedList : ILinkedList
	{
		public Node FirstNode { get; set; }
		public Node LastNode { get; set; }


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

			if (currentNode == LastNode)
			{
				LastNode.NextItem = newNode;
				newNode.PrevItem = LastNode;
				LastNode = newNode;
			}
			else
			{
				var nextNode = currentNode.NextItem;
				currentNode.NextItem = newNode;
				newNode.NextItem = nextNode;
				newNode.PrevItem = currentNode;
			}

		}

		public Node FindNode(int searchValue)
		{

			var currentNode = FirstNode;
			while (currentNode != null)
			{
				if (currentNode.Value == searchValue)
				{
					return currentNode;
				}
				currentNode = currentNode.NextItem;
			}
			return null;
		}
		public Node FindNodeByIndex(int index)
		{
			if (index < 0) { return null; }

			var currentIndex = 0;
			var currentNode = FirstNode;

			while (currentIndex < index)
			{
				currentNode = currentNode.NextItem;
				currentIndex++;
				if (currentNode.NextItem == null)
					if (currentIndex < index)
					{
						return null;
					}
					else
					{
						return LastNode;
					}

			}

			return currentNode;
		}
		public int GetCount()
		{
			int Count = 0;
			var currentNode = FirstNode;
			while (currentNode != null)
			{
				Count++;
				currentNode = currentNode.NextItem;
			}
			return Count;
		}

		public void OutAllList()
		{
			var currentNode = FirstNode;
			while (currentNode != null)
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
				FirstNode.PrevItem = null;
			}
			else
			if (index == GetCount() - 1)
			{
				var currentNode = LastNode.PrevItem;
				LastNode = currentNode;
				LastNode.NextItem = null;
			}
			else
			if (index != 0 && index != GetCount() - 1)
			{
				var currentNode = FirstNode;
				for (int i = 0; i < index; i++)
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
			var index = 0;
			var currentNode = FirstNode;
			while (currentNode != node)
			{
				currentNode = currentNode.NextItem;
				index++;
			}

			RemoveNode(index);
		}

	}
}
