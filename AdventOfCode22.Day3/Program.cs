string inputText = File.ReadAllText("puzzleInput.txt");
var bags = inputText.Split("\r\n");
var compartmentTuples = bags.Select(bag => (bag.Substring(0, bag.Length/2), bag.Substring(bag.Length/2, bag.Length/2)));

var total = compartmentTuples.Sum(compartmentTuple => GetCompartmentTupleTotal(compartmentTuple));

Console.WriteLine(total);

int GetCompartmentTupleTotal((string compartment1, string compartment2) compartmentTuple)
{
    char duplicateChar = 'A';
    foreach(char @char in compartmentTuple.compartment1)
    {
        if (compartmentTuple.compartment2.Contains(@char))
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