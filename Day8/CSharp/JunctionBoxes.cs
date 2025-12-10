namespace Day8;

public class JunctionBoxes
{
  private string[] _input;
  private Dictionary<int, (int[] coords, int[] connectingBoxes, int[] distances)> _boxDistances = new Dictionary<int, (int[] coords, int[] connectingBoxes, int[] distances)>();

  public JunctionBoxes(string[] inputLines) 
  {
      _input = inputLines;
      ParseAll();
      MapConnections();
  }

  public int[] ParseLine(string line)
  {
    var boxes = line.Split(',');
    List<int> boxCoords = new List<int>();
    foreach (var box in boxes)
    {
      boxCoords.Add(int.Parse(box));
    }
    return boxCoords.ToArray();
  }

  public void ParseAll()
  {
    for (int boxIndex = 0; boxIndex < _input.Length; boxIndex++)
    {
      var boxCoords = ParseLine(_input[boxIndex]);
      int summedCoords = boxCoords.Sum();
      int smallestDistanceSum = 99999; // Arbitrary large number
      List<int> connectingBoxes = new List<int>();
      List<int> connectingDistances = new List<int>();

      for (var nextBoxIndex = boxIndex + 1; nextBoxIndex < _input.Length; nextBoxIndex++)
      {
        var nextBoxCoords = ParseLine(_input[nextBoxIndex]);
        int summedNextCoords = nextBoxCoords.Sum();
        int distanceSum = Math.Abs(summedCoords - summedNextCoords);
        if (distanceSum < smallestDistanceSum)
        {
          smallestDistanceSum = distanceSum;
          connectingBoxes.Add(nextBoxIndex);
          connectingDistances.Add(distanceSum);
        }
        else
        {
          // Check next box
          continue;
        }
      }

      if (!_boxDistances.ContainsKey(boxIndex))
      {
        _boxDistances.Add(boxIndex, (new int[] {}, new int[] {}, new int[] {}));
      }
      _boxDistances[boxIndex] = (boxCoords, connectingBoxes.ToArray(), connectingDistances.ToArray());
    }
  }

  public void MapConnections()
  {
    foreach (var box in _boxDistances)
    {
      var distancesList = box.Value.distances.ToList();
      distancesList.Sort();
    }
    DebugDict();
  }

  public void DebugDict()
  {
    foreach (var box in _boxDistances)
    {
      Console.WriteLine($"Box {box.Key}: {string.Join(", ", box.Value.coords)}");
      Console.WriteLine($"  Connecting Boxes: {string.Join(", ", box.Value.connectingBoxes)}");
      Console.WriteLine($"  Connecting Boxes Count: {box.Value.connectingBoxes.Length}");
      Console.WriteLine($"  Connecting Distances: {string.Join(", ", box.Value.distances)}");
    }
  }

  public void GetDistanceFromBox(int boxIndex)
  {
    Console.WriteLine($"Checking Box: {boxIndex} with value {_boxDistances[boxIndex]}");
  }
}