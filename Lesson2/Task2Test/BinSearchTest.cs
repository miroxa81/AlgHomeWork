using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;


namespace Task2Test
{
	[TestClass]
	public class BinSearchTest
	{
		[TestMethod]
		public void BinarySearch_25_Exp_7_Test()
		{
			int[] testArr = new int[9] { -10, -5, -1, 0, 1, 3, 8,13 ,25 };
			int testValue = 25;
			int Expected = 8;
			//Arrange
			//Act
			int Actual = BinSearch.BinarySearch(testArr, testValue);
			//Assert
			Assert.AreEqual(Expected, Actual);
		}

		[TestMethod]
		public void BinarySearch_0_Exp_3_Test()
		{
			int[] testArr = new int[6] { -8, -2, -1, 0, 3, 16 };
			int testValue = 0;
			int Expected = 3;
			//Arrange
			//Act
			int Actual = BinSearch.BinarySearch(testArr, testValue);
			//Assert
			Assert.AreEqual(Expected, Actual);
		}
		[TestMethod]
		public void BinarySearch_minus5_Exp_1_Test()
		{
			int[] testArr = new int[8] { -10, -5, -1, 0, 1, 3, 8, 25 };
			int testValue = -5;
			int Expected = 1;
			//Arrange
			//Act
			int Actual = BinSearch.BinarySearch(testArr, testValue);
			//Assert
			Assert.AreEqual(Expected, Actual);
		}
		[TestMethod]
		public void BinarySearch_noData_Exp_minus1_Test()
		{
			int[] testArr = new int[8] { -10, -5, -1, 0, 1, 3, 8, 25 };
			int testValue = -4;
			int Expected = -1;
			//Arrange
			//Act
			int Actual = BinSearch.BinarySearch(testArr, testValue);
			//Assert
			Assert.AreEqual(Expected, Actual);
		}


	}
}
