using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode
{
    public class Program
    {
        public static string[] readFromFile(){
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day6\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            Regex a = new Regex(@"(.)(?!\1)(.)(?!\1|\2)(.)(?!\1|\2|\3).");
            var matches = a.Match(input[0]);
            Console.WriteLine(matches.Index+4);






            //Part 2
            int amountOfDistinct = 14;
            int index = 0;
            while(true){
                try{
                    if(input[0].ToList().GetRange(index,14).Distinct().Count() == amountOfDistinct){
                        Console.WriteLine(new string(input[0].ToList().GetRange(index,14).ToArray()));
                        Console.WriteLine(index+amountOfDistinct);
                    }

                        index++;

                }
                catch{
                    break;


                }


            }
        }
    }
}
