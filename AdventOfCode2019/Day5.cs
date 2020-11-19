using System;
using System.IO;

namespace AdventOfCode2019
{
	public class Day5
	{
		public static int Result1(string file)
		{
			string[] inputFile = File.ReadAllLines(file);
			inputFile = inputFile[0].Split(',');//only one line

			int[] input = new int[inputFile.Length];
			for (int i = 0; i < inputFile.Length; i++)
			{
				input[i] = int.Parse(inputFile[i]);
			}

			//special instructions

			IntCode pc = new IntCode();

			pc.input = 1;
			int diagnosticCode = -1;

			pc.Run(input);

			diagnosticCode = pc.output;

			return diagnosticCode;
		}

		public static int Result2(string input)
		{
			return 0;
			throw new NotImplementedException();
		}
	}
}