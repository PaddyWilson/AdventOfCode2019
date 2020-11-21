﻿using System;
using System.IO;

namespace AdventOfCode2019
{
	internal class Day9
	{
		internal static long Result1(string input)
		{
			string[] inputData = File.ReadAllLines(input);
			inputData = inputData[0].Split(',');

			//test programs
			//inputData = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',');//works
			//inputData = "1102,34915192,34915192,7,4,7,99,0".Split(',');//works
			//inputData = "104,1125899906842624,99".Split(','); //works

			//inputData = "109,-1,4,1,99".Split(','); //works
			//inputData = "109,-1,104,1,99".Split(','); //works
			//inputData = "109,-1,204,1,99".Split(','); //109
			//inputData = "109,1,9,2,204,-6,99".Split(','); //204
			//inputData = "109,1,109,9,204,-6,99".Split(','); //204
			//inputData = "109,1,209,-1,204,-106,99".Split(',');
			//inputData = "109,1,3,3,204,2,99".Split(',');
			//inputData = "109,1,203,2,204,2,99".Split(',');//works

			long[] data = new long[inputData.Length];
			for (long i = 0; i < inputData.Length; i++)
				data[i] = long.Parse(inputData[i]);

			IntCode cpu = new IntCode(data, 100000000);

			cpu.AddToInput(1);
			cpu.Run();

			//foreach (var item in cpu.output)
			//{
			//	Console.Write(item + ",");
			//}
			//Console.WriteLine();
			return cpu.output[0];
		}

		internal static long Result2(string input)
		{
			string[] inputData = File.ReadAllLines(input);
			inputData = inputData[0].Split(',');

			long[] data = new long[inputData.Length];
			for (long i = 0; i < inputData.Length; i++)
				data[i] = long.Parse(inputData[i]);

			IntCode cpu = new IntCode(data, 100000000);

			cpu.AddToInput(2);
			cpu.Run();

			//foreach (var item in cpu.output)
			//{
			//	Console.Write(item + ",");
			//}
			//Console.WriteLine();
			return cpu.output[0];
		}
	}
}