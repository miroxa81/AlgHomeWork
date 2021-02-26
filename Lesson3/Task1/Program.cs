using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
			//BenchmarkSwitcher.FromAssembly(typeof(DistanceCalcValueTypeDouble).Assembly).Run(args);
			//BenchmarkSwitcher.FromAssembly(typeof(DistanceCalcValueTypeFloat).Assembly).Run(args);
			//BenchmarkSwitcher.FromAssembly(typeof(DistanceCalcRefTypeFloat).Assembly).Run(args);

		}
	}


	


}
