﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parentheses
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] input = Console.ReadLine().ToCharArray();

			if (input.Length % 2 != 0)
			{
				Console.WriteLine("NO");
				Environment.Exit(0);
			}

			char[] opening = new[] { '(', '[', '{' };
			char[] closing = new[] { ')', ']', '}' };

			Stack<char> stack = new Stack<char>();

			foreach (char element in input)
			{
				if (opening.Contains(element))
				{
					stack.Push(element);
				}

				else if (closing.Contains(element))
				{
					char lastElement = stack.Pop();

					int openingIndex = Array.IndexOf(opening, lastElement);

					int closingIndex = Array.IndexOf(closing, element);

					if (openingIndex != closingIndex)
					{
						Console.WriteLine("NO");
						Environment.Exit(0);
					}
				}
			}

			if (stack.Any())
			{
				Console.WriteLine("NO");
			}
			else
			{
				Console.WriteLine("YES");
			}
		}
	}
}
