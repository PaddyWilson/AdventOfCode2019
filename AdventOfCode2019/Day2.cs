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

			int opCode = 0;
			int position = 0;

			opCode = input[position];
			while (opCode != 99)
			{
				int one, two, three;
				one = input[position + 1];
				two = input[position + 2];
				three = input[position + 3];

				switch (opCode)
				{
					case 1://add
						input[three] = input[one] + input[two];
						break;
					case 2://multiply
						input[three] = input[one] * input[two];
						break;
				}

				//move to next opCode
				position += 4;
				opCode = input[position];
			}

			return input[0];
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
			int[] backup = new int[memory.Length];
			Array.Copy(memory, backup, memory.Length);

			int answer = 0;

			int noun = 0;
			while (noun <= 99)
			{
				int verb = 0;
				while (verb <= 99)
				{
					Array.Copy(backup, memory, memory.Length);

					memory[1] = noun;
					memory[2] = verb;

					int opCode = 0;
					int instructionAddress = 0;

					while (opCode != 99)
					{
						int nounAddress, verbAddress, outputAddress;
						opCode = memory[instructionAddress];
						nounAddress = memory[instructionAddress + 1];
						verbAddress = memory[instructionAddress + 2];
						outputAddress = memory[instructionAddress + 3];

						if (outputAddress >= memory.Length - 1)
							break;

						switch (opCode)
						{
							case 1://add
								memory[outputAddress] = memory[nounAddress] + memory[verbAddress];
								break;
							case 2://multiply
								memory[outputAddress] = memory[nounAddress] * memory[verbAddress];
								break;
						}
						//move to next opCode
						if (opCode != 99)
							instructionAddress += 4;
						else
							break;

						if (instructionAddress + 1 >= memory.Length - 1 ||
							instructionAddress + 2 >= memory.Length - 1 ||
							instructionAddress + 3 >= memory.Length - 1)
							break;
					}

					if (memory[0] == 19690720)
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
