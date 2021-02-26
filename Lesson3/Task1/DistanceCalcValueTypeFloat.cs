using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	public class DistanceCalcValueTypeFloat
	{

		var TestStartPoint = 
			(
			new PointStruct { X = 10, Y = 10 }, 
			new PointStruct { X = 10, Y = 10 },
			new PointStruct { X = 10, Y = 10 },
			) ;

			(PointStruct, PointStruct) TestStartPoint =
			(
			new PointStruct { X = 10, Y = 10 },
			new PointStruct { X = 10, Y = 10 }
			new PointStruct { X = 10, Y = 10 }
			) ;


public float Calculate(PointStruct pointOne, PointStruct pointTwo)
		{
			float x = pointOne.X - pointTwo.X;
			float y = pointOne.Y - pointTwo.Y;
			return MathF.Sqrt((x * x) + (y * y));
		}
		[Benchmark]
		public void BenchTestDistanceCalcValueTypeFloat()
		{
			Calculate(Test);
		}
	}
}
