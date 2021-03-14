using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
	public class RandomWords
	{
		public string[] word = new string[10000]; 
		public HashSet<string> hash = new HashSet<string>();

		public RandomWords(int n)
		{
			for (int i = 0; i < word.Length; i++)
			{
				word[i] = new RandomString().Next(n);
				hash.Add(word[i]);
			}
		}
	}

}
