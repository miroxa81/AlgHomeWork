using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;


namespace Task1
{
	
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}


		[Config(typeof(MyCongig))]
		class MyCongig : ManualConfig
		{
			public MyCongig()
			{
				AddExporter(HtmlExporter.Default);
			}
		}
	}


	


}
