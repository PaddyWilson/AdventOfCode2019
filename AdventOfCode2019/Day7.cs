using System;
using System.IO;

namespace AdventOfCode2019
{
	internal class Day7
	{
		internal static int Result1(string input)
		{
			string[] inputFile = File.ReadAllLines(input);
			inputFile = inputFile[0].Split(',');//only one line

			//inputFile = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(',');

			int[] inputCommands = new int[inputFile.Length];
			for (int i = 0; i < inputFile.Length; i++)
			{
				inputCommands[i] = int.Parse(inputFile[i]);
			}

			IntCode cpu = new IntCode(inputCommands);

			// this is so dum but works great :)
			// should probably have brackets
			int highest = 0;
			for (int one = 0; one < 5; one++)
				for (int two = 0; two < 5; two++)
					if (one != two)
						for (int three = 0; three < 5; three++)
							if (one != two && one != three && two != three)
								for (int four = 0; four < 5; four++)
									if (one != two && one != three && one != four && two != three && two != four && three != four)
										for (int five = 0; five < 5; five++)
											if (one != two && one != three && one != four && one != five
												&& two != three && two != four && two != five
												&& three != four && three != five && four != five)
											{
												int temp = 0;
												cpu.Reset();
												cpu.SetInput(new int[] { one, temp });
												cpu.Run();
												temp = cpu.output;

												cpu.Reset();
												cpu.SetInput(new int[] { two, temp });
												cpu.Run();
												temp = cpu.output;

												cpu.Reset();
												cpu.SetInput(new int[] { three, temp });
												cpu.Run();
												temp = cpu.output;

												cpu.Reset();
												cpu.SetInput(new int[] { four, temp });
												cpu.Run();
												temp = cpu.output;

												cpu.Reset();
												cpu.SetInput(new int[] { five, temp });
												cpu.Run();
												temp = cpu.output;

												if (temp > highest)
													highest = temp;
											}
			return highest;
		}

		internal static int Result2(string input)
		{
			string[] inputFile = File.ReadAllLines(input);
			inputFile = inputFile[0].Split(',');//only one line

			//inputFile = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5".Split(',');

			int[] inputCommands = new int[inputFile.Length];
			for (int i = 0; i < inputFile.Length; i++)
				inputCommands[i] = int.Parse(inputFile[i]);
			int highest = 0;

			for (int one = 5; one < 10; one++)
				for (int two = 5; two < 10; two++)
					if (one != two)
						for (int three = 5; three < 10; three++)
							if (one != two && one != three && two != three)
								for (int four = 5; four < 10; four++)
									if (one != two && one != three && one != four && two != three && two != four && three != four)
										for (int five = 5; five < 10; five++)
											if (one != two && one != three && one != four && one != five
												&& two != three && two != four && two != five
												&& three != four && three != five && four != five)
											{
												IntCode cpu1 = new IntCode(inputCommands);
												IntCode cpu2 = new IntCode(inputCommands);
												IntCode cpu3 = new IntCode(inputCommands);
												IntCode cpu4 = new IntCode(inputCommands);
												IntCode cpu5 = new IntCode(inputCommands);

												cpu1.SetInput(new int[] { one });
												cpu2.SetInput(new int[] { two });
												cpu3.SetInput(new int[] { three });
												cpu4.SetInput(new int[] { four });
												cpu5.SetInput(new int[] { five });

												int temp = 0;
												do
												{
													cpu1.AddToInput(temp);
													cpu1.Run(true);

													cpu2.AddToInput(cpu1.output);
													cpu2.Run(true);

													cpu3.AddToInput(cpu2.output);
													cpu3.Run(true);

													cpu4.AddToInput(cpu3.output);
													cpu4.Run(true);

													cpu5.AddToInput(cpu4.output);
													cpu5.Run(true);

													temp = cpu5.output;
												} while (cpu1.IsRunning());

												if (temp > highest)
													highest = temp;
											}
			return highest;
		}
	}
}