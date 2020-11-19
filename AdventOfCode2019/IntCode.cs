using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Xml;

namespace AdventOfCode2019
{
	public class IntCode
	{
		public int input = 0;
		public int output = 0;

		public int Run(int[] code)
		{
			int[] memory = new int[code.Length];
			Array.Copy(code, memory, code.Length);

			int param1Add = 0, param2Add = 0, outputAddress = 0;
			int opCode = 0;
			int instructionAddress = 0;

			while (opCode != 99)
			{
				opCode = memory[instructionAddress];
				param1Add = memory[instructionAddress + 1];
				param2Add = memory[instructionAddress + 2];
				outputAddress = memory[instructionAddress + 3];

				if (opCode > 99)
				{
					if (opCode.ToString().Length > 2)
						if ('1' == string.Concat(opCode.ToString().Reverse())[2])
							param1Add = instructionAddress + 1;

					if (opCode.ToString().Length > 3)
						if ('1' == string.Concat(opCode.ToString().Reverse())[3])
							param2Add = instructionAddress + 2;

					if (opCode.ToString().Length > 4)
						if ('1' == string.Concat(opCode.ToString().Reverse())[4])
							outputAddress = instructionAddress + 3;

					opCode = int.Parse(opCode.ToString().Remove(0, opCode.ToString().Length - 2));
				}

				//if (outputAddress >= memory.Length - 1)
					//break;

				switch (opCode)
				{
					case 1://add
						memory[outputAddress] = memory[param1Add] + memory[param2Add]; instructionAddress += 4;
						break;
					case 2://multiply
						memory[outputAddress] = memory[param1Add] * memory[param2Add]; instructionAddress += 4;
						break;
					case 3://input
						memory[param1Add] = input; instructionAddress += 2;
						break;
					case 4://output
						output = memory[param1Add]; instructionAddress += 2;
						break;
				}

				opCode = memory[instructionAddress];
			}

			return memory[0];
		}

	}
}
