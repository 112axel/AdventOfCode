var input = File.ReadAllLines("./input.txt");

List<Hand> hands = new List<Hand>();
foreach(var line in input)
{
    var splitString = line.Split();
    hands.Add(new Hand(int.Parse(splitString[1]), splitString[0]));
}

hands.Sort();
var x = hands.Select(x => x.BigSort()).Reverse();
hands.Reverse();
var sum = 0;
for(int i = 0; i<hands.Count(); i++)
{
    sum += (i + 1) * hands[i].Bet;
}
Console.WriteLine(sum);


public class Hand: IComparable
{
    public int Bet { get; set; }
    private List<int> CardValues { get; set; } = new();

    private Dictionary<char, int> highValue = new()
    {
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 }
    };

    public Hand(int bet, string cards)
    {
        Bet = bet;

        CardValues = ParseCards(cards);
    }

    private List<int> ParseCards(string cards)
    {
        List<int> output = new();
        foreach (var card in cards)
        {
            if (Char.IsDigit(card))
            {
                output.Add(int.Parse(card.ToString()));
            }
            else
            {
                output.Add(highValue[card]);
            }
        }
        return output;
    }

    public int BigSort()
    {
        Dictionary<int, int> occurrences = new();
        foreach (var card in CardValues)
        {
            if (occurrences.ContainsKey(card))
            {
                occurrences[card]++;
            }
            else
            {
                occurrences.Add(card, 1);
            }
        }
        var maxAmount = occurrences.Max(x=>x.Value);
        if(maxAmount == 5)
        {
            return 10;
        }
        if(maxAmount == 4)
        {
            return 9;
        }
        if(maxAmount == 3)
        {
            if(occurrences.Where(x=>x.Value == 2).Count() == 1)
            {
                return 8;
            }
            return 7;
        }
        if(occurrences.Count(x=>x.Value == 2) == 2)
        {
            return 6;
        }
        if(maxAmount == 2)
        {
            return 5;
        }
        return 4;
    }

    public int SmallSort(Hand otherHand)
    {
        for(int i = 0; i<this.CardValues.Count; i++)
        {
            if (this.CardValues[i] > otherHand.CardValues[i])
            {
                return -1;
            }
            else if(this.CardValues[i] < otherHand.CardValues[i]){
                return 1;
            }
        }
        return 0;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        Hand otherHand = obj as Hand;
        int bigSort = this.BigSort();
        int otherBigSort = otherHand.BigSort();

        if(bigSort == otherBigSort)
        {
            return this.SmallSort(otherHand);
        }
        else
        {
            return otherBigSort - bigSort;
        }

    }
}
