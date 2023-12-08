using System.Text.RegularExpressions;

var input = File.ReadAllLines("./input.txt");

Regex numberFinder = new Regex(@"\d+");

var times = numberFinder.Matches(input[0]).Select(x=>int.Parse( x.Value)).ToList();
var dist = numberFinder.Matches(input[1]).Select(x=>int.Parse( x.Value)).ToList();

var longTime = int.Parse(times.Select(x => x.ToString()).Aggregate("",(current,s)=>current+s));
var longDist = long.Parse(dist.Select(x => x.ToString()).Aggregate("",(current,s)=>current+s));

var result = 1;

for(int i = 0; i < times.Count; i++)
{
    var timesToTest = Enumerable.Range(0, times[i]);
    var res = timesToTest.Count(x => LongerThanRecord(dist[i], x, times[i]));
    Console.WriteLine(res);
    result = result * res;
}

Console.WriteLine(result);

var timesToTest2 = Enumerable.Range(0, longTime);
long res2 = timesToTest2.LongCount(x => LongerThanRecord(longDist, x, longTime));
Console.WriteLine(res2);
bool LongerThanRecord(long record, long time, long maxtime)
{
    long totalDist = time * (maxtime - time);
    return totalDist > record;
}
