using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019
{
	public class Day2
	{
		public static long Result1(string file)
		{
			string[] inputFile = File.ReadAllLines(file);
			inputFile = inputFile[0].Split(',');//only one line

			long[] input = new long[inputFile.Length];
			for (long i = 0; i < inputFile.Length; i++)
			{
				input[i] = long.Parse(inputFile[i]);
			}

			//special instructions
			input[1] = 12;
			input[2] = 2;

			IntCode pc = new IntCode(input);
			//pc.Run(input);

			return pc.Run();
		}


		public static long Result2(string file)
		{
			string[] inputFile = File.ReadAllLines(file);
			inputFile = inputFile[0].Split(',');//only one line

			long[] memory = new long[inputFile.Length];
			for (long i = 0; i < inputFile.Length; i++)
			{
				memory[i] = long.Parse(inputFile[i]);
			}



			long answer = 0;
			long noun = 0;
			while (noun <= 99)
			{
				long verb = 0;
				while (verb <= 99)
				{
					memory[1] = noun;
					memory[2] = verb;

					IntCode comp = new IntCode(memory);

					if (comp.Run() == 19690720)
					{
						answer = 100 * noun + verb;
						return answer;
					}

					verb++;
				}
				noun++;
			}
			return answer;
		}

	}
}
