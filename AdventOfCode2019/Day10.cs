using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2019
{
	internal class Day10
	{
		internal static long Result1(string input)
		{
			string[] inputData = File.ReadAllLines(input);

			int width = inputData[0].Length;
			int height = inputData.Length;
			char[,] map = new char[width, height];

			for (int x = 0; x < height; x++)
				for (int y = 0; y < width; y++)
					map[x, y] = inputData[x][y];

			long[] output = FindBestStation(map, width, height);

			return output[2];
		}

		internal static long Result2(string input)
		{
			string[] inputData = File.ReadAllLines(input);

			int width = inputData[0].Length;
			int height = inputData.Length;
			char[,] map = new char[width, height];

			for (int x = 0; x < height; x++)
				for (int y = 0; y < width; y++)
					map[x, y] = inputData[x][y];

			long[] output = FindBestStation(map, width, height);

			int bestX = (int)output[0]; 
			int bestY = (int)output[1];

			return output[2];
		}

		internal static long[] FindBestStation(char[,] map, int width, int height)
		{
			char[,,] data = new char[width, height, 2];
			char[,,] dataBackup = new char[width, height, 2];

			for (int x = 0; x < height; x++)
			{
				for (int y = 0; y < width; y++)
				{
					data[x, y, 0] = map[x, y];
					data[x, y, 1] = (char)0;
				}
			}
			Array.Copy(data, dataBackup, width * height * 2);

			int mostX = 0;
			int mostY = 0;
			int detectedCount = 0;

			//search for visables
			for (int x = 0; x < height; x++)
			{
				for (int y = 0; y < width; y++)
				{
					if (data[x, y, 0] == '.') continue;
					Array.Copy(dataBackup, data, width * height * 2);


					int count = 0;

					List<double> ratios = new List<double>();
					//up stright
					for (int i = x; i >= 0; i--)
					{
						if (data[i, y, 1] == (char)1) continue;//has been visited before
						data[i, y, 1] = (char)1;
						if (x == i) { continue; }//same tile
						if (data[i, y, 0] == '.') continue;//void space						

						if (ratios.Contains(1)) continue;
						ratios.Add(1);
						count++;
					}
					ratios = new List<double>();
					//down stright
					for (int i = x; i < height; i++)
					{
						if (data[i, y, 1] == (char)1) continue;//has been visited before
						data[i, y, 1] = (char)1;
						if (x == i) { continue; }//same tile
						if (data[i, y, 0] == '.') continue;//void space						

						if (ratios.Contains(1)) continue;
						ratios.Add(1);
						count++;
					}
					ratios = new List<double>();
					//left stright
					for (int j = y; j >= 0; j--)
					{
						if (data[x, j, 1] == (char)1) continue;//has been visited before
						data[x, j, 1] = (char)1;
						if (y == j) { continue; }//same tile
						if (data[x, j, 0] == '.') continue;//void space						

						if (ratios.Contains(1)) continue;
						ratios.Add(1);
						count++;
					}
					ratios = new List<double>();
					//right stright
					for (int j = y; j < width; j++)
					{
						if (data[x, j, 1] == (char)1) continue;//has been visited before
						data[x, j, 1] = (char)1;
						if (y == j) { continue; }//same tile
						if (data[x, j, 0] == '.') continue;//void space						

						if (ratios.Contains(1)) continue;
						ratios.Add(1);
						count++;
					}

					ratios = new List<double>();
					//left up
					for (int i = x; i >= 0; i--)
					{
						for (int j = y; j >= 0; j--)
						{
							if (x == i && y == j) continue;//same tile
							if (data[i, j, 0] == '.') continue;//void space
							if (data[i, j, 1] == (char)1) continue;//has been visited before

							double ratio = (double)((double)((double)i - (double)x) / (double)((double)j - (double)y));
							if (ratios.Contains(ratio)) continue;

							ratios.Add(ratio);
							data[i, j, 1] = (char)1;
							count++;
						}
					}
					ratios = new List<double>();
					//right up
					for (int i = x; i >= 0; i--)
					{
						for (int j = y; j < width; j++)
						{
							if (x == i && y == j) continue;//same tile
							if (data[i, j, 0] == '.') continue;//void space
							if (data[i, j, 1] == (char)1) continue;//has been visited before

							double ratio = (double)((double)((double)i - (double)x) / (double)((double)j - (double)y));
							if (ratios.Contains(ratio)) continue;

							ratios.Add(ratio);
							data[i, j, 1] = (char)1;
							count++;
						}
					}
					ratios = new List<double>();
					//right down
					for (int i = x; i < height; i++)
					{
						for (int j = y; j < width; j++)
						{
							if (x == i && y == j) continue;//same tile
							if (data[i, j, 0] == '.') continue;//void space
							if (data[i, j, 1] == (char)1) continue;//has been visited before

							double ratio = (double)((double)((double)i - (double)x) / (double)((double)j - (double)y));
							//Console.WriteLine(ratio);
							if (ratios.Contains(ratio)) continue;

							ratios.Add(ratio);
							data[i, j, 1] = (char)1;
							count++;
						}
					}
					ratios = new List<double>();
					//left down
					for (int i = x; i < height; i++)
					{
						for (int j = y; j >= 0; j--)
						{
							if (x == i && y == j) continue;//same tile
							if (data[i, j, 0] == '.') continue;//void space
							if (data[i, j, 1] == (char)1) continue;//has been visited before

							double ratio = (double)((double)((double)i - (double)x) / (double)((double)j - (double)y));
							if (ratios.Contains(ratio)) continue;

							ratios.Add(ratio);
							data[i, j, 1] = (char)1;
							count++;
						}
					}

					if (count > detectedCount)
					{
						detectedCount = count;
						mostX = x;
						mostY = y;
					}
				}
			}
			return new long[] { mostX, mostY, detectedCount };
		}
	}
}