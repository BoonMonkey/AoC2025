namespace Day9;

public class Cinema
{
  private List<(int X, int Y)> _seats;
  public record SeatResult((int X, int Y) SeatA, (int X, int Y) SeatB, long Area);

  public Cinema(string[] input)
  {
    _seats = ProcessSeats(input);
    var result = GetLargestArea();
    PrintResult(result);
  }

  private List<(int X, int Y)> ProcessSeats(string [] input)
  {
    return input
      .Select(line => line.Split(','))
      .Select(parts => (X: int.Parse(parts[0]), Y: int.Parse(parts[1])))
      .ToList();
  }

  public SeatResult GetLargestArea()
  {
    long maxArea = 0;
    (int X, int Y) SeatA = (0, 0);
    (int X, int Y) SeatB = (0, 0);

    for (int i = 0; i < _seats.Count; i++)
    {
        for (int j = 0; j < _seats.Count; j++)
        {
            var seatA = _seats[i];
            var seatB = _seats[j];

            long width = Math.Abs(seatA.X - seatB.X) + 1;
            long height = Math.Abs(seatA.Y - seatB.Y) + 1;
            long currentArea = width * height;

            if (currentArea > maxArea)
            {
                maxArea = currentArea;
                SeatA = seatA;
                SeatB = seatB;
            }
        }
    }

    return new SeatResult(SeatA, SeatB, maxArea);
  } 

  public void PrintResult(SeatResult result)
  {
    Console.WriteLine($"\nLargest Area is {result.Area}");
    Console.WriteLine($"Defined by seats: ({result.SeatA.X},{result.SeatA.Y}) and ({result.SeatB.X},{result.SeatB.Y})");
  }
}