var input = File.ReadAllLines("./input.txt");


var result = 0;
foreach (var line in input)
{
    var numLine = line.Split(' ').Select(int.Parse);
    if (IsValid(numLine.ToList(),true))
    {
        result++;
    }
}


Console.WriteLine(result);

bool IsValid(List<int> ints, bool allowError)
{
    int lastNum = ints.First();
    int lastDiff = 0;
    bool first = true;

    bool errorLeft = allowError;

    if (allowError)
    {
        var ints2 = ints.ToList();
        ints2.RemoveAt(0);
        if(IsValid(ints2, false))
        {
            return true;
        }
        ints2 = ints.ToList();
        ints2.RemoveAt(1);
        if(IsValid(ints2, false))
        {
            return true;
        }

    }

    for (int i = 1; i < ints.Count; i++)
    {
        var num = ints[i];
        var currentJump = lastNum - num;

        if (Math.Abs(currentJump) > 3 || Math.Abs(currentJump) < 1)
        {
            if (errorLeft)
            {
                ints.RemoveAt(i);
                return IsValid(ints, false);
            }
            return false;
        }
        if (!first && (lastDiff > 0 != currentJump > 0))
        {
            if (errorLeft)
            {
                ints.RemoveAt(i);
                return IsValid(ints, false);
            }
            return false;
        }

        lastNum = num;
        lastDiff = currentJump;
        first = false;
    }
    return true;

}