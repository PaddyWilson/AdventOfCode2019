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

			IntCode pc = new IntCode(input);
			int[] arr = {1};
			pc.SetInput(arr);
			pc.Run();

			return pc.output;
		}

		public static int Result2(string file)
		{
			string[] inputFile = File.ReadAllLines(file);
			inputFile = inputFile[0].Split(',');//only one line

			//inputFile = "3,9,8,9,10,9,4,9,99,-1,8".Split(',');//works
			//inputFile = "3,9,7,9,10,9,4,9,99,-1,8".Split(',');
			//inputFile = "3,3,1108,-1,8,3,4,3,99".Split(',');
			//inputFile = "3,3,1107,-1,8,3,4,3,99".Split(',');//works

			//inputFile = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9".Split(',');//works
			//inputFile = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1".Split(',');//works

			//inputFile = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99".Split(',');//works

			int[] input = new int[inputFile.Length];
			for (int i = 0; i < inputFile.Length; i++)
			{
				input[i] = int.Parse(inputFile[i]);
			}

			//special instructions

			IntCode pc = new IntCode(input);
			int[] arr = { 5 };
			pc.SetInput(arr);
			pc.Run();

			return pc.output;
		}
	}
}