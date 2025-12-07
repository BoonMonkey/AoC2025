namespace Day7;

public class Teleporter
{
  private string[] _input;
  private Queue<int[]> _movements = new Queue<int[]>();
  private int _totalSplits = 0;
  private long _totalTimelines = 0;
  private int _row = 0;
  private char _startChar = 'S';
  private char _beamChar = '|';
  private char _splitterChar = '^';
  private char _openSpaceChar = '.';

  public int TotalSplits => _totalSplits;
  public long TotalTimelines => _totalTimelines;

  public Teleporter(string[] input)
  {
      _input = input;
  }

  public int GetStartPos() => _input[_row].IndexOf(_startChar);
  public void NextRow() => _row++;
  public void SetBeam(int pos) => _input[_row] = _input[_row].Remove(pos, 1).Insert(pos, _beamChar.ToString());

  public void Move()
  {
    _row = 0;
    while (_movements.Count > 0 && _row < _input.Length)
    {
      int[] positions = _movements.Dequeue();
      var currentLine = _input[_row];
      
      for (int i = 0; i < positions.Length; i++)
      {
        int pos = positions[i];
        var currentChar = currentLine[pos];
        if (currentChar == _openSpaceChar)
        {
            SetBeam(pos);
        }
        else if (currentChar == _splitterChar)
        {
          if (pos > 0)
          {
              SetBeam(pos - 1);
              
          }
          if (pos < currentLine.Length - 1)
          {
              SetBeam(pos + 1);
          }
          _totalSplits++;
        }
      }

      NextRow();
      // PrintGrid(); // Just used for debugging
    }
  }

  public void GetMovements(int startPos)
  {
      List<int> startPosList = new List<int>{GetStartPos()};
      Queue<int[]> movementList = new Queue<int[]>();
      movementList.Enqueue(startPosList.ToArray());

      while (_row < _input.Length)
      {
        List<int> newPositions = new List<int>{};
        foreach (var pos in startPosList)
        {
            if (_input[_row][pos] == _splitterChar)
            {
                newPositions.Add(pos - 1);
                newPositions.Add(pos + 1);
            }
            else
            {
                newPositions.Add(pos);
            }
        }
        newPositions = newPositions.Distinct().ToList();
        movementList.Enqueue(newPositions.ToArray());
        startPosList = newPositions;

        NextRow();
      }

      _movements = movementList;
  }

  public void GetTimelines()
  {
    _row = 0;

    var timelines = new Dictionary<int, long>(); // Position / Count of timelines
    timelines[GetStartPos()] = 1; // Start with one timeline at the start position

    while (_row < _input.Length)
    {
      var newTimeline = new Dictionary<int, long>();

      foreach (var timeline in timelines) // Go through each position in the current timeline
      {
        int position = timeline.Key; // Position in the current timeline
        long count = timeline.Value; // Number of timelines reaching this position, AddToTimeline will handle adding this count to new timelines

        if (position < 0 || position >= _input[_row].Length)
        {
          continue; // Out of bounds
        }

        char currentChar = _input[_row][position];
      
        if (currentChar == _splitterChar)
        {
          AddToTimeline(newTimeline, position - 1, count); // Split the timeline
          AddToTimeline(newTimeline, position + 1, count); // Split the timeline
        }
        else
        {
          AddToTimeline(newTimeline, position, count); // Continue down the same position
        }
      }
      timelines = newTimeline; // Update the timelines to the new timeline for the next row
      NextRow(); // Move to the next row
    }

    _totalTimelines = timelines.Values.Sum(); // +1 for the initial timeline
  }

  public void AddToTimeline(Dictionary<int, long> timelines, int position, long count)
  {
      if (!timelines.ContainsKey(position))
      {
          timelines[position] = 0; // If the row isn't already present in the timeline, initialize it to 0
      }
      timelines[position] += count; // Otherwise add the count var (number of timelines reaching this position) to the existing count
  }

  public void PrintGrid()
  {
      foreach (var line in _input)
      {
          Console.WriteLine(line);
      }
  }
}