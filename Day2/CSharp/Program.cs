// Import inputs
string inputFile = File.ReadAllText("Day2\\input.txt");

// Split inputs by commas
string[] inputs = inputFile.Split(',');

// Part One
long invalidIdValue = 0;
foreach (var input in inputs)
{
  var startId = long.Parse(input.Split('-')[0]);
  var endId = long.Parse(input.Split('-')[1]);
  var idChecker = new idCheck.IdCheck(startId, endId);

  invalidIdValue += idChecker.sumOfInvalidIds;
}

Console.WriteLine($"Part One: Sum of Invalid IDs = {invalidIdValue}");