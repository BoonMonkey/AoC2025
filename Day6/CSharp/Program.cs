// using System.Diagnostics;
string[] inputLines = File.ReadAllLines("Day6\\input.txt"); // Import inputs

var homework = new Day6.Homework(inputLines, "partOne");
Console.WriteLine($"Total columns in queue: {homework.Columns.Count}");
homework.PartOneColumnMath();

homework = new Day6.Homework(inputLines, "partTwo");
Console.WriteLine($"Total columns in queue: {homework.Columns.Count}");
homework.PartTwo();