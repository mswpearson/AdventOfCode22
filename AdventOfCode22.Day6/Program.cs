string inputText = File.ReadAllText("puzzleInput.txt");
var chars = inputText.ToCharArray();
var charQueue = new Queue<char>();

for (int i = 0; i < chars.Length; i++)
{
    charQueue.Enqueue(chars[i]);
    if (charQueue.Count() == 15)
    {
        charQueue.Dequeue();
        if (charQueue.Distinct().Count() == 14)
        {
            Console.WriteLine(i+1);
            break;
        }
    }
}