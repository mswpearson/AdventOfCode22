string inputText = File.ReadAllText("puzzleInput.txt");

var rows = inputText.Split("\r\n").Select(row => row.ToCharArray().Select(@char => int.Parse(@char.ToString())).ToArray()).ToArray();

var scenicScores = new List<int>();

for (int row=0; row < rows.Length; row++)
{
    for (int column = 0; column < rows[row].Length; column++)
    {
        scenicScores.Add(GetScenicScore(rows[row][column], row, column));
    }
}

Console.WriteLine(scenicScores.Max());

int GetScenicScore(int treeHeight, int row, int col)
{
    var toTheLeft = rows[row].Take(col);
    var leftVD = GetViewingDistance(treeHeight, toTheLeft.Reverse().ToArray());

    var toTheRight = rows[row].Skip(col+1);
    var rightVD = GetViewingDistance(treeHeight, toTheRight.ToArray());

    var column = rows.Select(row => row[col]);
    var above = column.Take(row);
    var aboveVD = GetViewingDistance(treeHeight, above.Reverse().ToArray());

    var below = column.Skip(row+1);
    var belowVD = GetViewingDistance(treeHeight, below.ToArray());

    return leftVD * rightVD * aboveVD * belowVD;
}

int GetViewingDistance(int treeHeight, int[] treeHeightsLookingFromTree)
{
    var nonBlocking = new List<int>();

    foreach (int tree in treeHeightsLookingFromTree)
    {
        if (tree < treeHeight)
        {
            nonBlocking.Add(tree);
        }
        else
        {
            nonBlocking.Add(tree);
            break;
        }
    }

    return nonBlocking.Count();
}