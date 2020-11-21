using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2019
{
	internal class Day10
	{
		internal static long Result1(string input)
		{
			string[] inputData = File.ReadAllLines(input);
			inputData = inputData[0].Split(',');

			long[] data = new long[inputData.Length];
			for (long i = 0; i < inputData.Length; i++)
				data[i] = long.Parse(inputData[i]);

			return 0;
		}

		internal static long Result2(string input)
		{
			string[] inputData = File.ReadAllLines(input);
			inputData = inputData[0].Split(',');

			long[] data = new long[inputData.Length];
			for (long i = 0; i < inputData.Length; i++)
				data[i] = long.Parse(inputData[i]);

			return 0;
		}
	}
}