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
		public List<int> input;
		int inputCount = 0;
		public int output = 0;

		bool running = false;
		bool isPaused = false;

		int[] memory;
		int[] backupMemory;
		int instructionAddress = 0;
		int relativeBase = 0;

		public IntCode(int[] code)
		{
			memory = new int[code.Length];
			backupMemory = new int[code.Length];
			Array.Copy(code, memory, code.Length);
			Array.Copy(code, backupMemory, code.Length);

			input = new List<int>();
		}

		public void Reset()
		{
			Array.Copy(backupMemory, memory, backupMemory.Length);
			running = false;
			isPaused = false;
			instructionAddress = 0;
			inputCount = 0;
			relativeBase = 0;
		}

		public void SetInput(int[] input)
		{
			this.input = new List<int>(input);
			inputCount = 0;
		}

		public void AddToInput(int input)
		{
			this.input.Add(input);
		}

		public bool IsRunning() { return running; }

		public int Run(bool pauseOnOutput = false)
		{
			running = true;
			isPaused = false;
			while (running && !isPaused)
			{
				isPaused = false;

				//position mode DEFAULT
				int param1Add = 0, param2Add = 0, param3Add = 0;
				int opCode = memory[instructionAddress];
				if (instructionAddress + 1 < memory.Length)
					param1Add = memory[instructionAddress + 1];
				if (instructionAddress + 2 < memory.Length)
					param2Add = memory[instructionAddress + 2];
				if (instructionAddress + 3 < memory.Length)
					param3Add = memory[instructionAddress + 3];

				if (opCode > 99)
				{
					string reversedOp = string.Concat(opCode.ToString().Reverse());
					//first param
					if (reversedOp.Length > 2)
						//immediate mode = 1
						if ('1' == reversedOp[2])
							param1Add = instructionAddress + 1;
						//relative mode = 2
						else if ('2' == reversedOp[2])
							param1Add = relativeBase + memory[instructionAddress + 1];

					//second param
					if (reversedOp.Length > 3)
						if ('1' == reversedOp[3])
							param2Add = instructionAddress + 2;
						//relative mode = 2
						else if ('2' == reversedOp[3])
							param1Add = relativeBase + memory[instructionAddress + 2];

					//third param
					if (reversedOp.Length > 4)
						if ('1' == reversedOp[4])
							param3Add = instructionAddress + 3;
						//relative mode = 2
						else if ('2' == reversedOp[4])
							param1Add = relativeBase + memory[instructionAddress + 3];

					//get base opCode
					opCode = int.Parse(opCode.ToString().Remove(0, opCode.ToString().Length - 2));
				}



				//run the instuction
				switch (opCode)
				{
					case 99://halt
						running = false; 
						instructionAddress += 1;
						break;
					case 1://add
						memory[param3Add] = memory[param1Add] + memory[param2Add]; 
						instructionAddress += 4;
						break;
					case 2://multiply
						memory[param3Add] = memory[param1Add] * memory[param2Add]; 
						instructionAddress += 4;
						break;
					case 3://input
						memory[param1Add] = input[inputCount]; 
						inputCount++; 
						instructionAddress += 2;
						break;
					case 4://output
						output = memory[param1Add]; 
						instructionAddress += 2;
						if (pauseOnOutput)
							isPaused = true;
						break;
					case 5://jump-if-true
						if (memory[param1Add] != 0)
							instructionAddress = memory[param2Add];
						else
							instructionAddress += 3;
						break;
					case 6://jump-if-false
						if (memory[param1Add] == 0)
							instructionAddress = memory[param2Add];
						else
							instructionAddress += 3;
						break;
					case 7://less than
						if (memory[param1Add] < memory[param2Add])
							memory[param3Add] = 1;
						else
							memory[param3Add] = 0;
						instructionAddress += 4;
						break;
					case 8://equals
						if (memory[param1Add] == memory[param2Add])
							memory[param3Add] = 1;
						else
							memory[param3Add] = 0;
						instructionAddress += 4;
						break;
					case 9://relative base
						relativeBase += memory[param1Add];
						instructionAddress += 2;
						break;
				}
			}
			return memory[0];
		}

	}
}
