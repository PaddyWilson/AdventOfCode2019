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

		static void Main(string[] args)
		{
			Console.WriteLine("Advent Of Code 2019");

			Console.WriteLine("Day 1. Answer 1:{0}, Answer 2:{1}",
				Day1.Result1(Day1Input), Day1.Result2(Day1Input));

			Console.WriteLine("Day 2. Answer 1:{0}, Answer 2:{1}",
				Day2.Result1(Day2Input), Day2.Result2(Day2Input));

			Console.WriteLine("Day 3. Answer 1:{0}, Answer 2:{1}",
				Day3.Result1(Day3Input), Day3.Result2(Day3Input));

			Console.ReadLine();
		}
	}
}
