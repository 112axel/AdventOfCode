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
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day10\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();

            var valueList = new List<int> { 1 };
            int x = 1;
            foreach (string line in input)
            {
                var splitString = line.Split(' ');
                if (splitString[0] == "noop")
                {
                    valueList.Add(x);
                }
                else if (splitString[0] == "addx")
                {
                    valueList.Add(x);
                    x += int.Parse(splitString[1]);
                    valueList.Add(x);
                }
            }


            int[] toUseForResult = new int[] { 20, 60, 100, 140, 180, 220 };
            int output1 = 0;
            foreach (int number in toUseForResult)
            {
                output1 += valueList[number - 1] * number;
                Console.WriteLine(valueList[number - 1] * number);
            }
            Console.WriteLine(output1);



            int rowLen = 40;
            int rows = 6;
            int currentIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                for(int j = 0; j < rowLen; j++)
                {
                    if (Math.Abs(valueList[currentIndex]-j)<=1)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                    currentIndex++;

                }

                Console.WriteLine();
            }

        }
    }
}
