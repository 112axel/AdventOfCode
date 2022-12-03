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
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day2\input.txt");
        }


        public static int SignToNumber(char inChar)
        {
            switch(inChar)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
            }
            return 0;



        }
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();


            int score = 0;
            int score2 = 0;

            foreach (string s in input)
            {

                char oponentMove = s[0];
                char myMove = s[2] == 'X' ? 'A' : s[2] == 'Y' ? 'B' : 'C';
                char wantedOutcome = s[2];


                if (oponentMove == myMove)
                {
                    score += 3;
                }
                else if ((myMove == 'A' && oponentMove == 'C') || (myMove == 'B' && oponentMove == 'A') || (myMove == 'C' && oponentMove == 'B'))
                {
                    score += 6;
                }

                score += SignToNumber(myMove);


                if (wantedOutcome == 'Y')
                {
                    myMove = oponentMove;
                    score2 += 3;

                }
                else if (wantedOutcome == 'X')
                {
                    myMove = oponentMove == 'A' ? 'C' : oponentMove == 'B' ? 'A' : 'B';
                }
                else if (wantedOutcome == 'Z')
                {
                    myMove = oponentMove == 'A' ? 'B' : oponentMove == 'B' ? 'C' : 'A';
                    score2 += 6;


                }





                score2 += SignToNumber(myMove);





            }

            Console.WriteLine(score);

            Console.WriteLine(score2);
        }

    }
}
