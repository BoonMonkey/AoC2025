namespace Day10;

public class Machine
{
  private char[] _initialLightDiagram; // Array of . and # characters | . = off, # = on | This represents the initial pattern
  private char[] _desiredLightDiagram; // Array of . and # characters | . = off, # = on | This represents the desired pattern | Default is all off
  private int _buttonCount;
  private int[][] _buttonWiringSchematics;
  private int[] _joltageRequirements;

  public string InitialLightDiagram => new string(_initialLightDiagram);
  public string DesiredLightDiagram => new string(_desiredLightDiagram);
  public int ButtonCount => _buttonCount;
  public int[][] ButtonWiringSchematics => _buttonWiringSchematics;
  public int[] JoltageRequirements => _joltageRequirements;

  public Machine(char[] initialLightDiagram, char[] desiredLightDiagram, int[][] buttonWiringSchematics, int[] joltageRequirements)
  {
      _initialLightDiagram = initialLightDiagram;
      _desiredLightDiagram = desiredLightDiagram;
      _buttonCount = buttonWiringSchematics.Length;
      _buttonWiringSchematics = buttonWiringSchematics;
      _joltageRequirements = joltageRequirements;
  }
}