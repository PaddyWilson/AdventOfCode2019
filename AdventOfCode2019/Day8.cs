using System;
using System.IO;

namespace AdventOfCode2019
{
	internal class Day8
	{
		internal static int Result1(string input)
		{
			string[] inputData = File.ReadAllLines(input);

			int[] data = new int[inputData[0].Length];
			for (int i = 0; i < inputData[0].Length; i++)
				data[i] = int.Parse(new char[] { inputData[0][i] });

			int height = 25;
			int length = 6;
			int layers = data.Length / (height * length);

			int[,,] image = new int[height, length, layers];

			int pos = 0;
			for (int lay = 0; lay < layers; lay++)
			{
				for (int y = 0; y < length; y++)
				{
					for (int x = 0; x < height; x++)
					{
						image[x, y, lay] = data[pos];
						pos++;
					}
				}
			}

			int layerLowest = 0;
			int digit0Lowest = int.MaxValue - 1;
			int digit1Lowest = int.MaxValue - 1;
			int digit2Lowest = int.MaxValue - 1;

			for (int lay = 0; lay < layers; lay++)
			{
				int digit0 = 0;
				int digit1 = 0;
				int digit2 = 0;

				for (int y = 0; y < length; y++)
				{
					for (int x = 0; x < height; x++)
					{
						if (image[x, y, lay] == 0)
							digit0++;
						if (image[x, y, lay] == 1)
							digit1++;
						if (image[x, y, lay] == 2)
							digit2++;
					}
				}

				if (digit0 < digit0Lowest)
				{
					layerLowest = lay;
					digit0Lowest = digit0;
					digit1Lowest = digit1;
					digit2Lowest = digit2;
				}
			}

			return digit1Lowest * digit2Lowest;
		}

		internal static int Result2(string input)
		{
			string[] inputData = File.ReadAllLines(input);

			int[] data = new int[inputData[0].Length];
			for (int i = 0; i < inputData[0].Length; i++)
				data[i] = int.Parse(new char[] { inputData[0][i] });

			int height = 25;
			int length = 6;
			int layers = data.Length / (height * length);

			int[,,] image = new int[height, length, layers];

			int pos = 0;
			for (int lay = 0; lay < layers; lay++)
			{
				for (int y = 0; y < length; y++)
				{
					for (int x = 0; x < height; x++)
					{
						image[x, y, lay] = data[pos];
						pos++;
					}
				}
			}

			int[,] imageRender = new int[height, length];
			for (int y = 0; y < length; y++)
				for (int x = 0; x < height; x++)
					imageRender[x, y] = 9;


			for (int y = 0; y < length; y++)
			{
				for (int x = 0; x < height; x++)
				{
					for (int lay = 0; lay < layers; lay++)
					{
						if (image[x, y, lay] < 2)
						{
							imageRender[x, y] = image[x, y, lay];
							break;
						}
					}
				}
			}

			for (int y = 0; y < length; y++)
			{
				for (int x = 0; x < height; x++)
				{
					Console.Write(imageRender[x, y]);
				}
				Console.WriteLine();
			}

			return 0;
		}
	}
}