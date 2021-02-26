using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	class Program
	{

		public class PointClass
		{
			public int X;
			public int Y;
		}

		public struct PointStruct
		{
			public int X;
			public int Y;
		}
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}

		public class BechmarkClass
		{
			public float DistanceShortCalcValueTypeFloat(PointStruct pointOne, PointStruct pointTwo)
			{
				float x = pointOne.X - pointTwo.X;
				float y = pointOne.Y - pointTwo.Y;
				return (x * x) + (y * y);
			}

			public double DistanceCalcValueTypeDouble(PointStruct pointOne, PointStruct pointTwo)
			{
				double x = pointOne.X - pointTwo.X;
				double y = pointOne.Y - pointTwo.Y;
				return Math.Sqrt((x * x) + (y * y));
			}

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
			public void TestDistanceShortCalcValueTypeFloat()
			{
				PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
				PointStruct endPoint = new PointStruct { X = 123, Y = 123 };

				DistanceShortCalcValueTypeFloat(startPoint, endPoint);
			}

		}
	}
}
