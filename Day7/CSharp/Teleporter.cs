namespace Day7;

public class Teleporter
{
  private string[] _input;
  private Queue<int[]> _movements = new Queue<int[]>();
  private int _totalSplits = 0;
  private int _row = 0;
  private char _startChar = 'S';
  private char _beamChar = '|';
  private char _splitterChar = '^';
  private char _openSpaceChar = '.';

  public int TotalSplits => _totalSplits;

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
      PrintGrid(); // Just used for debugging
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

  public void PrintGrid()
  {
      foreach (var line in _input)
      {
          Console.WriteLine(line);
      }
  }
}