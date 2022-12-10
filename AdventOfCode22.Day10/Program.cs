string inputText = File.ReadAllText("puzzleInput.txt");
string[] instructions = inputText.Split("\r\n");

int cycle = 0;
int X = 1;

var rows = new string[][]
{
    Enumerable.Repeat(" ", 40).ToArray(),
    Enumerable.Repeat(" ", 40).ToArray(),
    Enumerable.Repeat(" ", 40).ToArray(),
    Enumerable.Repeat(" ", 40).ToArray(),
    Enumerable.Repeat(" ", 40).ToArray(),
    Enumerable.Repeat(" ", 40).ToArray()
};


foreach(var instruction in instructions)
{
    ExecuteInstruction(instruction);
}

void ExecuteInstruction(string instruction)
{
    if (instruction == "noop")
    {
        cycle += 1;
        DrawPixel();
    }
    else
    {
        cycle += 1;
        DrawPixel();
        cycle += 1;
        DrawPixel();
        X += int.Parse(instruction.Split(' ')[1]);
    }
}

void DrawPixel()
{
    int rowIndex = -1;
    if (cycle <= 40) rowIndex = 0;
    else if (cycle <= 80) rowIndex = 1;
    else if (cycle <= 120) rowIndex = 2;
    else if (cycle <= 160) rowIndex = 3;
    else if (cycle <= 200) rowIndex = 4;
    else if (cycle <= 240) rowIndex = 5;

    var spritePos = GetSpritePosition();
    var horizontalPos = cycle - (rowIndex * 40) - 1;
    rows[rowIndex][horizontalPos] = spritePos.Contains(horizontalPos) ? "#" : ".";
}

int[] GetSpritePosition()
{
    return new int[] { X-1, X, X+1 };
}

foreach (var row in rows)
{
    Console.WriteLine(string.Join("", row));
}