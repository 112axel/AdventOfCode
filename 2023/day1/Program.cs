using System.Text.RegularExpressions;

var input = File.ReadAllLines("./input.txt");

var sum = 0;

string[] strings = {"zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

foreach (var line in input)
{
    var matches = Regex.Matches(line, @"(?=(\d|one|two|three|four|five|six|seven|eight|nine))").Select(x => x.Groups[1].Value);
    var filterLine = "";

    filterLine = String.Concat(matches.Select(match => match.Length != 1? Array.IndexOf(strings, match).ToString():match.ToString()));


    var first = filterLine.First(x => char.IsDigit(x));
    var last = filterLine.Last(x => char.IsDigit(x));
    var combined = first.ToString()+ last.ToString();
    Console.WriteLine($"combined {combined}");
    sum += int.Parse(combined);
}
Console.WriteLine(sum.ToString());





//foreach (var line in input)
//{
//    var first = line.First(x => char.IsDigit(x));
//    var last = line.Last(x => char.IsDigit(x));
//    var combined = first.ToString()+ last.ToString();
//    Console.WriteLine($"combined {combined}");
//    sum += int.Parse(combined);
//}
//Console.WriteLine(sum.ToString());
