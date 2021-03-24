using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int sizeBucket = 25;// размер блока в процентах от размера массива
			int[] testArray = new int[16] { 11, 2, 33, 24, 15, 6, 77, 98, 39, 45, 74, 12, 32, 0, -5, 42 };
			testArray = Sort.Bucket(testArray, sizeBucket);

			for (int i = 0; i < testArray.Length; i++)
			{
				Console.Write($"{testArray[i]}; ");
			}
		}
	}
}
