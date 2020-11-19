using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic;

namespace AdventOfCode2019
{
	public class Day3
	{
		public static int Result1(string file)
		{
			string[] input = File.ReadAllLines(file);

			//string[] wire1 = "R8,U5,L5,D3".Split(',');
			//string[] wire2 = "U7,R6,D4,L4".Split(',');

			//string[] wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(',');
			//string[] wire2 = "U62,R66,U55,R34,D71,R55,D58,R83".Split(',');

			//string[] wire1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(',');
			//string[] wire2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',');

			string[] wire1 = input[0].Split(',');
			string[] wire2 = input[1].Split(',');


			Dictionary<string, int> w1 = PlaceWires(wire1);
			Dictionary<string, int> w2 = PlaceWires(wire2);

			List<string> intersects = new List<string>();
			foreach (var item1 in w1)
			{
				foreach (var item2 in w2)
				{
					//don't include the starting point
					if (item1.Key == "0,0" && item2.Key == "0,0")
						continue;

					if (item1.Key == item2.Key)
						intersects.Add(item1.Key);
				}
			}

			//int size = 500;
			//char[,] vis = new char[size, size];
			//int offSetY = size / 2;
			//int offSetX = size / 2;
			int lowest = int.MaxValue - 1;

			foreach (var item in intersects)
			{
				int x = int.Parse(item.Split(',')[0]);
				int y = int.Parse(item.Split(',')[1]);

				//vis[offSetX + x, offSetY + y] = item;

				int temp = Math.Abs(x - 0) + Math.Abs(y - 0);
				if (temp < lowest)
					lowest = temp;
			}

			return lowest;
		}

		public static int Result2(string file)
		{
			string[] input = File.ReadAllLines(file);

			//string[] wire1 = "R8,U5,L5,D3".Split(',');
			//string[] wire2 = "U7,R6,D4,L4".Split(',');

			//string[] wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(',');
			//string[] wire2 = "U62,R66,U55,R34,D71,R55,D58,R83".Split(',');

			//string[] wire1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(',');
			//string[] wire2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',');

			string[] wire1 = input[0].Split(',');
			string[] wire2 = input[1].Split(',');

			Dictionary<string, int> w1 = PlaceWires(wire1);
			Dictionary<string, int> w2 = PlaceWires(wire2);

			//List<string> intersects = new List<string>();

			int lowest = int.MaxValue - 1;
			foreach (var item1 in w1)
			{
				foreach (var item2 in w2)
				{
					//don't include the starting point
					if (item1.Key == "0,0" && item2.Key == "0,0")
						continue;

					if (item1.Key == item2.Key)
					{
						//int x = int.Parse(item.Split(',')[0]);
						//int y = int.Parse(item.Split(',')[1]);

						//vis[offSetX + x, offSetY + y] = item;

						int temp = item1.Value +item2.Value;
						if (temp < lowest)
							lowest = temp;
					}
				}
			}

			return lowest;
		}

		static Dictionary<string, int> PlaceWires(string[] wire)
		{
			//starting position
			int x = 0;
			int y = 0;

			Dictionary<string, int> wireView = new Dictionary<string, int>();

			//wireView.Add(PosString(x, y));

			int length = 0;
			foreach (var item in wire)
			{
				char direction = item[0];
				int amount = int.Parse(item.Substring(1, item.Length - 1));
				int tempX = x;
				int tempY = y;

				while (amount != 0)
				{
					amount--;
					length++;
					switch (direction)
					{
						case 'D': x++; break;
						case 'U': x--; break;
						case 'L': y--; break;
						case 'R': y++; break;
						default:
							break;
					}

					if (!wireView.ContainsKey(PosString(x, y)))
						wireView.Add(PosString(x, y), length);
					//else
						//wireView.Add(PosString(x, y), length);
				}
			}
			return wireView;
		}


		static string PosString(int x, int y)
		{
			return x + "," + y;
		}
	}
}
