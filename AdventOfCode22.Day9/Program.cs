string inputText = File.ReadAllText("puzzleInput.txt");
string[] instructions = inputText.Split("\r\n");

var positionsCoveredByT = new List<(int x, int y)>();

// Part 1
//var rope = Enumerable.Repeat<(int x, int y)>((0, 0), 2).ToArray();

// Part 2
// If using the visualiser function, set the initial values to something like (25,25) so that it doesn't go out of bounds
var rope = Enumerable.Repeat<(int x, int y)>((0, 0), 10).ToArray();

foreach (var instruction in instructions)
{
    var splitInstruction = instruction.Split(' ');
    var direction = splitInstruction[0];
    var distance = int.Parse(splitInstruction[1]);

    for (int i=0; i < distance; i++)
    {
        MoveHead(direction);

        for (int position=1; position < rope.Length; position++)
        {
            Follow(position);
        }

        positionsCoveredByT.Add(rope[rope.Length - 1]);
    }
}

Console.WriteLine(positionsCoveredByT.Distinct().Count());

void MoveHead(string direction)
{
    switch (direction)
    {
        case "U":
            rope[0].y += 1;
            break;
        case "D":
            rope[0].y -= 1;
            break;
        case "L":
            rope[0].x -= 1;
            break;
        case "R":
            rope[0].x += 1;
            break;
    }
}

void Follow(int followerIndex)
{
    ref var toFollow = ref rope[followerIndex - 1];
    ref var follower = ref rope[followerIndex];

    if (!IsTouching(follower, toFollow))
    {
        string direction = "";
        if (toFollow.x > follower.x) direction += "R";
        else if (toFollow.x < follower.x) direction += "L";
        if (toFollow.y > follower.y) direction += "U";
        else if (toFollow.y < follower.y) direction += "D";

        switch (direction)
        {
            case "R":
                follower.x += 1;
                break;
            case "L":
                follower.x -= 1;
                break;
            case "U":
                follower.y += 1;
                break;
            case "D":
                follower.y -= 1;
                break;
            case "RU":
                follower.x += 1;
                follower.y += 1;
                break;
            case "RD":
                follower.x += 1;
                follower.y -= 1;
                break;
            case "LU":
                follower.x -= 1;
                follower.y += 1;
                break;
            case "LD":
                follower.x -= 1;
                follower.y -= 1;
                break;
            default:
                throw new Exception();
        }
    }
}

bool IsTouching((int x, int y) @this, (int x, int y) that)
{
    var touchingPositions = new List<(int x, int y)>
    {
        (that.x - 1, that.y + 1),
        (that.x, that.y + 1),
        (that.x + 1, that.y + 1),
        (that.x - 1, that.y),
        that,
        (that.x + 1, that.y),
        (that.x - 1, that.y - 1),
        (that.x, that.y - 1),
        (that.x + 1, that.y - 1)
    };

    return touchingPositions.Contains(@this);
}

// You can call this at various times through the solve to display the rope in a rudimentary manner
// Can end up throwing out of bounds very easily
void DrawPositions(string instruction)
{
    var line = Enumerable.Repeat(" ", 50).Select(cell => " ").ToArray();
    var grid = Enumerable.Repeat(line.ToArray(), 50).Select(line => line.Clone() as string[]).ToArray();

    int positionIndex = 0;
    foreach (var position in rope)
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