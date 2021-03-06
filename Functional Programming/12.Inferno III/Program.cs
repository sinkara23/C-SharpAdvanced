﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Inferno_III
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> gems = Console.ReadLine().Split().Select(int.Parse).ToList();
			Dictionary<string, Func<List<int>, List<int>>> filters = new Dictionary<string, 
				Func<List<int>, List<int>>>();
			string command;

			while ((command = Console.ReadLine()) != "Forge")
			{
				ParseCommand(command, filters);
			}

			List<int> filtered = GetFiltered(gems, filters);
			gems = gems.Where(gem => !filtered.Contains(gem)).ToList();
			string result = string.Join(" ", gems);
			Console.WriteLine(result);
		}

		private static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
		{
			List<int> filtered = new List<int>();

			foreach (KeyValuePair<string, Func<List<int>, List<int>>> pair in filters)
			{
				Func<List<int>, List<int>> filter = pair.Value;
				filtered.AddRange(filter(gems));
			}

			return filtered;
		}

		private static void ParseCommand(string commandInput, Dictionary<string, Func<List<int>, List<int>>> filters)
		{
			string[] tokens = commandInput.Split(";");
			string command = tokens[0];
			string filtersType = tokens[1];
			int parameter = int.Parse(tokens[2]);
			string dictKey = $"{filtersType} {parameter}";

			if (command == "Exclude")
			{
				filters[dictKey] = CreateFunction(filtersType, parameter);
			}
			else if (command == "Reverse")
			{
				filters.Remove(dictKey);
			}
		}
		private static Func<List<int>, List<int>> CreateFunction(string filtersType, int parameter)
		{
			switch (filtersType)
			{
				case "Sum Left":
					return gems => gems.Where(gem =>
					{
						int index = gems.IndexOf(gem);
						int leftGem = index - 1 >= 0 ? gems[index - 1] : 0;
						return gem + leftGem == parameter;
					}).ToList();

				case "Sum Right":
					return gems => gems.Where(gem =>
					{
						int index = gems.IndexOf(gem);
						int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
						return gem + rightGem == parameter;
					}).ToList();

				case "Sum Left Right":
					return gems => gems.Where(gem =>
					{
						int index = gems.IndexOf(gem);
						int leftGem = index - 1 >= 0 ? gems[index - 1] : 0;
						int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
						return leftGem + gem + rightGem == parameter;
					}).ToList();
				default:

					throw new ArgumentException();
			}
		}
	}
}
