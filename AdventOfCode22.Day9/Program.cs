string inputText = File.ReadAllText("puzzleInput.txt");
string[] instructions = inputText.Split("\r\n");

var positionsCoveredByT = new List<(int x, int y)>();

var positions = Enumerable.Repeat<(int x, int y)>((0, 0), 10).ToArray();

foreach (var instruction in instructions)
{
    var splitInstruction = instruction.Split(" ");
    var direction = splitInstruction[0];
    var distance = int.Parse(splitInstruction[1]);

    for (int moved = 0; moved < distance; moved++)
    {
        for (int position = 1; position < positions.Length; position++)
        {
            ref var hPos = ref positions[position - 1];
            ref var tPos = ref positions[position];
            if (position == 1)
            {
                direction = splitInstruction[0];
            }
            switch (direction)
            {
                case "U":
                    if (position == 1) 
                    {
                        hPos = (hPos.x, hPos.y + 1);
                    }
                    if (!TailIsTouching(hPos, tPos))
                    {
                        if (hPos == (tPos.x - 1, tPos.y + 2))
                        {
                            if ((splitInstruction[0] == "U"))
                                direction = "L";
                            tPos = (tPos.x - 1, tPos.y + 1);
                        }
                        else if (hPos == (tPos.x, tPos.y + 2))
                        {
                            tPos = (tPos.x, tPos.y + 1);
                        }
                        else
                        {
                            if ((splitInstruction[0] == "U"))
                                direction = "R";
                            tPos = (tPos.x + 1, tPos.y + 1);
                        }
                    }
                    break;
                case "D":
                    if (position == 1)
                    {
                        hPos = (hPos.x, hPos.y - 1);
                    }
                    if (!TailIsTouching(hPos, tPos))
                    {
                        if (hPos == (tPos.x - 1, tPos.y - 2))
                        {
                            if ((splitInstruction[0] == "D")) 
                                direction = "L";
                            tPos = (tPos.x - 1, tPos.y - 1);
                        }
                        else if (hPos == (tPos.x, tPos.y - 2))
                        {
                            tPos = (tPos.x, tPos.y - 1);
                        }
                        else
                        {
                            tPos = (tPos.x + 1, tPos.y - 1);
                        }
                    }
                    break;
                case "L":
                    if (position == 1)
                    {
                        hPos = (hPos.x - 1, hPos.y);
                    }
                    if (!TailIsTouching(hPos, tPos))
                    {
                        if (hPos == (tPos.x - 2, tPos.y - 1))
                        {
                            if ((splitInstruction[0] == "L")) 
                                direction = "D";
                            tPos = (tPos.x - 1, tPos.y - 1);
                        }
                        else if (hPos == (tPos.x - 2, tPos.y))
                        {
                            tPos = (tPos.x - 1, tPos.y);
                        }
                        else
                        {
                            if ((splitInstruction[0] == "L"))
                                direction = "U";
                            tPos = (tPos.x - 1, tPos.y + 1);
                        }
                    }
                    break;
                case "R":
                    if (position == 1)
                    {
                        hPos = (hPos.x + 1, hPos.y);
                    }
                    if (!TailIsTouching(hPos, tPos))
                    {
                        if (hPos == (tPos.x + 2, tPos.y - 1))
                        {
                            if ((splitInstruction[0] == "R"))
                                direction = "D";
                            tPos = (tPos.x + 1, tPos.y - 1);
                        }
                        else if (hPos == (tPos.x + 2, tPos.y))
                        {
                            tPos = (tPos.x + 1, tPos.y);
                        }
                        else
                        {
                            if ((splitInstruction[0] == "R"))
                                direction = "U";
                            tPos = (tPos.x + 1, tPos.y + 1);
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        DrawPositions(instruction, positions);

        positionsCoveredByT.Add(positions[9]);
    }
}

Console.WriteLine(positionsCoveredByT.Distinct().Count());

bool TailIsTouching((int x, int y) hPos, (int x, int y) tPos)
{
    var touchingPositions = new List<(int x, int y)>
    {
        (tPos.x - 1, tPos.y + 1),
        (tPos.x, tPos.y + 1),
        (tPos.x + 1, tPos.y + 1),
        (tPos.x - 1, tPos.y),
        tPos,
        (tPos.x + 1, tPos.y),
        (tPos.x - 1, tPos.y - 1),
        (tPos.x, tPos.y - 1),
        (tPos.x + 1, tPos.y - 1)
    };

    return touchingPositions.Contains(hPos);
}

void DrawPositions(string instruction, IEnumerable<(int x, int y)> positions)
{
    var line = Enumerable.Repeat(" ", 50).Select(cell => " ").ToArray();
    var grid = Enumerable.Repeat(line.ToArray(), 50).Select(line => line.Clone() as string[]).ToArray();

    int positionIndex = 0;
    foreach (var position in positions)
    {
        if (string.IsNullOrWhiteSpace(grid[position.y][position.x]))
        {
            grid[position.y][position.x] = positionIndex.ToString();
        }
        positionIndex++;
    }

    Console.WriteLine(instruction);
    Console.WriteLine(string.Join("\r\n", grid.Reverse().Select(line => string.Join("", line))));
}