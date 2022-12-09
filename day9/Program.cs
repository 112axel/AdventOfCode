using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode
{
    public class Point
    {

        public int X;
        public int Y;



        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    public class RopePart
    {
        public Point PointXY = new Point(0, 0);
        public List<(int, int)> PosHistory = new List<(int, int)>();


        public void MoveRelative(Point tail)
        {
            if (Math.Abs(tail.X - PointXY.X) > 1 || Math.Abs(tail.Y - PointXY.Y) > 1)
            {
                int xDif = tail.X - PointXY.X;
                int yDif = tail.Y - PointXY.Y;

                if (xDif == 0)
                {
                    PointXY.Y += 1 * yDif > 0 ? 1 : -1;
                }
                else if (yDif == 0)
                {
                    PointXY.X += 1 * xDif > 0 ? 1 : -1;
                }
                else
                {
                    PointXY.X += 1 * xDif > 0 ? 1 : -1;
                    PointXY.Y += 1 * yDif > 0 ? 1 : -1;

                }


            }
            if (!PosHistory.Contains((PointXY.X, PointXY.Y)))
            {
                PosHistory.Add((PointXY.X, PointXY.Y));
            }
        }
    }


    public class Rope
    {
        public List<RopePart> ropeParts = new List<RopePart>();
        public Rope(int ropeLen)
        {
            for(int i = 0; i<ropeLen; i++)
            {
                ropeParts.Add(new RopePart());
            }
        }

        public void MoveRope(string direction, int length)
        {
            Point HeadPoint = ropeParts[0].PointXY;
            for (int i = 0; i < length; i++)
            {
                if (direction == "R")
                {
                    HeadPoint.X++;
                }
                else if (direction == "L")
                {
                    HeadPoint.X--;
                }
                else if (direction == "U")
                {
                    HeadPoint.Y++;
                }
                else if (direction == "D")
                {
                    HeadPoint.Y--;
                }

                for(int j = 1; j < ropeParts.Count(); j++)
                {
                    ropeParts[j].MoveRelative(ropeParts[j - 1].PointXY);
                }
            }
        }
    }






    public class Program
    {
        public static string[] readFromFile()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day9\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = readFromFile();
            Rope rope = new Rope(10);

            foreach (string line in input)
            {
                var splitLine = line.Split(' ');
                rope.MoveRope(splitLine[0], int.Parse(splitLine[1]));
            }


        }
    }
}
