namespace idCheck;

public class IdCheck
{
  public long startId;
  public long endId;
  public long[] idsToCheck;
  public long[] partOneInvalidIds;
  public long[]? partTwoInvalidIds;
  public long sumOfInvalidIds;

  public IdCheck(long startId, long endId)
  {
    var idRangeList = new List<long>();
    for (long i = startId; i <= endId; i++)
    {
      idRangeList.Add(i);
    }
    this.startId = startId;
    this.endId = endId;
    this.idsToCheck = idRangeList.ToArray();
    this.partOneInvalidIds = GetPartOneInvalidIds(this.idsToCheck);
    this.partTwoInvalidIds = GetPartTwoInvalidIds(this.idsToCheck);
    this.sumOfInvalidIds = AddAllInvalid(this.partOneInvalidIds, this.partTwoInvalidIds);
  }

  public long[] GetPartOneInvalidIds(long[] idRange)
  {
    var hashSet = new HashSet<long>();
    foreach (var id in idRange)
    {
      if (id.ToString().Length % 2 == 0)
      {
        string idStr = id.ToString();
        string firstHalf = idStr.Substring(0, idStr.Length / 2);
        string secondHalf = idStr.Substring(idStr.Length / 2);
        if (firstHalf == secondHalf)
        {
          hashSet.Add(id);
        }
      }
    }
    return hashSet.ToArray();
  }

  public long[] GetPartTwoInvalidIds(long[] idRange)
  {
    var hashSet = new HashSet<long>();
    foreach (var id in idRange)
    {
      int idLength = id.ToString().Length;

      // Searching for repeating patterns up to half the length of the ID
      for (int i = 1; i <= idLength / 2; i++)
      {
        // If length is not divisible by i (pattern length), skip
        if (idLength % i != 0)
        {
          continue;
        }

        // Store found pattern in var
        string pattern = id.ToString().Substring(0, i);

        var stringBuilder = new System.Text.StringBuilder();
        for (int j = 0; j < idLength / i; j++)
        {
          stringBuilder.Append(pattern);
        }

        if (stringBuilder.ToString() == id.ToString())
        {
          hashSet.Add(id);
        }
      }
    }

    return hashSet.ToArray();
  }

  public long AddAllInvalid(long[] partOneInvalidIds, long[]? partTwoInvalidIds = null)
  {
    if (partTwoInvalidIds == null)
    {
      foreach (var id in partOneInvalidIds)
      {
        sumOfInvalidIds += id;
      }
    } 
    else if (partTwoInvalidIds != null)
    {
      foreach (var id in partTwoInvalidIds)
      {
        sumOfInvalidIds += id;
      }
    }

    return sumOfInvalidIds;
  }
}