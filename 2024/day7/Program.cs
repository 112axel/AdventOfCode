var input = File.ReadAllLines("./input.txt");


long result = 0;
foreach (var line in input)
{
    var parts1 = line.Split(':');
    long target = long.Parse(parts1[0]);

    var parts2 = parts1[1].Trim().Split(" ");

    var numbers = parts2.Select(long.Parse).ToList();


    var operations = parts2.Select(x=>"+").ToList();
    //remove 1
    operations.RemoveAt(0);

    while (operations.Last() != "x")
    {

        var calcResult = RunCalculation(numbers, operations);
        if (calcResult == target)
        {
            Console.WriteLine($"adding {calcResult}");
            result += calcResult;
            break;
        }
        IncrementList(operations);
    }
}

Console.WriteLine(result);

bool IncrementList(List<string> opertaions, int offset = 0)
{
    var length = opertaions.Count;
    if (offset >= length)
    {
        opertaions[offset - 1] = "x";
        return false;
    }

    switch (opertaions[offset])
    {
        case ("+"):
            {
                opertaions[offset] = "|";
                break;
            }
        case ("|"):
            {
                opertaions[offset] = "*";
                break;
            }

        case ("*"):
            {
                opertaions[offset] = "+";
                IncrementList(opertaions, offset + 1);
                break;
            }
    }
    return true;

}
long RunCalculation(List<long> numbers, List<string> operations)
{
    long? last = null;
    for (int i = 0; i < numbers.Count; i++)
    {
        if (last == null)
        {
            last = numbers[i];
            continue;
        }

        var operation = operations[i - 1];

        if (operation == "+")
        {
            last += numbers[i];
            continue;
        }
        if(operation == "|")
        {
            last = long.Parse(last.ToString() + numbers[i].ToString());
        }
        if (operation == "*")
        {
            last *= numbers[i];
            continue;
        }

    }
    return last ?? 0;
}


