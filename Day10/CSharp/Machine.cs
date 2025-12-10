using System.Diagnostics.Contracts;

namespace Day10;

public class Machine
{
  public char[] initialLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the initial pattern
  public char [] currentLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the current pattern during operation
  public char[] desiredLightDiagram { get; private set; } // Array of . and # characters | . = off, # = on | This represents the desired pattern | Default is all off
  public int buttonCount { get; private set; } // Number of buttons on the machine
  public int[][] buttonWiringSchematics { get; private set; } // Array which indicates which lights each button toggles
  public int[] joltageRequirements { get; private set; } // Not needed for part one, but included for completeness

  public Machine(char[] initialLightDiagram, char[] desiredLightDiagram, int[][] buttonWiringSchematics, int[] joltageRequirements)
  {
    this.initialLightDiagram = initialLightDiagram;
    this.currentLightDiagram = initialLightDiagram;
    this.desiredLightDiagram = desiredLightDiagram;
    this.buttonWiringSchematics = buttonWiringSchematics;
    this.joltageRequirements = joltageRequirements;
    this.buttonCount = buttonWiringSchematics.Length;
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
    var wiringSchematic = buttonWiringSchematics[buttonIndex];
    foreach (var lightIndex in wiringSchematic) // Loop through each light that this button toggles
    {
      currentLightDiagram[lightIndex] = currentLightDiagram[lightIndex] == '#' ? '.' : '#'; // Toggle the light
    }
  }

  public void CheckLightDiagram()
  {
    if (new string(currentLightDiagram) == new string(desiredLightDiagram))
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
    currentLightDiagram = initialLightDiagram;
  }
}