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
    if (rows[row].Take(row).All(tree => tree < treeHeight)) return true;

    // visible from right
    if (rows[row].Skip(row).All(tree => tree < treeHeight)) return true;

    // visible from top
    var column = rows.Select(row => row[col]);
    if (rows[row].Take(row).All(tree => tree < treeHeight)) return true;

    // visible from bottom
    if (rows[row].Skip(row).All(tree => tree < treeHeight)) return true;

    return false;
}

//1826