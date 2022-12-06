string inputText = File.ReadAllText("puzzleInput.txt");
var chars = inputText.ToCharArray();
var charQueue = new Queue<char>();

for (int i = 0; i < chars.Length; i++)
{
    charQueue.Enqueue(chars[i]);
    if (charQueue.Count() == 5)
    {
        charQueue.Dequeue();
        if (charQueue.Distinct().Count() == 4)
        {
            Console.WriteLine(i+1);
            break;
        }
    }
}