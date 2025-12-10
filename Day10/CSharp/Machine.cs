using System.Diagnostics.Contracts;

namespace Day10;

public class Machine
{
  public char[] InitialLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the initial pattern
  public char [] CurrentLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the current pattern during operation
  public char[] DesiredLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the desired pattern | Default is all off
  public int ButtonCount { get; private set; } // Number of buttons on the machine
  public int[][] ButtonWiringSchematics { get; private set; } // Array which indicates which lights each button toggles
  public int[] JoltageRequirements { get; private set; } // Not needed for part one, but included for completeness
  public List<int> ButtonHistory { get; private set; } // History of button presses

  public Machine(char[] initialLightDiagram, char[] desiredLightDiagram, int[][] buttonWiringSchematics, int[] joltageRequirements)
  {
    InitialLightDiagram = initialLightDiagram;
    CurrentLightDiagram = initialLightDiagram;
    DesiredLightDiagram = desiredLightDiagram;
    ButtonWiringSchematics = buttonWiringSchematics;
    JoltageRequirements = joltageRequirements;
    ButtonCount = buttonWiringSchematics.Length;
    ButtonHistory = new List<int>();
  }

  public void FindMatchingCombination()
  {
    // This is a placeholder for the logic to find the correct button combination
    // to achieve the desired light diagram from the initial light diagram.
    // Buttons can be pressed multiple times. This could involve a backtracking algorithm
    // or a breadth-first search through the state space of light diagrams.
  }

  public void PressButton(int buttonIndex)
  {
    var wiringSchematic = ButtonWiringSchematics[buttonIndex];
    foreach (var lightIndex in wiringSchematic) // Loop through each light that this button toggles
    {
      CurrentLightDiagram[lightIndex] = CurrentLightDiagram[lightIndex] == '#' ? '.' : '#'; // Toggle the light
    }
  }

  public void CheckLightDiagram()
  {
    if (new string(CurrentLightDiagram) == new string(DesiredLightDiagram))
    {
      Console.WriteLine("Desired light diagram achieved!");
    }
    else
    {
      Console.WriteLine("Current light diagram does not match desired.");
    }
  }

  public void ResetMachine()
  {
    CurrentLightDiagram = InitialLightDiagram;
  }
}