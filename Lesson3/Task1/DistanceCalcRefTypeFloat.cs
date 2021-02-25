using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	class DistanceCalcRefTypeFloat
	{
		[Benchmark]
		public static float PointDistance(PointClass pointOne, PointClass pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return (x * x) + (y * y);
		}

	}
}
