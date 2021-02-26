using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	public class DistanceCalcValueTypeDouble
	{
		public double Calculate(PointStruct pointOne, PointStruct pointTwo)
		{
			double x = pointOne.X - pointTwo.X;
			double y = pointOne.Y - pointTwo.Y;
			return Math.Sqrt((x * x) + (y * y));
		}	
		[Benchmark]
		public void BenchDistanceCalcValueTypeDouble()
		{
			PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
			PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
			Calculate(startPoint, endPoint);
		}
	}
}
