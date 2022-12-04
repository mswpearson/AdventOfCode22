using System.Text;

string inputText = File.ReadAllText("puzzleInput.txt");

var pairs = inputText.Split("\r\n");
var expandedPairs = pairs.Select(pair => (GetExpandedAssignments(pair.Split(',')[0]), GetExpandedAssignments(pair.Split(',')[1])));

Console.WriteLine(expandedPairs.Count(ep => DoesOneAssignmentContainTheOther(ep)));

IEnumerable<int> GetExpandedAssignments(string assingment)
{
    var startAndEnd = assingment.Split('-');
    int start = int.Parse(startAndEnd[0]);
    int end = int.Parse(startAndEnd[1]);

    var expandedAssignment = new List<int>();
    for (int i = start; i <= end; i++)
    {
        expandedAssignment.Add(i);
    }
    return expandedAssignment;
}

bool DoesOneAssignmentContainTheOther((IEnumerable<int>, IEnumerable<int>) expandedAssignments)
{
    return expandedAssignments.Item1.Any(ea => expandedAssignments.Item2.Contains(ea));
}