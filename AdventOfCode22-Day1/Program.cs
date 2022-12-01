using System.Diagnostics;

string inputText = File.ReadAllText("puzzleInput.txt");

var stopwatch = new Stopwatch();
stopwatch.Start();

var splitInput = inputText.Split("\r\n\r\n");

var totalElfCalories = splitInput.Select(input => input.Split("\r\n").Sum(i => int.Parse(i)));

var top3Calories = totalElfCalories.OrderByDescending(calories => calories).Take(3);
var sum = top3Calories.Sum();
stopwatch.Stop();

Console.WriteLine(sum); 
Console.WriteLine(stopwatch.Elapsed);
