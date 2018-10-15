﻿using System;
using System.Linq;

namespace Concatenate_Data
{
	class Program
	{
		static void Main(string[] args)
		{
			Action<string> print = message => Console.WriteLine(message);
			var name = Console.ReadLine().Split(' ').ToList();

			foreach (var word in name)
			{
				print(word);
			}
		}
	}
}
