﻿using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] rowsAndColumns = Console.ReadLine()
				.Split(", ")
				.Select(int.Parse)
				.ToArray();

			int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

			for (int rows = 0; rows < rowsAndColumns[0]; rows++)
			{
				int[] rowValues = Console.ReadLine()
					.Split(", ")
					.Select(int.Parse)
					.ToArray();

				for (int columns = 0; columns < rowsAndColumns[1]; columns++)
				{
					matrix[rows, columns] = rowValues[columns];
				}
			}

			int sum = 0;

			for (int rows = 0; rows < matrix.GetLength(0); rows++)
			{
				for (int columns = 0; columns < matrix.GetLength(1); columns++)
				{
					sum += matrix[0, columns];
				}
			}

			Console.WriteLine(matrix.GetLength(0));
			Console.WriteLine(matrix.GetLength(1));
			Console.WriteLine(sum);
		}
	}
}
