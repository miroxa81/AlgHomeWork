using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			Console.WriteLine($"Странная сумма массива: {StrangeSum(Arr)}.\nСложность метода StrangeSum() - O(N^3).");
			Console.ReadKey();
		}


		public static int StrangeSum(int[] inputArray)
		{
			int sum = 0;  // O(1)

			for (int i = 0; i < inputArray.Length; i++) // O(N)
			{
				for (int j = 0; j < inputArray.Length; j++) // O(N)
				{
					for (int k = 0; k < inputArray.Length; k++) // O(N)
					{
						int y = 0; // O(1)


						if (j != 0)// O(1)
						{
							y = k / j;// O(1)
						}

						sum += inputArray[i] + i + k + j + y;// O(1)
					}
				}
			}

			return sum;// O(1)
		}


	}
}
// O(1+N*N*N+1+1+1+1+1)=O(N^3+6) => O(N^3). Асимптотическая сложность функции StrangeSum O(N^3).