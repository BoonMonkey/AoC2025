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
      var initialLightDiagram = Array.Empty<char>();
      var desiredLightDiagram = Array.Empty<char>();
      var buttonWiringSchematics = Array.Empty<int[]>();
      var joltageRequirements = Array.Empty<int>();
      foreach (var part in parts)
      {
        if (part.Contains("["))
        {
          initialLightDiagram = part.Trim('[', ']').Replace("#", ".").ToCharArray();
          desiredLightDiagram = part.Trim('[', ']').ToCharArray();
        }

        if (part.Contains("("))
        {
          var buttonWiringSchematic = part.Trim('(', ')').Split(',').Select(s => int.Parse(s)).ToArray();
          buttonWiringSchematics = buttonWiringSchematics.Append(buttonWiringSchematic).ToArray();
        }

        if (part.Contains("{"))
        {
          joltageRequirements = part.Trim('{', '}').Split(',').Select(s => int.Parse(s)).ToArray();
        }
      }
      var machine = new Machine(initialLightDiagram, desiredLightDiagram, buttonWiringSchematics, joltageRequirements);
      machines.Add(machine);
    }
    return machines;
  }

  public void PrintMachines()
  {
    foreach (var machine in _machineList)
    {
      Console.WriteLine("Machine Details:");
      Console.WriteLine($"  Initial Light Diagram: {machine.InitialLightDiagram}");
      Console.WriteLine($"  Desired Light Diagram: {machine.DesiredLightDiagram}");
      Console.WriteLine($"  Button Count: {machine.ButtonCount}"); 
      Console.WriteLine($"  Button Wiring Schematics:");
      foreach (var buttonWiring in machine.ButtonWiringSchematics)
      {
        Console.WriteLine($"    - {string.Join(", ", buttonWiring)}");
      }
      Console.WriteLine($"  Joltage Requirements: {string.Join(", ", machine.JoltageRequirements)}");
      Console.WriteLine(); // Blank line for better readability between machines

      machine.PressButton(0); // Example: Press the first button
      Console.WriteLine($"  Current Light Diagram after pressing button 0: {machine.CurrentLightDiagram}");
    }
  }
}