using System;
using System.IO;

namespace AdventOfCode2019
{



	class Program
	{
		static readonly string Folder = @"C:\Users\GGGGG\Desktop\Code\AdventOfCode2019\input\";
		static readonly string Day1Input = Folder + @"day1-1.txt";
		static readonly string Day2Input = Folder + @"day2-1.txt";
		static readonly string Day3Input = Folder + @"day3-1.txt";
		static readonly string Day5Input = Folder + @"day5-1.txt";
		static readonly string Day6Input = Folder + @"day6-1.txt";

		static void Main(string[] args)
		{
			Console.WriteLine("Advent Of Code 2019");

			int answer = 0;
			int output = 0;
			string input = "";

			input = Day1Input;
			answer = 3331849;
			output = Day1.Result1(input);
			Console.WriteLine("Day 1. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			answer = 4994898;
			output = Day1.Result2(input);
			Console.WriteLine("Day 1. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));

			input = Day2Input;
			answer = 3101844;
			output = Day2.Result1(input);
			Console.WriteLine("Day 2. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			answer = 8478;
			output = Day2.Result2(input);
			Console.WriteLine("Day 2. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));

			//it takes a long time
			//input = Day3Input;
			//answer = 709;
			//output = Day3.Result1(input);
			//Console.WriteLine("Day 3. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			//answer = 13836;
			//output = Day3.Result2(input);
			//Console.WriteLine("Day 3. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));

			input = "245182-790572";
			answer = 1099;
			output = Day4.Result1(input);
			Console.WriteLine("Day 4. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			answer = 710;
			output = Day4.Result2(input);
			Console.WriteLine("Day 4. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));

			input = Day5Input;
			answer = 3122865;
			output = Day5.Result1(input);
			Console.WriteLine("Day 5. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			answer = 773660;
			output = Day5.Result2(input);
			Console.WriteLine("Day 5. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));

			input = Day6Input;
			answer = 140608;
			output = Day6.Result1(input);
			Console.WriteLine("Day 6. Answer 1:{0,10}, Correct?:{1}", output, (output == answer));
			answer = 337;
			output = Day6.Result2(input);
			Console.WriteLine("Day 6. Answer 2:{0,10}, Correct?:{1}", output, (output == answer));


			Console.ReadLine();
		}
	}
}
