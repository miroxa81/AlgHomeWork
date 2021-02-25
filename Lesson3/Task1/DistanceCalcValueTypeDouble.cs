using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	class DistanceCalcValueTypeDouble
	{
		[Benchmark]
		public static double PointDistance(PointStruct pointOne, PointStruct pointTwo)
		{
			double x = pointOne.X - pointTwo.X;
			double y = pointOne.Y - pointTwo.Y;
			return Math.Sqrt((x * x) + (y * y));
		}

	}
}
