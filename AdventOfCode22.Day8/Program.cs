string inputText = File.ReadAllText("puzzleInput.txt");

var rows = inputText.Split("\r\n").Select(row => row.ToCharArray().Select(@char => int.Parse(@char.ToString())).ToArray()).ToArray();

var visibleTrees = 0;

for (int row=0; row < rows.Length; row++)
{
    for (int column = 0; column < rows[row].Length; column++)
    {
        if (IsVisible(rows[row][column], row, column)) visibleTrees ++;
    }
}

Console.WriteLine(visibleTrees);

bool IsVisible(int treeHeight, int row, int col)
{
    // visible from left
    var toTheLeft = rows[row].Take(col);
    if (toTheLeft.All(tree => tree < treeHeight)) return true;

    // visible from right
    var toTheRight = rows[row].Skip(col+1);
    if (toTheRight.All(tree => tree < treeHeight)) return true;

    // visible from top
    var column = rows.Select(row => row[col]);
    var above = column.Take(row);
    if (above.All(tree => tree < treeHeight)) return true;

    // visible from bottom
    var below = column.Skip(row+1);
    if (below.All(tree => tree < treeHeight)) return true;

    return false;
}