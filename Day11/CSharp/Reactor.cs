namespace Day11;

public class Reactor
{
  private string[] _inputLines;
  public Queue<string> InstructionQueue { get; private set; } 
  public HashSet<string> VisitedDevices { get; private set; }
  private string _startInstruction;
  public Dictionary<string, (int index, string[] outputs)> DeviceOutputs { get; private set; }
  
  // Path Counter
  public int PathCounter { get; private set; } 

  public Reactor(string[] inputLines)
  {
      _inputLines = inputLines;
      InstructionQueue = new Queue<string>(); // Initialized empty queue
      VisitedDevices = new HashSet<string>(); // Track visited devices
      DeviceOutputs = AddDeviceOutputs();
  }

  public Dictionary<string, (int index, string[] outputs)> AddDeviceOutputs()
  {
    var DeviceOutputDict = new Dictionary<string, (int index, string[] outputs)>();
    for (int i = 0; i < _inputLines.Length; i++)
    {
      var deviceName = _inputLines[i].Split(':')[0];
      var outputs = _inputLines[i].Split(':')[1].Trim().Split(' ');
      if (!DeviceOutputDict.ContainsKey(deviceName))
      {
        if (deviceName == "you") // Find starting device and enqueue its instruction
        {
          _startInstruction = deviceName;
          EnqueueInstructions(_startInstruction);
        }
        DeviceOutputDict.Add(deviceName, (i, outputs)); // Add device with index and outputs to dictionary
      }
      DeviceOutputDict[deviceName] = (i, outputs); // Update device outputs
    }
    return DeviceOutputDict;
  }

  public void EnqueueInstructions(string instruction) => InstructionQueue.Enqueue(instruction);

  public void FindNextDevice()
  {
    while (InstructionQueue.Count > 0)
    {
      var currentDeviceName = InstructionQueue.Dequeue();
      var currentDictIndex = DeviceOutputs[currentDeviceName].index;
      var outputs = DeviceOutputs[currentDeviceName].outputs;
      VisitedDevices.Add(currentDeviceName);

      foreach (var output in outputs)
      {
        if (!VisitedDevices.Contains(output) && output != "out")
        {
          EnqueueInstructions(output);
        }
        
        if (output == "out")
        {
          PathCounter++;
        }
      }
    }
  }

  public void PrintInputLines()
  {
      foreach (var line in _inputLines)
      {
          Console.WriteLine(line);
      }
  }

  public void PrintDeviceOutputs()
  {
    foreach (var kvp in DeviceOutputs)
    {
      Console.WriteLine($"Device: {kvp.Key}");
      Console.WriteLine($"  Outputs: {string.Join(", ", kvp.Value)}\n");
    }
  }

  public void PrintQueue()
  {
    Console.WriteLine("Instruction Queue:");
    foreach (var instruction in InstructionQueue)
    {
      Console.WriteLine(instruction);
    }
  }
}