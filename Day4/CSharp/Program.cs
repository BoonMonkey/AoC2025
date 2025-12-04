using Day4;
using System.Diagnostics;

// Import inputs
string inputFile = File.ReadAllText("Day4\\input.txt");

// Split inputs by commas
string[] inputs = inputFile.Split("\r\n");

// Initialize PaperPile and PaperGrid
var paperPile = new PaperPile();
var paperGrid = new PaperGrid();

// Initialize item to find
char itemToFind = '@';
var totalAccessibleItems = 0;

// Create stopwatch for performance measurement
Stopwatch stopwatch = new Stopwatch();

foreach (var input in inputs)
{
  paperPile.AddStack();
  for (int xCoord = 0; xCoord < input.Length; xCoord++)
  {
    paperPile.AddRoll(xCoord);
    paperGrid.PopulateGrid(paperPile.rowCoords.x, paperPile.rowCoords.y, input[xCoord]);
  }
}

// Part 1 Optimized
stopwatch.Start();
totalAccessibleItems = paperGrid.GetAccessibleRolls(itemToFind).Count;
stopwatch.Stop();

Console.WriteLine($"Total accessible '{itemToFind}' items: {totalAccessibleItems}");
Console.WriteLine($"Time taken for Part 1: {stopwatch.ElapsedMilliseconds} ms");


// Part 2 Optimized
stopwatch.Reset();
stopwatch.Start();
var accessibleRolls = paperGrid.GetAccessibleRolls(itemToFind);
var processedRolls = new HashSet<(int x, int y)>();
var totalRemovedRolls = 0;

while (accessibleRolls.Count > 0)
{
  var currentRoll = accessibleRolls.Dequeue();

  if (!paperGrid.RollExists(currentRoll.x, currentRoll.y, itemToFind))
  {
    continue;
  }

  paperGrid.RemoveRoll(currentRoll.x, currentRoll.y);
  totalRemovedRolls++;

  int[] xOffset = { 0, 1, -1, 0, 1, -1, 1, -1 };
  int[] yOffset = { -1, -1, -1, 1, 1, 1, 0, 0 };

  for (int i = 0; i < xOffset.Length; i++)
  {
    int adjacentX = currentRoll.x + xOffset[i];
    int adjacentY = currentRoll.y + yOffset[i];

    if (paperGrid.gridLocations.ContainsKey((adjacentX, adjacentY)) && paperGrid.RollExists(adjacentX, adjacentY, itemToFind))
    {
      int adjacentCount = paperGrid.AdjacentCount(adjacentX, adjacentY, itemToFind);
      
      if (adjacentCount < 4)
      {
        accessibleRolls.Enqueue((adjacentX, adjacentY));
      }
    }
  }
}
stopwatch.Stop();
Console.WriteLine($"Total removed '{itemToFind}' items: {totalRemovedRolls}");
Console.WriteLine($"Time taken for Part 2: {stopwatch.ElapsedMilliseconds} ms");


// Commented out for optimization
// // Part 1 - Determine accessible items
// stopwatch.Start();

// totalAccessibleItems = paperGrid.AccessibleRolls();

// stopwatch.Stop();

// Console.WriteLine($"Total accessible '{itemToFind}' items: {totalAccessibleItems}");
// Console.WriteLine($"Time taken for Part 1: {stopwatch.ElapsedMilliseconds} ms");

// // Part 2 - Remove accessible items until none are left, updating accessibility as we g
// stopwatch.Start();

// while (totalAccessibleItems > 0)
// {
//   foreach (var key in paperGrid.gridLocations.Keys)
//   {
//     if (paperGrid.RollExists(key.x, key.y, itemToFind) && paperGrid.gridLocations[key].accessible)
//     {
//       paperGrid.RemoveRoll(key.x, key.y);
//       totalRemovedRolls++;

//       // After removing a roll, we need to re-evaluate accessibility for all rolls
//       totalAccessibleItems = paperGrid.AccessibleRolls();
//     }
//   }
// }

// stopwatch.Stop();
// Console.WriteLine($"Total removed '{itemToFind}' items: {totalRemovedRolls}");
// Console.WriteLine($"Time taken for Part 2: {stopwatch.ElapsedMilliseconds} ms");
