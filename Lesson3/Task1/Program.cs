using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

			 PointStruct PointOneSt = new PointStruct { X = 10, Y = 10 };
			PointStruct PointTwoSt= new PointStruct { X = 20, Y = 20 };
			PointClass PointOneCl = new PointClass { X = 10, Y = 10 };
			PointClass PointTwoCl = new PointClass { X = 20, Y = 20 };

			

			DistanceCalcValueTypeDouble.PointDistance(PointOneSt, PointTwoSt);
			DistanceCalcValueTypeFloat.PointDistance(PointOneSt, PointTwoSt);
			DistanceShortCalcValueTypeFloat.PointDistance(PointOneSt, PointTwoSt);
			DistanceCalcRefTypeFloat.PointDistance(PointOneCl, PointTwoCl);

		}
	}
}
