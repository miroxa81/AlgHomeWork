using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{

		public class RandomString
		{
			public string Next(int n)
			{
				var rndstr = "";
				var r = new Random();
				for (int i = 0; i < n; i++)
				{
					rndstr += (Char)(r.Next(65, 91));
				}
				return rndstr;
			}
		}

}
