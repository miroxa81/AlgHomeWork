using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public class TreeNode
	{
		public int Data { get; set; }
		public TreeNode LeftChild { get; set; }
		public TreeNode RightChild { get; set; }
		public int DataLenght
		{
			get 
			{ 
				return Data.ToString().Length; 
			}
		}
		public override bool Equals(object obj)
		{
			if (!(obj is TreeNode node))
				return false;
			return node.Data == Data;
		}
	}
}
