using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

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
