using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
	public class IntCode
	{
		public int Run(int[] code)
		{
			int[] memory = new int[code.Length];
			Array.Copy(code, memory, code.Length);

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

				instructionAddress += 4;
				opCode = memory[instructionAddress];

				//if (instructionAddress + 1 >= memory.Length - 1 ||
				//	instructionAddress + 2 >= memory.Length - 1 ||
				//	instructionAddress + 3 >= memory.Length - 1)
				//	break;
			}

			return memory[0];
		}

	}
}
