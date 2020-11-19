using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AdventOfCode2019
{
	public class Day4
	{
		public static int Result1(string input)
		{
			int count = 0;

			int start = int.Parse(input.Split('-')[0]);
			int end = int.Parse(input.Split('-')[1]);

			for (int i = start; i <= end; i++)
			{
				bool maybe = false;
				for (int x = 0; x < 5; x++)
				{
					//two of the same digits in a row
					if (i.ToString()[x] == i.ToString()[x + 1])
					{
						maybe = true;
						break;
					}
				}

				if (!maybe) continue;
				maybe = false;
				for (int x = 0; x < 5; x++)
				{
					char a = i.ToString()[x];
					char b = i.ToString()[x + 1];
					if (i.ToString()[x] > i.ToString()[x + 1])
					{
						maybe = false;
						break;
					}

					maybe = true;
				}

				if (!maybe)
					continue;

				count++;
			}

			return count;
		}



		public static int Result2(string input)
		{
			int count = 0;

			int start = int.Parse(input.Split('-')[0]);
			int end = int.Parse(input.Split('-')[1]);

			List<int> results = new List<int>();

			for (int i = start; i <= end; i++)
			{
				bool maybe = false;

				int ct = 0;
				for (int x = 0; x < 5; x++)
				{
					//two of the same digits in a row
					if (i.ToString()[x] == i.ToString()[x + 1])
					{
						ct++;
						maybe = true;
					}
				}

				if (!maybe) continue;
				maybe = false;
				for (int x = 0; x < 5; x++)
				{
					char a = i.ToString()[x];
					char b = i.ToString()[x + 1];
					if (i.ToString()[x] > i.ToString()[x + 1])
					{
						maybe = false;
						break;
					}

					maybe = true;
				}

				if (!maybe)
					continue;

				count++;
				results.Add(i);
			}

			count = 0;
			foreach (var item in results)
			{
				Dictionary<char, int> c = new Dictionary<char, int>();
				for (int x = 0; x < 5; x++)
				{
					//two of the same digits in a row
					if (item.ToString()[x] == item.ToString()[x + 1])
					{
						if (!c.ContainsKey(item.ToString()[x]))
							c.Add(item.ToString()[x], 1);
						else
							c[item.ToString()[x]]++;
					}
				}

				foreach (var item2 in c)
				{
					if (item2.Value == 1)
					{
						count++;
						break;
					}
				}

			}

			return count;
		}
	}
}
