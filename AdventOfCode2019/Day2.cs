using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019
{
	public class Day2
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
			input[1] = 12;
			input[2] = 2;

			IntCode pc = new IntCode(input);
			//pc.Run(input);

			return pc.Run();
		}


		public static int Result2(string file)
		{
			string[] inputFile = File.ReadAllLines(file);
			inputFile = inputFile[0].Split(',');//only one line

			int[] memory = new int[inputFile.Length];
			for (int i = 0; i < inputFile.Length; i++)
			{
				memory[i] = int.Parse(inputFile[i]);
			}



			int answer = 0;
			int noun = 0;
			while (noun <= 99)
			{
				int verb = 0;
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
