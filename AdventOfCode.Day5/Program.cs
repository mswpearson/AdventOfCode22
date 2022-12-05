string inputText = File.ReadAllText("puzzleInput.txt");
var instructions = inputText.Split("\r\n\r\n")[1].Split("\r\n");

var stacks = new Stack<char>[9];

stacks[0] = new Stack<char>();
stacks[0].Push('Z');
stacks[0].Push('J');
stacks[0].Push('N');
stacks[0].Push('W');
stacks[0].Push('P');
stacks[0].Push('S');

stacks[1] = new Stack<char>();
stacks[1].Push('G');
stacks[1].Push('S');
stacks[1].Push('T');

stacks[2] = new Stack<char>();
stacks[2].Push('V');
stacks[2].Push('Q');
stacks[2].Push('R');
stacks[2].Push('L');
stacks[2].Push('H');

stacks[3] = new Stack<char>();
stacks[3].Push('V');
stacks[3].Push('S');
stacks[3].Push('T');
stacks[3].Push('D');

stacks[4] = new Stack<char>();
stacks[4].Push('Q');
stacks[4].Push('Z');
stacks[4].Push('T');
stacks[4].Push('D');
stacks[4].Push('B');
stacks[4].Push('M');
stacks[4].Push('J');

stacks[5] = new Stack<char>();
stacks[5].Push('M');
stacks[5].Push('W');
stacks[5].Push('T');
stacks[5].Push('J');
stacks[5].Push('D');
stacks[5].Push('C');
stacks[5].Push('Z');
stacks[5].Push('L');

stacks[6] = new Stack<char>();
stacks[6].Push('L');
stacks[6].Push('P');
stacks[6].Push('M');
stacks[6].Push('W');
stacks[6].Push('G');
stacks[6].Push('T');
stacks[6].Push('J');

stacks[7] = new Stack<char>();
stacks[7].Push('N');
stacks[7].Push('G');
stacks[7].Push('M');
stacks[7].Push('T');
stacks[7].Push('B');
stacks[7].Push('F');
stacks[7].Push('Q');
stacks[7].Push('H');

stacks[8] = new Stack<char>();
stacks[8].Push('R');
stacks[8].Push('D');
stacks[8].Push('G');
stacks[8].Push('C');
stacks[8].Push('P');
stacks[8].Push('B');
stacks[8].Push('Q');
stacks[8].Push('W');

foreach (var instruction in instructions)
{
    var splitInstruction = instruction.Split(" ");
    int quantity = int.Parse(splitInstruction[1]);
    int from = int.Parse(splitInstruction[3]) - 1;
    int to = int.Parse(splitInstruction[5]) - 1;

    while (quantity > 0)
    {
        var popped = stacks[from].Pop();
        stacks[to].Push(popped);
        quantity -= 1;
    }
}

Console.WriteLine($"{stacks[0].Peek()}{stacks[1].Peek()}{stacks[2].Peek()}{stacks[3].Peek()}{stacks[4].Peek()}{stacks[5].Peek()}{stacks[6].Peek ()}{stacks[7].Peek()}{stacks[8].Peek()}");