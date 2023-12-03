var input = File.ReadAllLines("./input.txt");

var rounds = new List<Game>();
foreach(var line in input)
{

    var gameSplit = line.Split(":");
    var stringNum = gameSplit[0].Substring(4);
    var id = int.Parse(stringNum);

    var currentRound = new Game { Id = id };
    foreach(var set in gameSplit[1].Split(";"))
    {
        Dictionary<string, int> sums = new() { { "red", 0 }, { "blue", 0 }, { "green", 0 } };
        foreach (var keyValue in set.Split(","))
        {
            var values = keyValue.TrimStart().Split(" ");
            sums[values[1]] += int.Parse(values[0]);
        }
        if(currentRound.RedMax < sums["red"])
        {
            currentRound.RedMax = sums["red"];
        }
        if(currentRound.BlueMax < sums["blue"])
        {
            currentRound.BlueMax = sums["blue"];
        }
        if (currentRound.GreenMax < sums["green"])
        {
            currentRound.GreenMax = sums["green"];
        }
    }

    rounds.Add(currentRound);


}
var intrestingRounds = rounds.Where(round => round.RedMax <= 12 && round.BlueMax <= 14 && round.GreenMax <= 13);

var sum = intrestingRounds.Sum(x => x.Id);

var powerSum = rounds.Sum(x => x.Power);
Console.WriteLine(sum);
Console.WriteLine(powerSum);




public class Game
{
    public int Id { get; set; }
    public int RedMax { get; set; } = 0;
    public int BlueMax { get; set; } = 0;
    public int GreenMax { get; set; } = 0;
    public int Power { get { return RedMax * BlueMax * GreenMax; } }


}
