var input = File.ReadAllLines("./input.txt");


var result = 0;
foreach (var line in input)
{
    var numLine = line.Split(' ').Select(int.Parse);
    if (IsValid(numLine.ToList()))
    {
        result++;
    }
}


Console.WriteLine(result);

bool IsValid(List<int> ints)
{
    int lastNum = ints.First();
    int lastDiff = 0;
    bool first = true;
    foreach(var num in ints.Skip(1))
    {
        var currentJump = lastNum - num;

        if (Math.Abs(currentJump) > 3 || Math.Abs(currentJump) < 1)
        {
            return false;
        }
        if(!first && (lastDiff >0 != currentJump >0))
        {
            return false;
        }

        lastNum = num;
        lastDiff = currentJump;
        first = false;
    }
    return true;

}