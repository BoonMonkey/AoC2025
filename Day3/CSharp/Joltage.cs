namespace Day3;

public class Joltage
{
  public string bank;
  public long highestJoltage;

  public Joltage(string bank, int batteryCount)
  {
    this.bank = bank;
    this.highestJoltage = GetHighestJoltage(batteryCount);
  }
  
  public long GetHighestJoltage(int batteryCount)
  {
    // Bank split into list to allow easier manipulation
    List<char> bankList = bank.ToList();

    // Second list to store batteries as they are enabled
    List<char> enabledBatteries = new List<char>();

    // Count of batteries to be disabled
    int disableCounter = bankList.Count - batteryCount;

    // Loop through each battery in the bank
    foreach (var battery in bankList)
    {
      // If batteries to be disabled is greater than 0
      // And enabled batteries isn't empty
      // And the current battery is greater than the last enabled battery
      while (disableCounter > 0 && enabledBatteries.Count > 0 && battery > enabledBatteries[^1])
      {
        // Remove the last enabled battery
        enabledBatteries.Remove(enabledBatteries[^1]);

        // Decrease the disable counter as we've disabled a battery
        disableCounter--;
      }

      // Add the current battery to the enabled batteries list
      enabledBatteries.Add(battery);
    }

    // If disabledCounter still has some wiggle room, remove batteries from the end until
    // we reach the desired battery count, this allows for this solution to work for part one as well
    while (enabledBatteries.Count > batteryCount)
    {
      enabledBatteries.Remove(enabledBatteries[^1]);
    }

    // Return the concatenated enabled batteries as a long (int is too small for this)
    return long.Parse(string.Join("", enabledBatteries));
  }
}