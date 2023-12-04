// See https://aka.ms/new-console-template for more information

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
Dictionary<string,int> maximums = new Dictionary<string,int>();
maximums.Add("red", 0);
maximums.Add("green", 0);
maximums.Add("blue", 0);
int IDSum = 0;
int task = 2;
int powerSum = 0;

for (int i = 0; i < data.Length; i++)
{
	string line = data[i];

    string[] game = line.Split(": ")[1].Split("; ");
	foreach (string pull in game)
	{
		string[] colours = pull.Split(", ");
		foreach (string colour in colours)
		{
			string[] colourSplit = colour.Split(" ");
			int temp1 = Convert.ToInt32(colourSplit[0]);
			int temp2 = maximums[colourSplit[1]];
            if (Convert.ToInt32(colourSplit[0]) > maximums[colourSplit[1]])
			{
				maximums[colourSplit[1]] = Convert.ToInt32(colourSplit[0]);

            }
		}
	}

	if (task == 1)
	{
		if (maximums["red"] <= 12 && maximums["green"] <= 13 && maximums["blue"] <= 14)
		{
			IDSum += i + 1;
		}
	}
	else if(task == 2)
	{
		powerSum += maximums["red"] * maximums["green"] * maximums["blue"];

    }
	maximums["red"] = 0;
    maximums["green"] = 0;
    maximums["blue"] = 0;
}

if (task == 1)
{
	Console.WriteLine(IDSum);
}
if (task == 2)
{
	Console.WriteLine(powerSum);
}