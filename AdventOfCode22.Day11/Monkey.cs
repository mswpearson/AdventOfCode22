namespace AdventOfCode22.Day11
{
    public class Monkey
    {
        private readonly string Operator;
        private readonly string LeftOfOperator;
        private readonly string RightOfOperator;
        private readonly int DivisibleBy;
        private readonly int TrueMonkeyIndex;
        private readonly int FalseMonkeyIndex;

        public int ItemsInspected { get; set; }

        public Queue<int> Items { get; set; } = new Queue<int>();

        public Monkey(string monkeyInput)
        {
            var splitInput = monkeyInput.Split("\r\n");

            var splitStartingItems = splitInput[1].Trim().Split(' ');
            for (int i=2; i < splitStartingItems.Length; i++)
            {
                Items.Enqueue(int.Parse(splitStartingItems[i].Split(',')[0]));
            }

            var splitOperation = splitInput[2].Trim().Split(' ');
            LeftOfOperator = splitOperation[3];
            Operator = splitOperation[4];
            RightOfOperator = splitOperation[5];

            var splitTest = splitInput[3].Trim().Split(' ');
            DivisibleBy = int.Parse(splitTest[3]);

            var splitTrue = splitInput[4].Trim().Split(" ");
            TrueMonkeyIndex = int.Parse(splitTrue[5]);

            var splitFalse = splitInput[5].Trim().Split(" ");
            FalseMonkeyIndex = int.Parse(splitFalse[5]);
        }

        public (int newMonkeyIndex, int worryLevel) InspectNext()
        {
            int item = Items.Dequeue();
            item = Operation(item);
            item /= 3;
            var newMonkeyIndex = Test(item);

            ItemsInspected++;

            return (newMonkeyIndex, item);
        }

        private int Operation(int oldWorryLevel)
        {
            var left = LeftOfOperator == "old" ? oldWorryLevel : int.Parse(LeftOfOperator);
            var right = RightOfOperator == "old" ? oldWorryLevel : int.Parse(RightOfOperator);

            if (Operator == "+") return left + right;
            else return left * right;
        }

        private int Test(int worryLevel)
        {
            return worryLevel % DivisibleBy == 0 ? TrueMonkeyIndex : FalseMonkeyIndex;
        }
    }
}
