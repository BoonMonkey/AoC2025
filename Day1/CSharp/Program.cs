// Import inputs
string[] lines = File.ReadAllLines("Day1\\CSharp\\input.txt");

// Initialize part one dial - Size 100 to allow for 0-99 positions, starting position is 50
var partOne = new dial.Dial(100, 50);

// Process each line of input
foreach (var line in lines)
{
  string direction = line[0].ToString();
  var distance = int.Parse(line[1..]);

  // Part 1 solution
  partOne.Turn(distance, direction);
}
Console.WriteLine($"Part One - Times 0 Reached: {partOne.TimesZeroReached}");


// Initialize part two dial - Size 100 to allow for 0-99 positions, starting position is 50
var partTwo = new dial.Dial(100, 50);

foreach (var line in lines)
{
  string direction = line[0].ToString();
  var distance = int.Parse(line[1..]);

  // Part 2 solution
  partTwo.TurnCountAllZero(distance, direction);
}
Console.WriteLine($"Part Two - Times 0 Reached: {partTwo.TimesZeroReached}");