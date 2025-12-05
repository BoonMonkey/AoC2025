using Day5;
using System.Diagnostics;

// Import inputs
string[] inputLines = File.ReadAllLines("Day5\\input.txt");

var stopwatch = new Stopwatch();

stopwatch.Start();
var inventory = new Inventory(inputLines);
stopwatch.Stop();
Console.WriteLine($"Total fresh available IDs: {inventory.totalFreshFromAvailable}");
Console.WriteLine($"Total fresh IDs from ranges: {inventory.totalFreshFromRanges}");
Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
