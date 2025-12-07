using System.Diagnostics;
string[] inputLines = File.ReadAllLines("Day7\\input.txt"); // Import inputs
var stopwatch = new Stopwatch();

stopwatch.Start();
var teleporter = new Day7.Teleporter(inputLines);
int startPos = teleporter.GetStartPos();
Console.WriteLine($"Start position: {startPos}");
teleporter.GetMovements(startPos);
teleporter.Move();
stopwatch.Stop();
Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total splits: {teleporter.TotalSplits}");

stopwatch.Reset();
stopwatch.Start();
teleporter = new Day7.Teleporter(inputLines);
teleporter.GetTimelines();
stopwatch.Stop();
Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total timelines: {teleporter.TotalTimelines}");

// S = start
// Always move down
// . = open space
// ^ = beam gets split left and right of splitter
// Beam moves down again til it hits another splitter or the bottom