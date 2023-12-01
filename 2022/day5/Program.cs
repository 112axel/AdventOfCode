using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode
{
    public class Program
    {
        public static string[] readFromFile()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day5\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            int separator = input.ToList().IndexOf("");

            int amountOfStacks = (input[separator - 1].Length - 2) / 3;

            Stack<Char> middleTable = new Stack<Char>();


            List<Stack<Char>> stackList = new List<Stack<Char>>();
            for (int i = 0; i < amountOfStacks; i++)
            {
                stackList.Add(new Stack<Char>());
            }

            for (int i = separator - 2; i >= 0; i--)
            {
                Console.WriteLine(input[i]);

                for (int j = 1; j < input[i].Length; j += 4)
                {
                    Console.WriteLine(input[i][j]);

                    if (input[i][j] != ' ')
                    {
                        stackList[(j - 1) / 4].Push(input[i][j]);
                    }

                }
            }
            bool part2 = true;
            foreach (string instruction in input.ToList().GetRange(separator + 1, input.Length - separator - 1))
            {
                var partInstruction = instruction.Split(' ');

                for (int i = 0; i < int.Parse(partInstruction[1]); i++)
                {

                    if (part2)
                    {
                        if (stackList[int.Parse(partInstruction[3]) - 1].Count() > 0)
                        {
                            middleTable.Push(stackList[int.Parse(partInstruction[3]) - 1].Pop());
                        }
                    }
                    else
                    {
                        stackList[int.Parse(partInstruction[5]) - 1].Push(stackList[int.Parse(partInstruction[3]) - 1].Pop());
                    }
                }
                if (part2)
                {
                    while (middleTable.Count() > 0)
                    {

                        stackList[int.Parse(partInstruction[5]) - 1].Push(middleTable.Pop());

                    }
                }
            }


            string output = "";
            foreach (Stack<char> currentStack in stackList)
            {
                if (currentStack.Count > 0)
                {
                    output += currentStack.Peek();
                }
            }

            Console.WriteLine(output);
        }
    }
}
