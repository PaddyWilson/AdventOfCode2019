using System;
using System.IO;

namespace AdventOfCode2019
{
	internal class Day9
	{
		internal static int Result1(string input)
		{
			string[] inputData = File.ReadAllLines(input);
			inputData = inputData[0].Split(',');

			//test programs
			inputData = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',');
			inputData = "1102,34915192,34915192,7,4,7,99,0".Split(',');
			inputData = "104,1125899906842624,99".Split(',');

			int[] data = new int[inputData.Length];
			for (int i = 0; i < inputData.Length; i++)
				data[i] = int.Parse(inputData[i]);

			IntCode cpu = new IntCode(data);

			cpu.AddToInput(0);
			cpu.Run();

			return cpu.output;
		}

		internal static int Result2(string input)
		{
			return 0;
		}
	}
}