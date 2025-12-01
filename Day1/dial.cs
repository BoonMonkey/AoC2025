namespace dial;

public class Dial
{
    public int Size { get; }
    public int Position { get; private set; }
    public int TimesZeroReached { get; set; }

    public Dial(int size, int startPosition)
    {
      Size = size;
      Position = startPosition;
      TimesZeroReached = 0;
    }

    public void Turn(int steps, string direction)
    {
      int stepValue = (direction == "R") ? 1 : -1;
      Position += steps * stepValue;
      Position = ((Position % Size) + Size) % Size;
      if (Position == 0)
      {
        TimesZeroReached++;
      }
    }

    public void TurnCountAllZero(int steps, string direction)
    {
      int stepValue = (direction == "R") ? 1 : -1;
      for (int i = 0; i < steps; i++)
      {
        Position += stepValue;
        Position = ((Position % Size) + Size) % Size;
        if (Position == 0)
        {
          TimesZeroReached++;
        }
      }
    }
}