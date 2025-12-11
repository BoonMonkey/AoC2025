// using System.Diagnostics;
using Day11;
string[] inputLines = File.ReadAllLines("Day11\\input.txt"); // Import inputs
var reactor = new Reactor(inputLines);
reactor.PrintInputLines();
reactor.PrintDeviceOutputs();
reactor.PrintQueue();
reactor.FindNextDevice();
Console.WriteLine($"Total paths from you to out: {reactor.PathCounter}");