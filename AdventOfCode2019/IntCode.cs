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
					if (opCode.ToString().Length > 2)
						if ('1' == string.Concat(opCode.ToString().Reverse())[2])
							param1Add = instructionAddress + 1;

					if (opCode.ToString().Length > 3)
						if ('1' == string.Concat(opCode.ToString().Reverse())[3])
							param2Add = instructionAddress + 2;

					if (opCode.ToString().Length > 4)
						if ('1' == string.Concat(opCode.ToString().Reverse())[4])
							param3Add = instructionAddress + 3;

					opCode = int.Parse(opCode.ToString().Remove(0, opCode.ToString().Length - 2));
				}

				//for testing
				//				foreach (var item in memory)
				//				{
				//					Console.Write(item + ",");
				//				}
				//Console.WriteLine();
				//				Console.WriteLine("data {0},{1},{2},{3} : address {4},{5},{6},{7} : ins {8}", memory[instructionAddress], memory[param1Add], memory[param2Add], memory[param3Add], opCode, param1Add, param2Add, param3Add, instructionAddress);
				//				Console.ReadKey();

				switch (opCode)
				{
					case 99:
						running = false; instructionAddress += 1;
						break;
					case 1://add
						memory[param3Add] = memory[param1Add] + memory[param2Add]; instructionAddress += 4;
						break;
					case 2://multiply
						memory[param3Add] = memory[param1Add] * memory[param2Add]; instructionAddress += 4;
						break;
					case 3://input
						memory[param1Add] = input[inputCount]; inputCount++; instructionAddress += 2;
						break;
					case 4://output
						output = memory[param1Add]; instructionAddress += 2;
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
				}
			}
			return memory[0];
		}

	}
}
