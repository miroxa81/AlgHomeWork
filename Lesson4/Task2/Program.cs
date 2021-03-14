using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

/*
_______________________________________________________________________________
| Method            | TestTarget  | Mean          | Error       | StdDev      |
| ------------------| ----------- | -------------:| -----------:| -----------:|
| 'Поиск в HashSet' | 3_j(Z       | 13.53 ns      | 0.292 ns    | 0.390 ns    |
| 'Поиск в HashSet' | Wv]? l      | 11.33 ns      | 0.116 ns    | 0.103 ns    |
| 'Поиск в массиве' | p1dy0       | 41,702.50 ns  | 265.709 ns  | 235.544 ns  |
| 'Поиск в массиве' | uD Yd       | 41,202.24 ns  | 213.771 ns  | 199.962 ns  |
|___________________|_____________|_______________|_____________|_____________|
*/





namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
/*			RandomWords test = new RandomWords();
			Search.Str(test.word[new Random().Next(10000)], test.word);
			Search.Hash(test.word[new Random().Next(10000)], test.hash);*/

				BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}
	}

	public class Test
	{
		readonly RandomWords test = new RandomWords(5);


		public IEnumerable<object> TestTarget() 
		{
			yield return test.word[new Random().Next(10000)];
			yield return test.word[new Random().Next(10000)];

		}

		[Benchmark(Description = "Поиск в массиве")]
		[ArgumentsSource(nameof(TestTarget))]
		public void BenchmarkStringSearch(string TestTarget)
		{
			Search.Str(TestTarget, test.word);
		}

		[Benchmark(Description = "Поиск в HashSet")]
		[ArgumentsSource(nameof(TestTarget))]
		public void BenchmarkHashSetSearch(string TestTarget)
		{
			Search.Hash(TestTarget, test.hash);
		}
	}

}
