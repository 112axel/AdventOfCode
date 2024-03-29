﻿using System.Text.RegularExpressions;

var input = File.ReadAllLines("./input.txt");

List<Point> specialTiles = new();
Regex isSpecial = new Regex(@"[^\d. \n]");
Regex isGear= new Regex(@"[*]");
Regex numbers = new Regex(@"\d{1,}");

Dictionary<Point, List<int>> gearPos = new();

for (int line = 0; line < input.Length; line++)
{
    for(int tile = 0; tile < input[line].Length; tile++)
    {
        var symbol = input[line][tile].ToString();
        if (isSpecial.IsMatch(symbol))
        {
            specialTiles.Add(new (tile, line));
        }
        if (isGear.IsMatch(symbol))
        {
            gearPos.Add(new(tile, line),new List<int>());
        }
    }
}
int total = 0;
for (int line = 0; line < input.Length; line++)
{
    var matches = numbers.Matches(input[line]);
    var temp = matches.Where(match => IsClose(specialTiles, match, line, gearPos)).ToList();
    total += temp.Sum(x => int.Parse(x.Value));

}

Console.WriteLine(total);
Console.WriteLine(gearPos.Where(x=>x.Value.Count == 2).Select(x => x.Value[0] * x.Value[1]).Sum());
bool IsClose(List<Point> points, Match match, int line,Dictionary<Point,List<int>> gears)
{
    var xRange = Enumerable.Range(match.Index - 1,  match.Length + 2);
    var yRange = Enumerable.Range(line - 1, 3);
    foreach (var yNum in yRange)
    {
        foreach (var xNum in xRange)
        {
            if(points.Any(a=>a.x == xNum && a.y == yNum))
            {
                if(gearPos.ContainsKey(new Point(xNum, yNum)))
                {
                    gearPos[new Point(xNum, yNum)].Add(int.Parse(match.Value));
                }
                return true;
            }
        }

    }

    return false;
}


List<Point> PointsAround(int x, int y)
{
    List<Point> output = new();
    for (int xloop = -1; xloop <= 1; xloop++)
    {
        for (int yloop = -1; yloop <= 1; yloop++)
        {
            output.Add(new Point(x + xloop, y + yloop));
        }
    }
    return output;
}
public record Point(int x, int y);