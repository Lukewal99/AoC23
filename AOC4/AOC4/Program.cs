// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;

int task = 2;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
List<string> data = sr.ReadToEnd().Split("\r\n").ToList();
int numsMatching = 0;
double scoreSum = 0;


if (task == 1)
{
    foreach (string line in data)
    {
        string[] Ticket = line.Split(":")[1].Split(" |");
        string[] WinningNumbers = Ticket[0].Replace("  ", " ").Split(" ");
        string[] NumbersYouHave = Ticket[1].Replace("  ", " ").Split(" ");
        numsMatching = 0;
        foreach (string number in NumbersYouHave)
        {
            if (WinningNumbers.Contains(number) && number != "")
            {
                numsMatching++;
            }
        }

        if (numsMatching > 0)
        {
            scoreSum += Math.Pow(2, (numsMatching - 1));
        }
    }
    Console.WriteLine(scoreSum);
}
else if(task == 2)
{
    // All of the cards, and how many matching numbers they have
    // Card Number / Numbers that match
    Dictionary<int, int> reference = new Dictionary<int, int>();
    foreach (string line in data)
    {
        numsMatching = 0;
        string[] Ticket = line.Split(": ");
        int TicketNumber = Convert.ToInt32(Ticket[0].Split(" ").Last()); 
        
        string[] Numbers = Ticket[1].Split(" | ");
        string[] WinningNumbers = Numbers[0].Split(" ");
        string[] NumbersYouHave = Numbers[1].Split(" ");

        foreach (string number in NumbersYouHave)
        {
            if (WinningNumbers.Contains(number) && number != "")
            {
                numsMatching++;
            }
        }

        reference.Add(TicketNumber, numsMatching);

    }
   
    // Card Number / How many of that card I have
    Dictionary<int,int> cardsCounts = new Dictionary<int, int>();
    foreach (KeyValuePair<int,int> card in reference)
    {
        cardsCounts.Add(card.Key, 1);
    }

    foreach(KeyValuePair<int,int> card in cardsCounts)
    {
        for (int i = 1; i <= reference[card.Key]; i++)
        {
            cardsCounts[card.Key+i] += card.Value;
        }
    }

    Console.WriteLine(cardsCounts.Values.Sum());
}