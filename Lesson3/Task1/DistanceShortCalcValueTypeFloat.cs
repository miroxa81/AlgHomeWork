using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{


	public class DistanceShortCalcValueTypeFloat
	{
		public float Calculate(PointStruct pointOne, PointStruct pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return (x * x) + (y * y);
		}
		[Benchmark]
		public void BenchTestCalculate()
		{
			PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
			PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
			Calculate(startPoint, endPoint);
		}
	}
}
