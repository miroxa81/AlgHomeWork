using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	class DistanceCalcValueTypeFloat
	{
		[Benchmark]
		public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return MathF.Sqrt((x * x) + (y * y));
		}
	}
}
