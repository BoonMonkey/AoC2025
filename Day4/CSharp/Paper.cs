namespace Day4;

public class PaperPile
{
  const int START_X = 0;
  const int START_Y = -1;
  
  public (int x, int y) rowCoords = (0, 0);

  public PaperPile()
  {
    rowCoords = (START_X, START_Y);
  }

  public void AddStack()
  {
    // Increase Y coord every new row added
    rowCoords.y++;
  }

  public void AddRoll(int positionInRow)
  {
    // Increase X coord every new item in the row
    rowCoords.x = positionInRow;
  }
}

public class PaperGrid
{
  // Dictionary to store all grid locations and their value
  public Dictionary<(int x, int y), (char itemToFind, bool accessible)> gridLocations = new Dictionary<(int x, int y), (char itemToFind, bool accessible)>();

  public void PopulateGrid(int xCoord, int yCoord, char value)
  {
    // Adds location to the dictionary, obviously :D 
    gridLocations.Add((xCoord, yCoord), (value, false));
  }

  public void UpdateAccessible(int xCoord, int yCoord, bool isAccessible)
  {
    var currentValue = gridLocations[(xCoord, yCoord)];
    gridLocations[(xCoord, yCoord)] = (currentValue.itemToFind, isAccessible);
  }

  public List<(int x, int y)> GetAdjacentLocations(int xCoord, int yCoord)
  {
    // Check all adjacent items N, NE, NW, S, SE, SW, E, W
    var adjacentLocations = new List<(int x, int y)>
    {
      (xCoord, yCoord - 1), // North
      (xCoord + 1, yCoord - 1), // Northeast
      (xCoord - 1, yCoord - 1), // Northwest
      (xCoord, yCoord + 1), // South
      (xCoord + 1, yCoord + 1), // Southeast
      (xCoord - 1, yCoord + 1), // Southwest
      (xCoord + 1, yCoord), // East
      (xCoord - 1, yCoord), // West
    };

    return adjacentLocations;
  }
}


// Initial thoughts:
// PaperPile will be used to represent the entire wall of paper rolls
// PaperRow will represent line of paper rolls from the input and use a dictionary to store the coordinates of each item
// PaperLocator will be used to find the specific items in the warehouse that the forklift can access

// First update:
// Removed PaperRow and combined it into PaperPile

// Second update: 
// Removed PaperLocator and combined it into PaperGrid
// PaperGrid now holds the dictionary of all grid locations and their values
// PaperGrid and PaperPile can probably be combined, will consider that later, but for now this works fine and I don't want to get too bogged down in refactoring

// Third update:
// Grid positions seem to be working well, just trying to find the adjacent items now

// Fourth update:
// Added method to get adjacent locations and output them in a list of tuples containing their X and Y
// Next step will be to see if I can check the dictionary contains keys for these positions and if so, check if their value matches the character necessary, then I can just see if there are more than 4 of them after that

// Firth update:
// Added a bool to the dictionary value tuple to indicate if the item has been marked as accessible, this should help us avoid double counting items since my current return is 34 as opposed to the example 13