namespace Day3;

public class Joltage
{
  public string bank;
  public int minJoltage;
  public int maxJoltage;
  public char[] joltageRatings;
  public Dictionary<string, char[]> possibleJoltages;
  public int highestJoltage;

  public Joltage(string bank)
  {
    this.bank = bank;
    this.minJoltage = 1;
    this.maxJoltage = 9;
    this.joltageRatings = GetBankJoltages();
    this.possibleJoltages = GetPossibleJoltages();
    this.highestJoltage = GetHighestJoltage();
  }

  // Using extension member to get char array of bank joltages
  public char[] GetBankJoltages() => bank.ToArray();

  // I could just do this in the GetPossibleJoltages method as part of initializing the dictionary, but I wanted to test out extension members a bit further for practice
  public char[] FindLeftJoltage() => joltageRatings[0..(joltageRatings.Length - 1)];

  // Get possible left and right joltages
  public Dictionary<string, char[]> GetPossibleJoltages()
  {
    var possibleJoltages = new Dictionary<string, char[]>
    {
      { "left", FindLeftJoltage() },
      { "right", joltageRatings }
    };
    return possibleJoltages;
  }
  
  public int GetHighestJoltage()
  {
    // Length of possible joltages -1 to avoid including the last element since right will need to be --something-- at least
    int possibleJoltageLength = joltageRatings.Length - 1;

    // Actually using tuples for something for once??? Probably don't need to, but feels nice to have a use case for em
    (int index, int value) highestLeft = (0, 0);
    (int index, int value) highestRight = (0, 0);

    // Loop left first
    for (int i = 0; i < possibleJoltageLength; i++)
    {
      // Checking if current left joltage is higher than the first left joltage
      if (int.Parse(possibleJoltages["left"][i].ToString()) > highestLeft.value)
      {
        // When it IS higher, store the index and the value
        highestLeft = (i, int.Parse(possibleJoltages["left"][i].ToString()));

        // And also set the possible right joltages to be everything AFTER the current stored left index
        possibleJoltages["right"] = joltageRatings[(i + 1)..];
      }
    }

    // Then loop right joltages
    for (int i = 0; i < possibleJoltages["right"].Length; i++)
    {
      if (int.Parse(possibleJoltages["right"][i].ToString()) > highestRight.value)
      {
        // Same logic, but store in right tuple
        highestRight = (i, int.Parse(possibleJoltages["right"][i].ToString()));
      }
    }

    // Concatenate highest left and right values to get overall highest joltage
    highestJoltage = int.Parse(highestLeft.value.ToString() + highestRight.value.ToString());

    return highestJoltage;
  }
}