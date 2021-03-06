﻿using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
	class Program
	{
		static void Main(string[] args)
		{
			int table = int.Parse(Console.ReadLine());

			SortedDictionary<string, int> chemical = new SortedDictionary<string, int>();

			for (int i = 0; i < table; i++)
			{
				string[] brchemical = Console.ReadLine().Split(' ');

				foreach (string item in brchemical)
				{
					if (!chemical.ContainsKey(item))
					{
						chemical.Add(item, 1);
					}
				}
			}

			foreach (KeyValuePair<string, int> item in chemical)
			{
				string key = item.Key;
				Console.Write(key + " ");
			}

			//second solution - Hash Set

			//SortedSet<string> chemicals = new SortedSet<string>();

			//int n = int.Parse(Console.ReadLine());

			//for (int i = 0; i < n; i++)
			//{
			//	string[] input = Console.ReadLine().Split();

			//	foreach (string chemicalName in input)
			//	{
			//		chemicals.Add(chemicalName);
			//	}
			//}

			//Console.WriteLine(String.Join(" ", chemicals));
		}
	}
}
