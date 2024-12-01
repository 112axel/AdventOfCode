using System.Runtime.ExceptionServices;

var input = File.ReadAllLines("./input.txt");

var output = 0;

var list1 = new List<int>();
var list2 = new List<int>();
foreach (var line in input)
{
    var result = line.Split("   ");
    list1.Add(int.Parse(result[0]));
    list2.Add(int.Parse(result[1]));
}
list1 = list1.Order().ToList();
list2 = list2.Order().ToList();

for(int i = 0;  i < list1.Count; i++)
{
    var diff = Math.Abs(list1[i] - list2[i]);
    output += diff;
} 
Console.WriteLine(output);

var output2 = 0;
//part 2 
for(int i = 0;  i < list1.Count; i++)
{
    var val1 = list1[i];
    var val2 = list2.Count(x=>x == val1);
    output2 += val1 * val2;
}

Console.WriteLine("part2");  
Console.WriteLine(output2);  

