string inputText = File.ReadAllText("puzzleInput.txt");
string[] instructions = inputText.Split("\r\n");

int cycle = 0;
int X = 1;

var signalStrengthsCollector = new List<int>();

foreach(var instruction in instructions)
{
    ExecuteInstruction(instruction);
}

void ExecuteInstruction(string instruction)
{
    if (instruction == "noop")
    {
        cycle += 1;
        CollectIfNeed();
    }
    else
    {
        cycle += 1;
        CollectIfNeed();
        cycle += 1;
        CollectIfNeed();
        X += int.Parse(instruction.Split(' ')[1]);
    }
}

void CollectIfNeed()
{
    if (new int[] { 20, 60, 100, 140, 180, 220 }.Contains(cycle))
    {
        signalStrengthsCollector.Add(cycle * X);
    }
}

Console.WriteLine(signalStrengthsCollector.Sum());