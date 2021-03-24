using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
	public class Sort
	{
		public static int[] Bucket(int[] sortableArray, int size)
		{
			List<int> result = new List<int>();
			if (sortableArray.Length == 0) { return result.ToArray() ; }
			int maxSortableArray = sortableArray[0];
			int minSortableArray = sortableArray[0];

			int quantityBucket = 100 / size;

			if (100 % size  != 0) { quantityBucket++; }

			
			List<int>[] bucketsArray = new List<int>[quantityBucket];

			for (int i = 0; i < quantityBucket; i++)
			{
				bucketsArray[i] = new List<int>();
			}

			for (int i = 0; i < sortableArray.Length; i++)
			{
				if (sortableArray[i] > maxSortableArray) maxSortableArray = sortableArray[i];
				if (sortableArray[i] < minSortableArray) minSortableArray = sortableArray[i];
			}

			int bucketEdge = (Math.Abs(maxSortableArray) + Math.Abs(minSortableArray)) / quantityBucket + 1;

			for (int i = 0; i < sortableArray.Length; i++)
			{
				int currentBucket = sortableArray[i] / bucketEdge;
				bucketsArray[currentBucket].Add(sortableArray[i]);
			}

			for (int currentBucket = 0; currentBucket < quantityBucket; currentBucket++)
			{
				bucketsArray[currentBucket].Sort();
			}

			
				for (int currentBucket = 0; currentBucket < quantityBucket; currentBucket++)

					foreach (var i in bucketsArray[currentBucket])
					{
						result.Add(i);
					}
			return result.ToArray(); ;
		}


	}
}
