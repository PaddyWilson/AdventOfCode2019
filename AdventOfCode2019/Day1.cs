﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2019
{
	public class Day1
	{
		public static long Result1(string file)
		{
			string[] input = File.ReadAllLines(file);

			long output = 0;

			foreach (var item in input)
			{
				long i = (long)Math.Floor((decimal)(long.Parse(item) / 3) - 2);
				output += i;
			}
			return output;
		}

		public static long Result2(string file)
		{
			string[] input = File.ReadAllLines(file);

			long output = 0;

			foreach (var item in input)
			{
				long temp = 0;
				long i = (long)Math.Floor((decimal)(long.Parse(item) / 3) - 2);
				temp = i;
				while (i > 0)
				{
					i = (long)Math.Floor(((decimal)i / 3) - 2);
					if (i > 0)
						temp += i;
				}
				output += temp;
			}
			return output;
		}


	}
}
