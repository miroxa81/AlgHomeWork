using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;


namespace Task2
{
	public class Search
	{
		public static bool Hash(string target, HashSet<string> testHash)
		{
			return testHash.Contains(target);
		}
		public static bool Str(string target, string[] testString)
		{
			for (int i = 0; i < testString.Length; i++)
			{
				if (target == testString[i])
				{
					return true;
				}
			}
			return false;
		}


	}
}
