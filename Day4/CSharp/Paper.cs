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

  // Optimization - Predefining offsets rather than using GetAdjacentLocations method to create a new list each time
  public (int x, int y)[] offsetCoords = 
  {
    (0, -1), (1, -1), (-1, -1),
    (0, 1),  (1, 1),  (-1, 1),
    (1, 0),  (-1, 0)
  };

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

  public void RemoveRoll(int xCoord, int yCoord)
  {
    gridLocations[(xCoord, yCoord)] = ('.', false);
  }

  // Optimization - Didn't want to remove it so I can remember the unoptimized version to avoid in future
  // public List<(int x, int y)> GetAdjacentLocations(int xCoord, int yCoord)
  // {
  //   // Check all adjacent items N, NE, NW, S, SE, SW, E, W
  //   var adjacentLocations = new List<(int x, int y)>
  //   {
  //     (xCoord, yCoord - 1), // North
  //     (xCoord + 1, yCoord - 1), // Northeast
  //     (xCoord - 1, yCoord - 1), // Northwest
  //     (xCoord, yCoord + 1), // South
  //     (xCoord + 1, yCoord + 1), // Southeast
  //     (xCoord - 1, yCoord + 1), // Southwest
  //     (xCoord + 1, yCoord), // East
  //     (xCoord - 1, yCoord), // West
  //   };

  //   return adjacentLocations;
  // }

  public bool ValidLocation(int xCoord, int yCoord)
  {
    return gridLocations.ContainsKey((xCoord, yCoord));
  }

  public bool RollExists(int xCoord, int yCoord, char itemToFind)
  {
    if (gridLocations[(xCoord, yCoord)].itemToFind == itemToFind)
    {
      return true;
    }
    return false;
  }

  public int AdjacentCount(int xCoord, int yCoord, char itemToFind)
  {
    var adjacentCount = 0;

    foreach (var offset in offsetCoords)
    {
      int adjacentX = xCoord + offset.x;
      int adjacentY = yCoord + offset.y;

      if (ValidLocation(adjacentX, adjacentY) && RollExists(adjacentX, adjacentY, itemToFind))
      {
        adjacentCount++;
      }
    }

    return adjacentCount;
  }

// Optimization - Entire method rewritten to use AdjacentCount rather than GetAdjacentLocations
//   public int AccessibleRolls()
//   {
//     // Initialize item to find
//     char itemToFind = '@';
//     var totalAccessibleItems = 0;

//     foreach (var key in gridLocations.Keys)
//     {
//       // Skip over items that we don't care about
//       if (RollExists(key.x, key.y, itemToFind) == false)
//       {
//         continue;
//       }

//       var adjacentLocations = GetAdjacentLocations(key.x, key.y);
//       var adjacentPaperRolls = 0;
//       foreach (var location in adjacentLocations)
//       {
//         // If the key exists in the dictionary and the value matches the item to find, increase the adjacenet paper roll count
//         if (ValidLocation(location.x, location.y) && RollExists(location.x, location.y, itemToFind))
//         {
//           adjacentPaperRolls++;
//         }
//       }

//       // If there are less than 4 adjacent paper rolls, mark this as accessible, default is to mark as false so this SHOULD allow us to only count the accessible ones
//       if (adjacentPaperRolls < 4)
//       {
//         UpdateAccessible(key.x, key.y, true);
//       }
//     }

//     // Loop through all grid locations again and count the accessible items
//     foreach (var key in gridLocations.Keys)
//     {
//       if (RollExists(key.x, key.y, itemToFind) && gridLocations[key].accessible)
//       {
//         totalAccessibleItems++;
//       }
//     }
//     return totalAccessibleItems;
//   }

  public Queue<(int x, int y)> GetAccessibleRolls(char itemToFind)
  {
    // Initialize queue to store accessible rolls, which will allow us to process only the accessible items for removal instead of having to loop through the entire grid each time
    var accessibleRolls = new Queue<(int x, int y)>();

    foreach (var key in gridLocations.Keys)
    {
      // Skip over items that we don't care about
      if (RollExists(key.x, key.y, itemToFind) == false)
      {
        continue;
      }

      // Store count of adjacent paper rolls, rather than getting the list of adjacent locations then counting them, we can do it in one go
      var adjacentPaperRolls = AdjacentCount(key.x, key.y, itemToFind);
      if (adjacentPaperRolls < 4)
      {
        // Add to accessible rolls queue
        accessibleRolls.Enqueue((key.x, key.y));
      }
    }

    return accessibleRolls;
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

// Part one solved with the accessible marking :D

// Part two thoughts:
// I'm thinking I can add a method to replace a roll (@) with an empty marker (.) similar to what the input has already, which should mean they get skipped by the logic I already added, the recursion of this will be the tricky part
// Going to start by trying to move some of the logic from program.cs to PaperGrid to keep things tidy

// Sixth update:
// Added RemoveRoll method to PaperGrid to replace an item with a '.'
// Moved logic from Program.cs to PaperGrid for part one logic, added a PartOne method for now, will need to tidy this up later

// Seventh update:
// Broke out the out the logic from part one into it's own method AccessibleRolls and some of the logic from there into helper methods

// Eighth update:
// Using a while loop against the total accessible to remove accessible items until none are left, constantly updating the accessibility after each removal

// Part two solved but it's SLOW as hell

// Optimizations:
// Predefined offsets rather than creating a new list each time in GetAdjacentLocations - Comment added above also to show this, remember this for future use, it may come up again
// Rewrote AccessibleRolls to use AdjacentCount rather than GetAdjacentLocations to avoid creating lists and looping through them multiple times
// 