//
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.IO;
//
//var input = await File.ReadAllTextAsync(@"C:\Users\axelc\source\repos\AdventOfCode\day11\input.txt");
//
//for (var part = 1; part <= 2; part++)
//{
//    var monkeys = input.Split("\r\n\r\n").Select(m => new Monkey(m)).ToArray();
//    var superModulo = monkeys.Aggregate(1, (current, monkey) => current * monkey.Test);
//    var rounds = part == 1 ? 20 : 10_000;
//    for (var i = 0; i < rounds; i++)
//    {
//        foreach (var monkey in monkeys)
//        {
//            while (monkey.Items.Count > 0)
//            {
//                var item = monkey.Items.Dequeue();
//                var worry = part == 1 ? monkey.EvaluateOperation(item) / 3 : monkey.EvaluateOperation(item) % superModulo;
//                var receiverIndex = worry % monkey.Test == 0 ? monkey.TestPassing : monkey.TestNotPassing;
//                monkeys[receiverIndex].Items.Enqueue(worry);
//                monkey.ProcessedItems++;
//            }
//        }
//    }
//    var topMonkeys = monkeys.OrderByDescending(m => m.ProcessedItems).Take(2).ToArray();
//    Console.WriteLine($"Part {part}: {topMonkeys[0].ProcessedItems * topMonkeys[1].ProcessedItems}");
//}
//
//class Monkey
//{
//    public Monkey(string input)
//    {
//        var lines = input.Split("\r\n");
//        lines[1].Replace("  Starting items: ", string.Empty).Replace(" ", string.Empty).Split(',').Select(long.Parse).ToList().ForEach(Items.Enqueue);
//        Operation = lines[2].Replace("  Operation: new = old ", string.Empty);
//        Test = int.Parse(lines[3].Replace("  Test: divisible by ", string.Empty));
//        TestPassing = int.Parse(lines[4].Replace("    If true: throw to monkey ", string.Empty));
//        TestNotPassing = int.Parse(lines[5].Replace("    If false: throw to monkey ", string.Empty));
//    }
//    public Queue<long> Items { get; set; } = new();
//    public string Operation { get; set; }
//    public int Test { get; set; }
//    public int TestPassing { get; set; }
//    public int TestNotPassing { get; set; }
//    public long ProcessedItems { get; set; }
//    public long EvaluateOperation(long item)
//    {
//        var op = Operation.Split(' ');
//        if (!long.TryParse(op[1], out var val)) { val = item; }
//        return op[0] == "*" ? val * item : val + item;
//    }
//}
//
//






using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode
{
    public enum OperationEnum
    {
        Add,
        Multiply,
        Square
    }
    public class Monkey
    {
        public Monkey() { }

        public Queue<int> ItemQueue = new Queue<int>();
        public OperationEnum Operation;
        public int OperationNumber;

        public int TestDivision;
        public Monkey True;
        public Monkey False;

        public int InspectCount = 0;


        public int Inspect()
        {
            InspectCount++;
            return (int)(Math.Floor(CalculateOperation(ItemQueue.Dequeue()) / 3.0));
        }

        public int CalculateOperation(int inputNumber) => Operation switch
        {
            OperationEnum.Add => inputNumber + OperationNumber,
            OperationEnum.Multiply => inputNumber * OperationNumber,
            OperationEnum.Square => inputNumber * inputNumber,
            _ => throw new InvalidOperationException()
        };
        public void MoveBaseOnDiv(int inputNumber)
        {
            if (inputNumber % TestDivision == 0)
            {
                True.ItemQueue.Enqueue(inputNumber);
            }
            else
            {
                False.ItemQueue.Enqueue(inputNumber);
            }
        }
    }
    public class Program
    {
        public static string[] readFromFile()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day11\input.txt");
        }

        public static void Main()
        {

            List<Monkey> monkeys = new List<Monkey>();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            for (int i = 0; i < (input.Length + 1) / 7; i++)
            {
                monkeys.Add(new Monkey());
            }

            for (int offset = 0; offset < input.Length; offset += 7)
            {
                var currentMonkey = monkeys[offset / 7];
                currentMonkey.Operation = input[offset + 2].Contains("*") ? input[offset + 2].Split(' ').Last() == "old" ? OperationEnum.Square : OperationEnum.Multiply : OperationEnum.Add;
                try
                {

                    currentMonkey.OperationNumber = int.Parse(input[offset + 2].Split(' ').Last());
                }
                catch
                {
                    currentMonkey.OperationNumber = 0;
                }
                currentMonkey.TestDivision = int.Parse(input[offset + 3].Split(' ').Last());
                currentMonkey.True = monkeys[int.Parse(input[offset + 4].Split(' ').Last())];
                currentMonkey.False = monkeys[int.Parse(input[offset + 5].Split(' ').Last())];

                foreach (string a in input[offset + 1].Split(':')[1].Split(','))
                {
                    currentMonkey.ItemQueue.Enqueue(int.Parse(a));
                }


            }

            //Main part

            int rounds = 20;
            for (int round = 0; round < rounds; round++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    while (monkey.ItemQueue.Count() > 0)
                    {
                        var a = monkey.Inspect();
                        monkey.MoveBaseOnDiv(a);
                    }
                }
            }
            var c = monkeys.OrderByDescending(m => m.InspectCount).Take(2).ToArray();
            Console.WriteLine(c[0].InspectCount * c[1].InspectCount);
        }
    }
}
