using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int sizeArray = 10;
			const int sizeBucket = 20;// размер блока в процентах от размера массива

			var testArray = RandomArray(sizeArray);
			for (int i = 0; i < sizeArray; i++)
			{
				Console.Write($"{testArray[i]}; ");

			}
			Console.Write($"\n");
			testArray = BucketSort(testArray, sizeBucket);

			for (int i = 0; i < sizeArray; i++)
			{
				Console.Write($"{testArray[i]}; ");

			}

		}


		static int[] BucketSort(int[] sortableArray, int size)
		{
			int quantityBucket = sortableArray.Length * size / 100;
			int averageBucketSize = sortableArray.Length / quantityBucket;
			int[] resultArray = new int[sortableArray.Length];
			Queue<int>[] bucketsArray = new Queue<int>[quantityBucket];

			for (int i = 0; i < quantityBucket; i++)
			{
				bucketsArray[i] = new Queue<int>();
			}

			for (int i = 0; i < sortableArray.Length; i++)
			{
				int currentBucket = sortableArray[i] % averageBucketSize;

				if (bucketsArray[currentBucket].Count == 0)
				{
					bucketsArray[currentBucket].Enqueue(sortableArray[i]);
				}
				else
				{
					while (sortableArray[i] > bucketsArray[currentBucket].Peek())
					{
						bucketsArray[currentBucket].Enqueue(bucketsArray[currentBucket].Dequeue());
					}
				}
			}
			for (int currentBucket = 0; currentBucket < quantityBucket; currentBucket++)

				for (int i = 0; i < bucketsArray[currentBucket].Count; i++)
				{
					resultArray[i] = bucketsArray[currentBucket].Dequeue();
				}

			return resultArray;
		}




		static int[] RandomArray(int n)
		{
			int[] Arr = new int[n];
			for (int i = 0; i < n; i++)
			{
				Arr[i] = new Random().Next(10000);
			}
			return Arr;
		}
	}
}
