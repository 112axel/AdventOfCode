using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace AdventOfCode
{
    public class Program
    {
        public static string[] readFromFile()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day8\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            List<List<int>> grid = new List<List<int>>();
            List<int> scores = new List<int>();

            foreach (string line in input)
            {
                var newList = new List<int>();
                grid.Add(newList);

                foreach (char numChar in line)
                {
                    newList.Add(int.Parse(numChar.ToString()));
                }
            }
            int awnser = 0;
            for (int y = 0; y < grid.Count(); y++)
            {
                for (int x = 0; x < grid[y].Count(); x++)
                {
                    scores.Add(CalculateScenicScore(grid, x, y));
                    if (CheckRow(grid, y, x) || CheckColumn(grid, x, y))
                    {
                        awnser += 1;
                    }
                }
            }
            Console.WriteLine(awnser);
            Console.WriteLine(scores.Max());
        }

        public static bool CheckRow(List<List<int>> grid, int row, int index)
        {
            int maxNum = -1;
            for (int i = 0; i < index; i++)
            {
                if (grid[row][i] > maxNum)
                {
                    maxNum = grid[row][i];
                }

            }
            if (grid[row][index] > maxNum)
            {
                return true;
            }

            maxNum = grid[row][index];

            for (int i = index + 1; i < grid[0].Count(); i++)
            {
                if (grid[row][i] >= maxNum)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckColumn(List<List<int>> grid, int column, int index)
        {
            int maxNum = -1;
            for (int i = 0; i < index; i++)
            {
                if (grid[i][column] > maxNum)
                {
                    maxNum = grid[i][column];
                }

            }
            if (grid[index][column] > maxNum)
            {
                return true;
            }

            maxNum = grid[index][column];

            for (int i = index + 1; i < grid[0].Count(); i++)
            {
                if (grid[i][column] >= maxNum)
                {
                    return false;
                }
            }
            return true;

        }

        public static int CalculateScenicScore(List<List<int>> grid, int x, int y)
        {
            int up = 0;
            int left = 0;
            int down = 0;
            int right = 0;

            int add = 1;


            // up 
            try
            {
                while (grid[y][x] > grid[y + add][x])
                {
                    up++;
                    add++;
                }
                    up++;
            }
            catch
            {

            }
            //Down
            add = 1;
            try
            {
                while (grid[y][x] > grid[y - add][x])
                {
                    down++;
                    add++;
                }
                    down++;
            }
            catch
            {
            }
            //Left
            add = 1;
            try
            {
                while (grid[y][x] > grid[y][x - add])
                {
                    left++;
                    add++;
                }
                    left++;
            }
            catch
            {
            }
            //Right
            add = 1;
            try
            {
                while (grid[y][x] > grid[y][x + add])
                {
                    right++;
                    add++;
                }
                    right++;
            }
            catch
            {
            }

            return up * left * down * right;
        }
    }
}
