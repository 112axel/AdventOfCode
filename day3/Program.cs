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
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day3\input.txt");
        }
        public static int CharToPrio(char character){
            return character-(char.IsUpper(character)?38:96);


        }
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();


            var prioList = new List<int>();

            foreach(string line in input){
                string part1 = line.Substring(0,line.Length/2);
                string part2 = line.Substring(line.Length/2,line.Length/2);

                foreach(char letter in part1){
                    if(part2.Contains(letter)){
                        prioList.Add(CharToPrio(letter));
                        break;
                    }
                }


            }

            Console.WriteLine($"Result = {prioList.Sum()}");
            //Part2
            int result = 0;
            for(int i = 0; i<input.Length;i+=3){
                var group = input.ToList().GetRange(i,3).ToArray();
                foreach(char letter in group[0]){
                    if(group[1].Contains(letter) && group[2].Contains(letter)){

                        result += CharToPrio(letter);
                        break;


                    }


                }

            } 
            Console.WriteLine(result);

        }
    }
}
