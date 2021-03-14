using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public interface ITree
	{
		TreeNode GetRoot();
		void PrintTree();
		TreeNode GetNodeByValue(int value);
		void AddValue(int value);
		void RemoveByValue(int value);
}
}
