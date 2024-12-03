using System.Text.RegularExpressions;

var input = File.ReadAllText("./input.txt");



Regex regex = new Regex(@"mul\((\d+),(\d+)\)");

Regex removeDont = new Regex(@"don't\(\).+?do\(\)");


var a = regex.Matches(input);


int result = 0;
foreach (Match match in a)
{
    result += (int.Parse(match.Groups[1].ToString()) * int.Parse(match.Groups[2].ToString()));
}

Console.WriteLine(result);