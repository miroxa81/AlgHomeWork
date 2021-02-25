using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
	public static class BinSearch
	{
		public static int BinarySearch(int[] inputArray, int searchValue)
		{
			int min = 0; //O(1)
			int max = inputArray.Length - 1;//O(1)
			while (min <= max)//O(log2(N)).
			{
				int mid = (min + max) / 2;
				if (searchValue == inputArray[mid])
				{
					return mid;
				}
				else if (searchValue < inputArray[mid])
				//Максимальное кол-во выполнений цикла будет N/(2^x)=1
				// соответственно N=2^x
				//N=log 2 (2^x) => log2(N) = x log2(2) => log2(N)= x
				{
					max = mid - 1;
				}
				else
				{
					min = mid + 1;
				}
			}
			return -1;//O(1)
		}
	}
}
