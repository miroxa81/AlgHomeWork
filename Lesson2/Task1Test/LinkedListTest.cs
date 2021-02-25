using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Test
{
	[TestClass]
	public class LinkedListTest
	{
		DoubleLinkedList MyTestList = new DoubleLinkedList();
		int[] testArray = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
		public DoubleLinkedList FillList(int[] testArr)
		{
			var MyTL = new DoubleLinkedList();
			for (int i = 0; i < testArr.Length; i++)
			{
				MyTL.AddNode(testArr[i]);
			}
			return MyTL;
		}
		[TestMethod]
		public void AddNode_One_EmptyList_Test()
		{
			//Arrange
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
			MyTestList = FillList(testArray); // Test Array  = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray); //Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray); //Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray);// Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray); //Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray); //Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[9] { 22, 24, 26, 28, 44, 30, 32, 34, 36 };
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
			MyTestList = FillList(testArray); //Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[9] { 22, 24, 26, 28, 30, 32, 34, 36, 44 };
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
		[TestMethod]
		public void RemoveNodeByIndex_FirstIndex_Test()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[7] { 24, 26, 28, 30, 32, 34, 36 };
			int testIndex = 0;
			//Act
			MyTestList.RemoveNode(testIndex);
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
		public void RemoveNodeByIndex_LastIndex_Test()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[7] { 22, 24, 26, 28, 30, 32, 34 };
			int testIndex = 7;
			//Act
			MyTestList.RemoveNode(testIndex);
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
		public void RemoveNodeByIndex_5_Test()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[7] { 22, 24, 26, 28, 30, 34, 36 };
			int testIndex = 5;
			//Act
			MyTestList.RemoveNode(testIndex);
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
		public void RemoveNodeByIndex_OutOfRange_Test()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int testIndex = -2;
			//Act
			MyTestList.RemoveNode(testIndex);
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
		public void RemoveNode()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int[] ExpectedArray = new int[7] { 22, 24, 26, 28, 30, 34, 36 };
			int testIndex = 5;
			var testNode = MyTestList.FindNodeByIndex(testIndex);
			//Act
			MyTestList.RemoveNode(testNode);
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
		public void GetCountTest()
		{
			//Arrange
			MyTestList = FillList(testArray);//Test Array = new int[8] { 22, 24, 26, 28, 30, 32, 34, 36 };
			int Expected = 8;
			//Act
			int Result = MyTestList.GetCount();
			//Assert
			Assert.AreEqual(Expected, Result);
		}
	}
}
