namespace Day10;

public class Machine
{
  private char[] _initialLightDiagram; // Array of . and # characters | . = off, # = on | This represents the initial pattern
  private char [] _currentLightDiagram; // Array of . and # characters | . = off, # = on | This represents the current pattern during operation
  private char[] _desiredLightDiagram; // Array of . and # characters | . = off, # = on | This represents the desired pattern | Default is all off
  private int _buttonCount; // Number of buttons on the machine
  private int[][] _buttonWiringSchematics; // Array which indicates which lights each button toggles
  private int[] _joltageRequirements; // Not needed for part one, but included for completeness

  public string InitialLightDiagram => new string(_initialLightDiagram);
  public string CurrentLightDiagram => new string(_currentLightDiagram);
  public string DesiredLightDiagram => new string(_desiredLightDiagram);
  public int ButtonCount => _buttonCount;
  public int[][] ButtonWiringSchematics => _buttonWiringSchematics;
  public int[] JoltageRequirements => _joltageRequirements;

  public Machine(char[] initialLightDiagram, char[] desiredLightDiagram, int[][] buttonWiringSchematics, int[] joltageRequirements)
  {
      _initialLightDiagram = initialLightDiagram;
      _currentLightDiagram = initialLightDiagram;
      _desiredLightDiagram = desiredLightDiagram;
      _buttonCount = buttonWiringSchematics.Length;
      _buttonWiringSchematics = buttonWiringSchematics;
      _joltageRequirements = joltageRequirements;
  }

  public void PressButton(int buttonIndex)
  {
    var wiringSchematic = _buttonWiringSchematics[buttonIndex];
    foreach (var lightIndex in wiringSchematic) // Loop through each light that this button toggles
    {
      _currentLightDiagram[lightIndex] = _currentLightDiagram[lightIndex] == '#' ? '.' : '#'; // Toggle the light
    }
  }
}