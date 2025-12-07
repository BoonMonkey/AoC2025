// using System.Diagnostics;
string[] inputLines = File.ReadAllLines("Day7\\input.txt"); // Import inputs

var teleporter = new Day7.Teleporter(inputLines);
int startPos = teleporter.GetStartPos();
Console.WriteLine($"Start position: {startPos}");
teleporter.GetMovements(startPos);
teleporter.Move();

Console.WriteLine($"Total splits: {teleporter.TotalSplits}");
// S = start
// Always move down
// . = open space
// ^ = beam gets split left and right of splitter
// Beam moves down again til it hits another splitter or the bottom