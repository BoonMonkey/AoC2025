using Day3;

// Import inputs
string inputFile = File.ReadAllText("Day3\\input.txt");

// Split inputs by commas
string[] inputs = inputFile.Split("\r\n");

// Total output joltage
long partOneJoltage = 0;
long partTwoJoltage = 0;

// Part one
foreach (string input in inputs)
{
  var bank = new Joltage(input, 2);
  partOneJoltage += bank.highestJoltage;
}

// Part two
foreach (string input in inputs)
{
  var bank = new Joltage(input, 12);
  partTwoJoltage += bank.highestJoltage;
}

Console.WriteLine($"Part one - Total Joltage from all banks: {partOneJoltage}");
Console.WriteLine($"Part two - Total Joltage from all banks: {partTwoJoltage}");