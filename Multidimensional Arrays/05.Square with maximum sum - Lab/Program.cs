﻿using System;
using System.Linq;

namespace _05.Square_with_maximum_sum
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
			int rowIndex = 0, columnIndex = 0;

			for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
			{
				for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
				{
					int tempSum = matrix[rows, columns] + matrix[rows, columns + 1]
						+ matrix[rows + 1, columns] + matrix[rows + 1, columns + 1];

					if (tempSum > sum)
					{
						sum = tempSum;
						rowIndex = rows;
						columnIndex = columns;
					}
				}
			}

			Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
			Console.WriteLine(matrix[rowIndex + 1, columnIndex] + " " + matrix[rowIndex + 1, columnIndex + 1]);
			Console.WriteLine(sum);
		}
	}
}
