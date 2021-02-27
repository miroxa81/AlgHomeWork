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
		[Benchmark(Description = "Метод без кв. корня. Тип-Value. Значения-float")]
		[Arguments(10, 10, 100, 100)]
		[Arguments(10, 10, 200, 200)]
		[Arguments(10, 10, 300, 300)]
		[Arguments(10, 10, 400, 400)]
		[Arguments(10, 10, 500, 500)]
		public void BenchTestDistanceShortCalcValueTypeFloat(int x1, int y1, int x2, int y2)
		{
			PointStruct startPoint = new PointStruct { X = x1, Y = y1 };
			PointStruct endPoint = new PointStruct { X = x2, Y = y2 };
			Calculate(startPoint, endPoint);
		}
	}
}
