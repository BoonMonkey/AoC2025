namespace Day6;

public class Homework
{
  private string[] _inputLines; // Private to hold the input lines and not be exposed directly
  private string[] _operators; // Private to hold the operators and not be exposed directly
  private Dictionary<int, List<string>> _numbersByLine; // Private to hold the numbers by line and not be exposed directly
  private int _inputLineCounter; // Private to hold the line counter and not be exposed directly
  private Queue<int[]> _columns; // Private to hold the columns and not be exposed directly
  private string _part; // Private to hold the part (part one or part two) and not be exposed directly

  public string[] Operators => _operators; // Public to allow read-only access to the operators
  public Dictionary<int, List<string>> NumbersByLine => _numbersByLine; // Public to allow read-only access to the numbers by line
  public Queue<int[]> Columns => _columns; // Public to allow read-only access to the columns
  
  
  public Homework(string[] inputLines, string part)
  {
    _inputLines = inputLines;
    _numbersByLine = new Dictionary<int, List<string>>();
    _operators = Array.Empty<string>();
    _columns = new Queue<int[]>();
    _part = part;
    GetNumbersByLine();
    GetOperator();
    LinesToColumns();
  }

  public void GetNumbersByLine()
  {
    var numbersByLineDict = _numbersByLine; // Initialize the dictionary to hold numbers by line
    _inputLineCounter = 0; // Initialize line counter for the key in the dictionary

    foreach (var inputLine in _inputLines)
    {
      if (inputLine.Contains("*") || inputLine.Contains("+")) // Skip lines containing "*" or "+"
      {
        continue;
      }

      var numbersInLine = new List<string>(); // List to hold numbers found in the current line

      if (_part == "partOne") // Check if we're processing part one
      {
        var splitInput = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries); // Split the input line by space and remove empty entries
        numbersInLine.AddRange(splitInput); // Adding all items from the split to the list
      }
      else if (_part == "partTwo")
      {
        foreach (char character in inputLine)
        {
          numbersInLine.Add(character.ToString()); // Add each character as a string to the list, including spaces to make sure I'm not skipping any positions
        }
      }

      numbersByLineDict.Add(_inputLineCounter, numbersInLine); // Add the list to the dictionary with the current line counter as the key
      _inputLineCounter++; // Increment the line counter for the next line
    }
    _numbersByLine = numbersByLineDict; // Assign the populated dictionary to the private field
  }

  public void GetOperator()
  {
    var operatorLine = _inputLines[^1].Trim().Split(" "); // Access the last line of input lines and split by space
    var operatorList = _operators.ToList(); // Convert the array of operators to a list

    foreach (var character in operatorLine)
    {
      if (character.Length > 0)
      {
        operatorList.Add(character); // If the split part does have a length > 0, it's an operator, so add it to the list
      }
    }
    _operators = operatorList.ToArray(); // Assign the split operators to the private field
  }

  public void LinesToColumns()
  {
    var totalColumns = _numbersByLine[0].Count; // Determine the total number of columns based on the first line's count
    for (int i = 0; i < totalColumns; i++)
    {
      _columns.Enqueue(GetColumns(i)); // Enqueue the column array obtained from GetColumns method
    }
  }

  public int[] GetColumns(int columnIndex)
  {
    var column = new List<int>(); // Initialize a list to hold the numbers in the specified column
    for (int i = 0; i < _numbersByLine.Count; i++)
    {
      if (columnIndex < _numbersByLine[i].Count) // Check if the column index is valid for the current line
      {
        string columnValue = _numbersByLine[i][columnIndex];

        if (_part == "partOne")
        {
          column.Add(int.Parse(columnValue)); // Parse string as int and add to the list for part one
        }
        else if (_part == "partTwo")
        {
          if (int.TryParse(columnValue, out int columnValueInt))
          {
            column.Add(columnValueInt); // Parse string as int and add to the list for part two if it's numeric
          }
        }
      }
    }
    return column.ToArray(); // Return the populated array
  }

  public void PartOneColumnMath()
  {
    var columnToProcess = 0;
    long totalFromColumnValues = 0;
    while (_columns.Count > 0)
    {
      var currentColumn = _columns.Dequeue(); // Dequeue the next column to process
      var currentOperator = _operators[columnToProcess]; // Get the operator for the current column

      if (currentOperator == "*")
      {
        long output = 1; // Using long to avoid int32 overflow
        foreach (var number in currentColumn)
        {
          output *= number; // Multiply each number in the column
        }
        totalFromColumnValues += output;
      }
      else if (currentOperator == "+")
      {
        long output = 0; // Using long to avoid int32 overflow
        foreach (var number in currentColumn)
        {
          output += number; // Add each number in the column
        }
        totalFromColumnValues += output;
      }
      columnToProcess++;
    }
    Console.WriteLine($"Total from all column values: {totalFromColumnValues}");
  }

  public void PartTwo()
  {
    string[][] grid = new string[_inputLines.Length][]; 
    Dictionary<(int y, int x), string> gridDict = new Dictionary<(int y, int x), string>();
    for (int i = 0; i < _inputLines.Length; i++)
    {
      grid[i] = _inputLines[i].Select(c => c.ToString()).ToArray();
    }

    Console.WriteLine("Grid representation for Part Two:");
    foreach (var row in grid)
    {
      Console.WriteLine(string.Join(",", row));
    }

    for (int row = 0; row < grid.Length; row++)
    {
      for (int col = 0; col < grid[row].Length; col++)
      {
        gridDict[(row, col)] = grid[row][col];
      }
    }

    Console.WriteLine("Grid Dictionary representation for Part Two:");
    foreach (var item in gridDict)
    {
      if (gridDict[item.Key] == " ")
      {
        gridDict.Remove(item.Key);
        continue;
      }
      Console.WriteLine($"Position: {item.Key}, Value: {item.Value}");
    }

    int rowCount = gridDict.Keys.Max(k => k.y);
    int colCount = gridDict.Keys.Max(k => k.x);
    var columns = new Queue<string>();

    for (int col = colCount; col >= 0; col--)
    {
      var columnValues = new List<string>();
      for (int row = 0; row <= rowCount; row++)
      {
        if (gridDict.ContainsKey((row, col)))
        {
          columnValues.Add(gridDict[(row, col)]);
        }
      }
      var columnString = string.Join("", columnValues);
      columns.Enqueue(columnString);
    }

    Console.WriteLine($"Queue representation of columns for Part Two:");
    foreach (var item in columns)
    {
      Console.WriteLine(item);
    }
  }
}