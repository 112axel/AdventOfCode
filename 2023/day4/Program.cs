var input = File.ReadAllLines("./input.txt");
double pointSum = 0;
for(int i = 0; i<input.Length; i++)
{
    var split1 = input[i].Split(":");
    var card = split1[0];
    var split2 = split1[1].Split("|");
    var winningNumbers = split2[0].Trim().Split(" ").Where(x=> x!="").ToList();
    var numbersIHave = split2[1].Trim().Split(" ").Where(x=> x!="").ToList();

    double numberOfMatches = numbersIHave.Count(x=>winningNumbers.Contains(x));

    pointSum += numberOfMatches == 0 ? 0 : Math.Pow(2.0, (numberOfMatches - 1) * 1.0);

}

Console.WriteLine(pointSum);


