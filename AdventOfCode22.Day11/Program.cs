using AdventOfCode22.Day11;

string inputText = File.ReadAllText("puzzleInput.txt");
string[] monkeyInputs = inputText.Split("Monkey ");

Monkey[] monkeys = monkeyInputs.Where(mi => !string.IsNullOrWhiteSpace(mi)).Select(mi => new Monkey(mi)).ToArray();

int rounds = 20;

for (int round = 0; round < rounds; round++)
{
    foreach (var monkey in monkeys)
    {
        while (monkey.Items.Any())
        {
            var item = monkey.InspectNext();
            monkeys[item.newMonkeyIndex].Items.Enqueue(item.worryLevel);
        }
    }
}

var top2 = monkeys.Select(m => m.ItemsInspected).OrderByDescending(ii => ii).Take(2).ToArray();
Console.WriteLine(top2[0] * top2[1]);