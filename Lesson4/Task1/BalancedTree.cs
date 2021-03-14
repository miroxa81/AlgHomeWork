using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task1
{
	class BalancedTree : ITree
	{
		TreeNode root;
		public TreeNode GetRoot()//ITree 
		{
			return root;
		}

		public void ClearTree()
		{
			root = null;
		}
		public void AddValue(int value) //ITree
		{
			TreeNode node = new TreeNode { Data = value };

			if (root == null)
			{
				root = node;
			}
			else
			{
				root = Insert(root, node);
			}
		}
		private TreeNode Insert(TreeNode currentNode, TreeNode newNode)
		{
			if (currentNode == null)
			{
				currentNode = newNode;
				return currentNode;
			}
			else
			{
				if (newNode.Data < currentNode.Data)
				{
					currentNode.LeftChild = Insert(currentNode.LeftChild, newNode);
					currentNode = Balance(currentNode);
				}
				else
				{
					currentNode.RightChild = Insert(currentNode.RightChild, newNode);
					currentNode = Balance(currentNode);
				}
			}
			return currentNode;
		}
		public TreeNode FindByValue(int value, TreeNode currentNode)//ITree
		{
			if (value < currentNode.Data)
			{
				if (value == currentNode.Data)
				{
					return currentNode;
				}
				else
				if (currentNode.LeftChild != null)
					return FindByValue(value, currentNode.LeftChild);
				else return null;
			}
			else
			{
				if (value == currentNode.Data)
				{
					return currentNode;
				}
				else
					if (currentNode.RightChild != null)
					return FindByValue(value, currentNode.RightChild);
				else return null;
			}
		}
		public TreeNode GetNodeByValue(int value)//ITree
		{
			if (root == null) return null;
			else
				return FindByValue(value, root);
		}

		public void RemoveByValue(int value)//ITree
		{
			root = Delete(root, value);
		}
		private TreeNode Delete(TreeNode cureentNode, int target)
		{
			TreeNode parentNode;
			if (cureentNode == null) { return null; }
			else
			{
				if (target < cureentNode.Data)
				{
					cureentNode.LeftChild = Delete(cureentNode.LeftChild, target);
					if (BalanceFactor(cureentNode) == -2)
					{
						if (BalanceFactor(cureentNode.RightChild) <= 0)
						{
							cureentNode = Right_Rotate(cureentNode);
						}
						else
						{
							cureentNode = Right_left_Rotate(cureentNode);
						}
					}
				}
				else if (target > cureentNode.Data)
				{
					cureentNode.RightChild = Delete(cureentNode.RightChild, target);
					if (BalanceFactor(cureentNode) == 2)
					{
						if (BalanceFactor(cureentNode.LeftChild) >= 0)
						{
							cureentNode = Left_Rotate(cureentNode);
						}
						else
						{
							cureentNode = Left_right_Rotate(cureentNode);
						}
					}
				}
				else
				{
					if (cureentNode.RightChild != null)
					{

						parentNode = cureentNode.RightChild;
						while (parentNode.LeftChild != null)
						{
							parentNode = parentNode.LeftChild;
						}
						cureentNode.Data = parentNode.Data;
						cureentNode.RightChild = Delete(cureentNode.RightChild, parentNode.Data);
						if (BalanceFactor(cureentNode) == 2)
						{
							if (BalanceFactor(cureentNode.LeftChild) >= 0)
							{
								cureentNode = Left_Rotate(cureentNode);
							}
							else { cureentNode = Left_right_Rotate(cureentNode); }
						}
					}
					else
					{
						return cureentNode.LeftChild;
					}
				}
			}
			return cureentNode;
		}
		private TreeNode Balance(TreeNode currentNode)
		{
			int bf = BalanceFactor(currentNode);
			if (bf > 1)
			{
				if (BalanceFactor(currentNode.LeftChild) > 0)
				{
					currentNode = Left_Rotate(currentNode);
				}
				else
				{
					currentNode = Left_right_Rotate(currentNode);
				}
			}
			else if (bf < -1)
			{
				if (BalanceFactor(currentNode.RightChild) > 0)
				{
					currentNode = Right_left_Rotate(currentNode);
				}
				else
				{
					currentNode = Right_Rotate(currentNode);
				}
			}
			return currentNode;
		}
		public void PrintTree()//ITree
		{
			var h = GetNodeHight(root);
			var w = Convert.ToInt32(Math.Pow(2, h) * (FindMax().ToString().Length + 6));
			if (w > Console.WindowWidth) 
			{ 
				Console.WindowWidth = w; 
			}
			DispayOut(root, 1, 0, w);
			Console.WriteLine();
		}
		private void DispayOut(TreeNode currentNode, int y, int x_left, int x_right)
		{
			if (currentNode != null)
			{
				var x = x_left + (x_right - x_left) / 2;

				Console.SetCursorPosition(x, y);
				WriteColor($"[", ConsoleColor.DarkYellow);

				WriteColor($"{currentNode.Data}", ConsoleColor.Gray);

				WriteColor($"]", ConsoleColor.DarkYellow);

				if (currentNode.LeftChild != null)
				{
					Console.SetCursorPosition(x + 1, y + 1);
					WriteColor("┘", ConsoleColor.DarkRed);

					DrawLine(x, (x - (x_right - x_left) / 4 + currentNode.LeftChild.DataLenght), y, ConsoleColor.DarkRed);

					Console.SetCursorPosition((x - (x_right - x_left) / 4 + currentNode.LeftChild.DataLenght), y + 1);
					WriteColor("┌", ConsoleColor.DarkRed);
				}
				if (currentNode.RightChild != null)
				{
					Console.SetCursorPosition(x + currentNode.DataLenght, y + 1);
					WriteColor("└", ConsoleColor.DarkGreen);
					DrawLine((x + currentNode.DataLenght + 1), (x + (x_right - x_left) / 4) + 1, y, ConsoleColor.DarkGreen);
					Console.SetCursorPosition((x + (x_right - x_left) / 4) + 1, y + 1);
					WriteColor("┐", ConsoleColor.DarkGreen);
				}
				y++;
				DispayOut(currentNode.LeftChild, y + 1, x_left, x);
				DispayOut(currentNode.RightChild, y + 1, x, x_right);
			}
		}
		private void DrawLine(int start, int end, int y, ConsoleColor c)
		{
			if (start < end)
			{
				while (start != end)
				{
					Console.SetCursorPosition(start, y + 1);
					WriteColor($"─", c); //Thread.Sleep(50 * y);

					start++;
				}
			}
			else
			{
				while (start != end)
				{
					Console.SetCursorPosition(start, y + 1);
					WriteColor($"─", c); //Thread.Sleep(50 * (y + 1));
					start--;
				}
			}
		}
		/*	private int DispayOutHoriz(TreeNode currentNode, int x, int y)
			{
				Console.SetCursorPosition(x, y);
				WriteColor($"[{currentNode.Data}]", ConsoleColor.Gray);

				int level = y;

				if (currentNode.RightChild != null)
				{
					Console.SetCursorPosition(x + currentNode.DataLenght + 2, y);
					WriteColor("==", ConsoleColor.Green);
					y = DispayOutHoriz(currentNode.RightChild, x + 8, y);
				}

				if (currentNode.LeftChild != null)
				{
					while (level <= y)
					{
						Console.SetCursorPosition(x + (currentNode.DataLenght + 2) / 2, level + 1);
						WriteColor("║", ConsoleColor.Red);
						level++;
					}
					y = DispayOutHoriz(currentNode.LeftChild, x, y + 2);
				}

				return y;
			}*/
		private int FindMax()
		{
			if (root == null)
				throw new InvalidOperationException("Tree is empty");
			var currentNode = root;
			while (currentNode.RightChild != null)
				currentNode = currentNode.RightChild;
			return currentNode.Data;
		}
		private int GetNodeHight(TreeNode currentNode)
		{
			if (currentNode == null)
			{ return -1; }
			return 1 + Math.Max(GetNodeHight(currentNode.LeftChild), GetNodeHight(currentNode.RightChild));
		}
		private void WriteColor(string txt, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(txt);
			Console.ResetColor();
		}
		private int GetHeight(TreeNode currentNode)
		{
			int height = 0;
			if (currentNode != null)
			{
				int left_h = GetHeight(currentNode.LeftChild);
				int right_h = GetHeight(currentNode.RightChild);
				int max_h = Math.Max(left_h, right_h);
				height = max_h + 1;
			}
			return height;
		}
		private int BalanceFactor(TreeNode currentNode)
		{
			int left_h = GetHeight(currentNode.LeftChild);
			int right_h = GetHeight(currentNode.RightChild);
			int b_factor = left_h - right_h;
			return b_factor;
		}
		private TreeNode Right_Rotate(TreeNode parentNode)
		{
			TreeNode pivot = parentNode.RightChild;
			parentNode.RightChild = pivot.LeftChild;
			pivot.LeftChild = parentNode;
			return pivot;
		}
		private TreeNode Left_Rotate(TreeNode parentNode)
		{
			TreeNode pivot = parentNode.LeftChild;
			parentNode.LeftChild = pivot.RightChild;
			pivot.RightChild = parentNode;
			return pivot;
		}
		private TreeNode Left_right_Rotate(TreeNode parentNode)
		{
			TreeNode pivot = parentNode.LeftChild;
			parentNode.LeftChild = Right_Rotate(pivot);
			return Left_Rotate(parentNode);
		}
		private TreeNode Right_left_Rotate(TreeNode parentNode)
		{
			TreeNode pivot = parentNode.RightChild;
			parentNode.RightChild = Left_Rotate(pivot);
			return Right_Rotate(parentNode);
		}
		public List<int> WalkDFS()//Lesson 5 
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
		}
	}
}
