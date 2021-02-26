using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	public class DistanceCalcRefTypeFloat
	{
		public float Calculate(PointClass pointOne, PointClass pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return (x * x) + (y * y);
		}
		[Benchmark]
		public void BenchTestDistanceCalcRefTypeFloat_10_10_100_100()
		{
			PointClass startPoint = new PointClass { X = 10, Y = 100 };
			PointClass endPoint = new PointClass { X = 10, Y = 100 };
			Calculate(startPoint, endPoint);
		}
		[Benchmark]
		public void BenchTestDistanceCalcRefTypeFloat_10_10_500_500()
		{
			PointClass startPoint = new PointClass { X = 10, Y = 500 };
			PointClass endPoint = new PointClass { X = 10, Y = 500 };
			Calculate(startPoint, endPoint);
		}
		[Benchmark]
		public void BenchTestDistanceCalcRefTypeFloat_10_10_1000_1000()
		{
			PointClass startPoint = new PointClass { X = 10, Y = 1000 };
			PointClass endPoint = new PointClass { X = 10, Y = 1000 };
			Calculate(startPoint, endPoint);
		}
	}
}
