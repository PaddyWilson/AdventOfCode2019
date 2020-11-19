using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2019
{
	public class Day1
	{
		public static int Result1(string file)
		{
			string[] input = File.ReadAllLines(file);

			int output = 0;

			foreach (var item in input)
			{
				int i = (int)Math.Floor((decimal)(int.Parse(item) / 3) - 2);
				output += i;
			}
			return output;
		}

		public static int Result2(string file)
		{
			string[] input = File.ReadAllLines(file);

			int output = 0;

			foreach (var item in input)
			{
				int temp = 0;
				int i = (int)Math.Floor((decimal)(int.Parse(item) / 3) - 2);
				temp = i;
				while (i > 0)
				{
					i = (int)Math.Floor(((decimal)i / 3) - 2);
					if (i > 0)
						temp += i;
				}
				output += temp;
			}
			return output;
		}


	}
}
