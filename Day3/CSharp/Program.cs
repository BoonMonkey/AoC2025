using Day3;

// Import inputs
string inputFile = File.ReadAllText("Day3\\input.txt");

// Split inputs by commas
string[] inputs = inputFile.Split("\r\n");

// Total output joltage
int totalJoltage = 0;

foreach (string input in inputs)
{
  var bank = new Joltage(input);

  // Debugging steps, commented out for main run
  // Console.WriteLine($"Processing bank: {bank.bank}");
  // Console.WriteLine($"Joltage ratings: {string.Join(",", bank.joltageRatings)}");
  // Console.WriteLine($"Joltage ratings length: {bank.joltageRatings.Length}");
  // Console.WriteLine($"Possible left joltages: {string.Join(",", bank.possibleJoltages["left"])}");
  // Console.WriteLine($"Possible right joltages: {string.Join(",", bank.possibleJoltages["right"])}");
  
  // Console.WriteLine($"Highest Joltage for bank {bank.bank}: {bank.highestJoltage}");

  totalJoltage += bank.highestJoltage;
}

Console.WriteLine($"Total Joltage from all banks: {totalJoltage}");