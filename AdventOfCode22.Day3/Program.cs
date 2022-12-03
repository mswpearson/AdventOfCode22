string inputText = File.ReadAllText("puzzleInput.txt");
var bags = inputText.Split("\r\n");
var bagGroups = bags.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 3)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();

var total = bagGroups.Sum(bagGroup => GetGroupTotal(bagGroup));

Console.WriteLine(total);

int GetGroupTotal(IEnumerable<string> group)
{
    char duplicateChar = 'A';
    foreach(char @char in group.ElementAt(0))
    {
        if (group.ElementAt(1).Contains(@char) && group.ElementAt(2).Contains(@char))
        {
            duplicateChar = @char;
            break;
        }
    }

    int charVal;
    if (char.IsUpper(duplicateChar)) 
    {
        charVal = duplicateChar - 38;
    }
    else
    {
        charVal = duplicateChar - 96;
    }
    return charVal;
}