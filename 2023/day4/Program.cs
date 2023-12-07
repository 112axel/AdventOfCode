var input = File.ReadAllLines("./input.txt");
double pointSum = 0;

List<List<string>> winingNumbers2 = new List<List<string>>();
List<List<string>> numbersHave2 = new List<List<string>>();
for(int i = 0; i<input.Length; i++)
{
    var split1 = input[i].Split(":");
    var card = split1[0];
    var split2 = split1[1].Split("|");
    var winningNumbers = split2[0].Trim().Split(" ").Where(x=> x!="").ToList();
    var numbersIHave = split2[1].Trim().Split(" ").Where(x=> x!="").ToList();

    double numberOfMatches = numbersIHave.Count(x=>winningNumbers.Contains(x));

    pointSum += numberOfMatches == 0 ? 0 : Math.Pow(2.0, (numberOfMatches - 1) * 1.0);

    winingNumbers2.Add(winningNumbers);
    numbersHave2.Add(numbersIHave);

}


var sum = 0;
for(int i = 0; i<input.Length; i++)
{
    sum += recursive(winingNumbers2, numbersHave2 ,i);
}

Console.WriteLine(pointSum);
Console.WriteLine(sum);

int recursive(List<List<string>>win, List<List<string>>have,int index)
{
    int numberOfMatches = have[index].Count(x => win[index].Contains(x));
    var newTicets = Enumerable.Range(index + 1, numberOfMatches);
    return newTicets.Sum(x=>recursive(win,have,x))+1;

} 
