using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
namespace Test_Task1_Lesson8
{
	[TestClass]
	public class SortClassTest
	{

		const int sizeBucket = 25;// размер блока в процентах от размера массива
		int [] testArray = new int[14] { 11, 2, 33, 24, 15, 77, 98, 39,  74, 12, 32, 0, 5, 42 };

		[TestMethod]
		public void TestBucketSort()
		{
			//Arrange						   0,1,2,3,,4,,5,,6,,7,,8,,9,,10,11,12,13	
			int[] ExpectedArray = new int[14] {0,2,5,11,12,15,24,32,33,39,42,74,77,98 };
			//Act
			var ResultArray = Sort.Bucket(testArray, sizeBucket);
			//Assert
			Assert.AreEqual(ExpectedArray, ResultArray);




		}
	}
}
