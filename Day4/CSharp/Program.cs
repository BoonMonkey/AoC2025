using Day4;

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

foreach (var input in inputs)
{
  paperPile.AddStack();
  for (int xCoord = 0; xCoord < input.Length; xCoord++)
  {
    paperPile.AddRoll(xCoord);
    paperGrid.PopulateGrid(paperPile.rowCoords.x, paperPile.rowCoords.y, input[xCoord]);
  }
}

foreach (var key in paperGrid.gridLocations.Keys)
{
  // Skip over items that we don't care about
  if (paperGrid.gridLocations[key].itemToFind != itemToFind)
  {
    continue;
  }

  var adjacentLocations = paperGrid.GetAdjacentLocations(key.x, key.y);
  // Console.WriteLine($"There are {adjacentLocations.Count} adjacent locations to ({key.x}, {key.y})");
  var adjacentPaperRolls = 0;
  foreach (var location in adjacentLocations)
  {
    // If the key exists in the dictionary and the value matches the item to find, increase the adjacenet paper roll count
    if (paperGrid.gridLocations.ContainsKey((location.x, location.y)) && paperGrid.gridLocations[(location.x, location.y)].itemToFind == itemToFind)
    {
      adjacentPaperRolls++;
    }
  }

  // If there are less than 4 adjacent paper rolls, mark this as assessible, default is to mark as false so this SHOULD allow us to only count the accessible ones
  if (adjacentPaperRolls < 4)
  {
    paperGrid.UpdateAccessible(key.x, key.y, true);
  }
}

// Loop through all grid locations again and count the accessible items
foreach (var key in paperGrid.gridLocations.Keys)
{
  if (paperGrid.gridLocations[key].itemToFind == itemToFind && paperGrid.gridLocations[key].accessible)
  {
    totalAccessibleItems++;
  }
}

Console.WriteLine($"Total accessible '{itemToFind}' items: {totalAccessibleItems}");


