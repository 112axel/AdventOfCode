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
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day2\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            Console.WriteLine("Hello!");

        }
    }
}
