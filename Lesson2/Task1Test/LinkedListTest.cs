using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Test
{
	[TestClass]
	public class LinkedListTest
	{

		[TestMethod]
		public void AddNode_One_EmptyList_Test()
		{
			//Arrange
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			int FirstNodeValue = 22;
			//Act
			MyTestList.AddNode(22);
			//Assert
			Assert.AreEqual(FirstNodeValue, MyTestList.FirstNode.Value);
			Assert.AreEqual(null, MyTestList.FirstNode.PrevItem);
			Assert.AreEqual(null, MyTestList.FirstNode.NextItem);
		}
		[TestMethod]
		public void AddNode_Two_Empty_Test()
		{
			//Arrange
			int FirstNodeValue = 22;
			int SecondNodeValue = 24;
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			//Act
			MyTestList.AddNode(22);
			MyTestList.AddNode(24);
			//Assert
			Assert.AreEqual(null, MyTestList.FirstNode.PrevItem);
			Assert.AreEqual(FirstNodeValue, MyTestList.FirstNode.Value);
			Assert.AreEqual(MyTestList.LastNode, MyTestList.FirstNode.NextItem);
			Assert.AreEqual(MyTestList.FirstNode, MyTestList.LastNode.PrevItem);
			Assert.AreEqual(SecondNodeValue, MyTestList.LastNode.Value);
			Assert.AreEqual(null, MyTestList.LastNode.NextItem);
		}
		[TestMethod]
		public void AddNode_Three_Empty_Test()
		{
			//Arrange
			int FirstNodeValue = 22;
			int SecondNodeValue = 24;
			int ThirdNodeValue = 26;
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			//Act
			MyTestList.AddNode(22);
			MyTestList.AddNode(24);
			MyTestList.AddNode(26);
			//Assert
			Assert.AreEqual(null, MyTestList.FirstNode.PrevItem);
			Assert.AreEqual(FirstNodeValue, MyTestList.FirstNode.Value);
			Assert.AreEqual(SecondNodeValue, MyTestList.FirstNode.NextItem.Value);
			Assert.AreEqual(SecondNodeValue, MyTestList.LastNode.PrevItem.Value);
			Assert.AreEqual(ThirdNodeValue, MyTestList.LastNode.Value);
			Assert.AreEqual(null, MyTestList.LastNode.NextItem);
		}


		[TestMethod]
		public void FindNodeByIndex_Test()
		{
			//Arrange
			int[] TestArray = { 22, 24, 26, 28, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}
			int ExpectedValue = 32;
			int testIndex = 5;
			//Act
			var ActualNode = MyTestList.FindNodeByIndex(testIndex);

			//Assert
			Assert.AreEqual(ExpectedValue, ActualNode.Value);
		}
		[TestMethod]
		public void FindNodeByIndex_Last_Test()
		{
			//Arrange
			int[] TestArray = { 22, 24, 26, 28, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}
			int ExpectedValue = 36;
			int testIndex = 7;
			//Act
			var ActualNode = MyTestList.FindNodeByIndex(testIndex);
			//Assert
			Assert.AreEqual(ExpectedValue, ActualNode.Value);
		}

		[TestMethod]
		public void FindNodeByIndex_OutOfRangeIndex_Test()
		{
			//Arrange
			int[] TestArray = { 22, 24, 26, 28, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}
			Node ExpectedNode = null;
			int testIndex = 15;
			//Act
			var ActualNode = MyTestList.FindNodeByIndex(testIndex);

			//Assert
			Assert.AreEqual(ExpectedNode, ActualNode);
		}

		[TestMethod]
		public void FindNodebyValueTest()
		{
			//Arrange
			int[] TestArray = { 22, 24, 26, 28, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}
			int testValue = 24;
			int testIndex = 1;
			Node ExpectedNode = MyTestList.FindNodeByIndex(testIndex);
			//Act
			var ActualNode = MyTestList.FindNode(testValue);
			//Assert
			Assert.AreEqual(ExpectedNode, ActualNode);
		}
		[TestMethod]
		public void FindNodebyValue_notFound_Test()
		{
			//Arrange
			int[] TestArray = { 22, 24, 26, 28, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}

			int testValue = 18;
			Node ExpectedNode = null;
			//Act
			var ActualNode = MyTestList.FindNode(testValue);
			//Assert
			Assert.AreEqual(ExpectedNode, ActualNode);
		}

		[TestMethod]
		public void AddNode44After_28_Test()
		{
			//Arrange
			int[] TestArray = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[9] { 22, 24, 26, 28, 44, 30, 32, 34, 36 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}

			int testIndex = 3;
			var testNode = MyTestList.FindNodeByIndex(testIndex);
			//Act
			MyTestList.AddNodeAfter(testNode, 44);

			//Assert
			int index = 0;
			while (MyTestList.FindNodeByIndex(index) != null)
			{
				var Result = MyTestList.FindNodeByIndex(index).Value;
				Assert.AreEqual(ExpectedArray[index], Result);
				index++;
			}
		}

		[TestMethod]
		public void AddNode44After_Last_Test()
		{
			//Arrange
			int[] TestArray = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[9] { 22, 24, 26, 28, 30, 32, 34, 36, 44 };
			DoubleLinkedList MyTestList = new DoubleLinkedList();
			for (int i = 0; i < TestArray.Length; i++)
			{
				MyTestList.AddNode(TestArray[i]);
			}
			int testIndex = 7;
			var testNode = MyTestList.FindNodeByIndex(testIndex);
			//Act
			MyTestList.AddNodeAfter(testNode, 44);

			//Assert
			int index = 0;
			while (MyTestList.FindNodeByIndex(index) != null)
			{
				var Result = MyTestList.FindNodeByIndex(index).Value;
				Assert.AreEqual(ExpectedArray[index], Result);
				index++;
			}
		}
	}
}
