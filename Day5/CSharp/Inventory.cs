namespace Day5;

public class Inventory
{
  public string[] ids;
  public string[] freshIdStrings;
  public string[] availableIdStrings;
  public Queue<string> processingQueue = new Queue<string>();
  public long[][] freshIdRanges;
  public int totalFreshFromAvailable;
  public long totalFreshFromRanges;

  public Inventory(string[] inputLines)
  {
      ids = inputLines;
      freshIdStrings = FreshIdStrings();
      availableIdStrings = AvailableIdStrings();

      // Using the queue learnt yesterday to add all available IDs for processing, these will be removed one by one later, saves me adding hundreds if not thousands of lists
      processingQueue = new Queue<string>(availableIdStrings);

      freshIdRanges = FreshIdRanges();
      totalFreshFromAvailable = FreshFromAvailable();
      totalFreshFromRanges = FreshFromRanges();
  }

  // Finding fresh ingredients by taking the strings before the empty line
  public string[] FreshIdStrings()
  {
    var seperatorPosition = Array.IndexOf(ids, string.Empty);
    freshIdStrings = ids[..seperatorPosition];
    return freshIdStrings;
  }

  // Finding available ingredients by taking the strings after the empty line
  public string[] AvailableIdStrings()
  {
    var seperatorPosition = Array.IndexOf(ids, string.Empty);
    availableIdStrings = ids[(seperatorPosition + 1)..];
    return availableIdStrings;
  }

  // Adding fresh ID ranges to a list of long arrays for I can check against them easier later
  public long[][] FreshIdRanges()
  {
    var ranges = new List<long[]>();
    foreach (var id in freshIdStrings)
    {
        string[] parts = id.Split('-');
        long start = long.Parse(parts[0]);
        long end = long.Parse(parts[1]);
        ranges.Add(new long[] { start, end });
    }
    return ranges.ToArray();
  }

  // Checking available IDs against fresh ID ranges and counting how many are fresh
  public int FreshFromAvailable()
  {
    var totalFreshFromAvailable = 0;
    while (processingQueue.Count > 0)
    {
        var currentIdStr = processingQueue.Dequeue();
        var currentId = long.Parse(currentIdStr);
        foreach (var range in freshIdRanges)
        {
            if (currentId >= range[0] && currentId <= range[1])
            {
                totalFreshFromAvailable++;
                break;
            }
        }
    }
    return totalFreshFromAvailable;
  }

  // Counting fresh IDs from ranges using a HashSet to ensure no double counting
  public long FreshFromRanges()
  {
    // Using long to avoid overflow issues with large ranges
    long totalUniqueFromRanges = 0;

    // Sort ranges by their starting values so all overlaps are adjacent
    Array.Sort(freshIdRanges, (start, end) => start[0].CompareTo(end[0]));

    // Set initial range start and end to the first range in the sorted list
    var (currentRangeStart, currentRangeEnd) = (freshIdRanges[0][0], freshIdRanges[0][1]);

    // Iterate through the sorted ranges to merge overlapping ones
    for (int i = 0; i < freshIdRanges.Length; i++)
    {
      var (nextRangeStart, nextRangeEnd) = (freshIdRanges[i][0], freshIdRanges[i][1]);

      // If the next range starts after the current range ends, then there is no overlap and we can add the current range to the total
      if (nextRangeStart > currentRangeEnd)
      {
        totalUniqueFromRanges += (currentRangeEnd - currentRangeStart) + 1; 

        // Move to the next range
        currentRangeStart = nextRangeStart;
        currentRangeEnd = nextRangeEnd;
      }
      // If the next range starts within the current range, we have an overlap
      else if (nextRangeEnd > currentRangeEnd)
      {
        // So the end of the current range is extended to the end of the next range, which is the merge part of this process
        currentRangeEnd = nextRangeEnd;
      }
    } 

    // Need to process the last range after the for loop to avoid index out of bounds
    totalUniqueFromRanges += (currentRangeEnd - currentRangeStart) + 1;
    return totalUniqueFromRanges;
  }
}