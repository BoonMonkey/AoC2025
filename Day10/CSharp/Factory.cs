namespace Day10;

public class Factory
{
  private readonly string[] _inputLines;
  private readonly List<Machine> _machineList;

  public Factory(string[] inputLines)
  {
      _inputLines = inputLines;
      _machineList = BuildMachines();
      PrintMachines();
  }

  public List<Machine> BuildMachines()
  {
    var machines = new List<Machine>();
    foreach (var line in _inputLines)
    {
      var parts = line.Split(" ");
      var lightDiagram = Array.Empty<char>();
      var wiringSchematics = Array.Empty<int[]>();
      var joltageRequirements = Array.Empty<int>();
      foreach (var part in parts)
      {
        if (part.Contains("["))
        {
          lightDiagram = part.Trim('[', ']').ToCharArray();
          // Console.WriteLine($"Light Diagram: {new string(lightDiagram)}, Type: {lightDiagram.GetType()}"); // Debug line to check output and type
        }

        if (part.Contains("("))
        {
          var wiringSchematic = part.Trim('(', ')').Split(',').Select(s => int.Parse(s)).ToArray();
          wiringSchematics = wiringSchematics.Append(wiringSchematic).ToArray();
          // Console.WriteLine($"Wiring Schematics: {string.Join(", ", wiringSchematic)}, Type: {wiringSchematic.GetType()}"); // Debug line to check output and type
        }

        if (part.Contains("{"))
        {
          joltageRequirements = part.Trim('{', '}').Split(',').Select(s => int.Parse(s)).ToArray();
          // Console.WriteLine($"Joltage Requirements: {string.Join(", ", joltageRequirement)}, Type: {joltageRequirement.GetType()}"); // Debug line to check output and type
        }
      }
      // Console.WriteLine($"Parsed Machine - Light Diagram: {new string(lightDiagram)}, Wiring Schematics Count: {wiringSchematics.Length}, Joltage Requirements: {string.Join(", ", joltageRequirement)}"); // Debug line to check parsed values
      var machine = new Machine(lightDiagram, wiringSchematics, joltageRequirements);
      machines.Add(machine);
    }
    return machines;
  }

  public void PrintMachines()
  {
    foreach (var machine in _machineList)
    {
      Console.WriteLine("Machine Details:");
      Console.WriteLine($"  Light Diagram: {machine.LightDiagram}");
      Console.WriteLine("  Wiring Schematics:");
      foreach (var wiring in machine.WiringSchematics)
      {
        Console.WriteLine($"    - {string.Join(", ", wiring)}");
      }
      Console.WriteLine($"  Joltage Requirements: {string.Join(", ", machine.JoltageRequirements)}");
      Console.WriteLine(); // Blank line for better readability between machines
    }
  }
}