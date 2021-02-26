using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(CalcDistance).Assembly).Run(args);
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}
	}


	public class Test
	{
		public float DistanceCalcValueTypeFloat(PointStruct pointOne, PointStruct pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return MathF.Sqrt((x * x) + (y * y));
		}

		public float DistanceCalcRefTypeFloat(PointClass pointOne, PointClass pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return (x * x) + (y * y);
		}
		[Benchmark]
		public void BenchTestDistanceCalcValueTypeFloat()
		{
			PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
			PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
			DistanceCalcValueTypeFloat(startPoint, endPoint);
		}
		[Benchmark]

		public void BenchTestDistanceCalcRefTypeFloat()
		{
			PointClass startPoint = new PointClass { X = 10, Y = 123 };
			PointClass endPoint = new PointClass { X = 10, Y = 123 };
			DistanceCalcRefTypeFloat(startPoint, endPoint);
		}
	}


}
