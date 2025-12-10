namespace Day10;

public class Machine
{
  private char[] _lightDiagram;
  private int[][] _wiringSchematics;
  private int[] _joltageRequirements;

  public string LightDiagram => new string(_lightDiagram);
  public int[][] WiringSchematics => _wiringSchematics;
  public int[] JoltageRequirements => _joltageRequirements;

  public Machine(char[] lightDiagram, int[][] wiringSchematics, int[] joltageRequirements)
  {
      _lightDiagram = lightDiagram;
      _wiringSchematics = wiringSchematics;
      _joltageRequirements = joltageRequirements;
  }
}