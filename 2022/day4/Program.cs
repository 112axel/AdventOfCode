using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode
{
    public class Program
    {
        public static string[] readFromFile(){
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day4\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            int part1Count = 0;
            int part2Count = 0;


            foreach(string line in input){

                var sets = line.Split(',');

                var set1 = sets[0].Split('-');
                var set2 = sets[1].Split('-');


                var numberSet1 = Enumerable.Range(int.Parse(set1[0]),int.Parse(set1[1])-int.Parse(set1[0])+1).ToList();
                var numberSet2 = Enumerable.Range(int.Parse(set2[0]),int.Parse(set2[1])-int.Parse(set2[0])+1).ToList();



                if(numberSet1.Union(numberSet2).Sum() == numberSet1.Sum() || numberSet2.Union(numberSet1).Sum() == numberSet2.Sum()){


                    part1Count++;
                    Console.WriteLine(line);

                }

                if(numberSet1.Intersect(numberSet2).Count()!=0){

                    part2Count++;


                }



            }
            Console.WriteLine($"Part 1 Result = {part1Count} Part 2 result = {part2Count}");
        }
    }
}
