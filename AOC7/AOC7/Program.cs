// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Net.NetworkInformation;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
long sum = 0;

#region Define conversion Dictionary. Yes I should use an Enum, No i couldn't get it working.
Dictionary<char, int> cardToNumber = new Dictionary<char, int>();
cardToNumber.Add('A', 0);
cardToNumber.Add('K', 1);
cardToNumber.Add('Q', 2);
cardToNumber.Add('J', 3);
cardToNumber.Add('T', 4);
cardToNumber.Add('9', 5);
cardToNumber.Add('8', 6);
cardToNumber.Add('7', 7);
cardToNumber.Add('6', 8);
cardToNumber.Add('5', 9);
cardToNumber.Add('4', 91);
cardToNumber.Add('3', 92);
cardToNumber.Add('2', 93);
Dictionary<int, char> NumberToCard = new Dictionary<int, char>();
NumberToCard.Add(0, 'A');
NumberToCard.Add(1, 'K');
NumberToCard.Add(2, 'Q');
NumberToCard.Add(3, 'J');
NumberToCard.Add(4, 'T');
NumberToCard.Add(5, '9');
NumberToCard.Add(6, '8');
NumberToCard.Add(7, '7');
NumberToCard.Add(8, '6');
NumberToCard.Add(9, '5');
NumberToCard.Add(91, '4');
NumberToCard.Add(92, '3');
NumberToCard.Add(93, '2');
#endregion

List<string>[] handScoresAndBids = new List<string>[7];
for (int i = 0; i < 7; i++)
{
    handScoresAndBids[i] = new List<string>();
}

foreach (string line in data)
{
    string[] lineFormatted = line.Split(" ");
    string hand = lineFormatted[0];
    int bid = Convert.ToInt32(lineFormatted[1]);

    // Card / Count of that card
    Dictionary<char,int> handCounted = new Dictionary<char,int>();
    foreach (char card in hand)
    {
        if (handCounted.ContainsKey(card))
        {
            handCounted[card]++;
        }
        else
        {
            handCounted.Add(card,1);
        }
    }

    // Identify hands
    KeyValuePair<char, int> keyValuePair;
    switch (handCounted.Count)
    {
        case 5:
            // HC
            handScoresAndBids[6].Add(hand + " : " + Convert.ToInt32(bid));
            break;

        case 4:
            // P
            handScoresAndBids[5].Add(hand + " : " + Convert.ToInt32(bid));
            break;

        case 3:
            // 3oaK or 2P
            keyValuePair = handCounted.First();
            if(keyValuePair.Value == 3)
            { // 3oaK
                handScoresAndBids[3].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else if(keyValuePair.Value == 2)
            { // 2P
                handScoresAndBids[4].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else if(keyValuePair.Value == 1)
            {
                keyValuePair = handCounted.Last();
                if(keyValuePair.Value == 1)
                { // 3oaK
                    handScoresAndBids[3].Add(hand + " : " + Convert.ToInt32(bid));
                }
                else if(keyValuePair.Value == 2)
                { // 2P
                    handScoresAndBids[4].Add(hand + " : " + Convert.ToInt32(bid));
                }
            }

            break;

        case 2:
            // 4oak or FH
            keyValuePair = handCounted.First();
            if(keyValuePair.Value == 4)
            { // FoaK
                handScoresAndBids[1].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else if (keyValuePair.Value == 3)
            { // FH
                handScoresAndBids[2].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else if (keyValuePair.Value == 2)
            { // FH
                handScoresAndBids[2].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else if (keyValuePair.Value == 1)
            { // FoaK
                handScoresAndBids[1].Add(hand + " : " + Convert.ToInt32(bid));
            }
            else
            { // Fuck
                Console.WriteLine("FUCK: Invalid 4oaK / FH");
            }
            break;

        case 1:
            // 5oaK
            handScoresAndBids[0].Add(hand + " : " + Convert.ToInt32(bid));
            break;

        default:
            Console.WriteLine("FUCK: Invalid Hand");
            break;
    }
}

int rank = data.Length;
List<string> cards = new List<string>();
List<string> cardsNumerised = new List<string>();
// HC, Pair, 2P etc.
foreach (List<string> scoreType in handScoresAndBids)
{
    cards = new List<string>();
    cardsNumerised = new List<string>();
    if (scoreType.Count != 0)
    {
        foreach (string hand in scoreType)
        {
            string handNumerised = "";
            foreach (char card in hand.Split(" : ")[0])
            {
                handNumerised += cardToNumber[card] + " ";
            }
            cardsNumerised.Add(handNumerised + " : " + hand.Split(" : ")[1]);
        }
        cardsNumerised.Sort();

    }
    foreach (string hand in cardsNumerised)
    {
        string handCharacterised = "";
        foreach (string card in hand.Split(" : ")[0].Split(" "))
        {
            if (card != "")
            {
                handCharacterised += NumberToCard[Convert.ToInt32(card)];
            }
        }
        cards.Add(handCharacterised + " : " + hand.Split(" : ")[1]);
    }

    foreach (string card in cards)
    {
        int bid = Convert.ToInt32(card.Split(" : ")[1]);
        sum += bid * rank;
        Console.WriteLine(card.Split(" ")[0]);
        rank--;
    }
}



Console.WriteLine(sum);

//249221489 is too low
// 93508364 not right