using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
namespace Test_Task1_Lesson8
{
	[TestClass]
	public class SortClassTest
	{

		const int sizeBucket = 25;// размер блока в процентах от размера массива

		int[] testArray1 = new int[1] {11};
		int[] testArray1_equal_1 = new int[2] { 2, 2};

		int[] testArray2 = new int[2] {42, -5 };
		int[] testArray14 = new int[14] { 11, 2, 33, 24, 15, 77, 98, 39, 74, 12, 32, 0, 5, 42 };
		int[] testArray0 = new int[0] {};

		[TestMethod]
		public void TestBucketSort14()
		{
			//Arrange						
			int[] ExpectedArray = new int[14] { 0, 2, 5, 11, 12, 15, 24, 32, 33, 39, 42, 74, 77, 98 };
			//Act
			var ResultArray = Sort.Bucket(testArray14, sizeBucket);
			//Assert
			CollectionAssert.AreEqual(ExpectedArray, ResultArray);
		}

		[TestMethod]
		public void TestBucketSort1_equal_1()
		{
			//Arrange						
			int[] ExpectedArray = new int[2] { 2,2 };
			//Act
			var ResultArray = Sort.Bucket(testArray1_equal_1, sizeBucket);
			//Assert
			CollectionAssert.AreEqual(ExpectedArray, ResultArray);
		}
		[TestMethod]
		public void TestBucketSort2()
		{
			//Arrange						
			int[] ExpectedArray = new int[2] { 42, -5 };
			//Act
			var ResultArray = Sort.Bucket(testArray2, sizeBucket);
			//Assert
			CollectionAssert.AreEqual(ExpectedArray, ResultArray);
		}
		[TestMethod]
		public void TestBucketSort0()
		{
			//Arrange						
			int[] ExpectedArray = new int[0] { };
			//Act
			var ResultArray = Sort.Bucket(testArray0, sizeBucket);
			//Assert
			CollectionAssert.AreEqual(ExpectedArray, ResultArray);
		}
		[TestMethod]
		public void TestBucketSort1()
		{
			//Arrange						
			int[] ExpectedArray = new int[1] { 11};
			//Act
			var ResultArray = Sort.Bucket(testArray1, sizeBucket);
			//Assert
			CollectionAssert.AreEqual(ExpectedArray, ResultArray);
		}

	}
}
