using System.Text.RegularExpressions;

var input = File.ReadAllLines("./input.txt");

var fullLine = string.Concat(input);


Regex regex = new Regex(@"mul\((\d+),(\d+)\)");

Regex removeDont = new Regex(@"don't\(\).+?(?:do\(\)|$)");


var b = removeDont.Replace(fullLine,"");

var a = regex.Matches(b);


int result = 0;
foreach (Match match in a)
{
    result += (int.Parse(match.Groups[1].ToString()) * int.Parse(match.Groups[2].ToString()));
}

Console.WriteLine(result);