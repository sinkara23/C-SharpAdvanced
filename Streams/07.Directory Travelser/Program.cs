﻿using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _07.Directory_Travelser
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Console.ReadLine();

			Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

			string[] files = Directory.GetFiles(path);

			foreach (string file in files)
			{
				FileInfo fileInfo = new FileInfo(file);
				string extension = fileInfo.Extension;

				if (!filesDictionary.ContainsKey(extension))
				{
					filesDictionary[extension] = new List<FileInfo>();
				}

				filesDictionary[extension].Add(fileInfo);
			}

			filesDictionary = filesDictionary
				.OrderByDescending(x => x.Value.Count)
				.ThenBy(x => x.Key)
				.ToDictionary(x => x.Key, y => y.Value);

			//string desktop = @"%Ivan Dragolov%\Desktop\";
			//string desktop = @"D:\CSharpAdvance\C-SharpAdvanced\Streams\07.Directory Travelser";
			string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string fullFileName = desktop + "report.txt";

			using (StreamWriter writer = new StreamWriter(fullFileName))
			{
				foreach (KeyValuePair<string, List<FileInfo>> pair in filesDictionary)
				{
					string extension = pair.Key;
					writer.WriteLine(extension);
					IOrderedEnumerable<FileInfo> fileInfos = pair
						.Value
						.OrderByDescending(fi => fi.Length);

					foreach (FileInfo fileInfo in fileInfos)
					{
						double filesize = (double)fileInfo.Length / 1024;
						writer.WriteLine($"-- {fileInfo.Name} - {filesize:f3}kb");
					}
				}
			}
		}
	}
}

