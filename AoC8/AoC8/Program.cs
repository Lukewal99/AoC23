// See https://aka.ms/new-console-template for more information

int task = 2;
StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
string directions = data[0];
Dictionary<string, string[]> map = new Dictionary<string, string[]>();
Dictionary<string, List<int>> startToLoop = new Dictionary<string, List<int>>();

int steps = 0;

for (int i = 2; i < data.Length; i++)
{
    string line = data[i];
    line = line.Remove(4, 3);
    line = line.Remove(7,1);
    line = line.Remove(11,1);
    string[] lineSplit =  line.Split(" ");
    string location = lineSplit[0];
    string Left = lineSplit[1];
    string Right = lineSplit[2];
    string[] destinations = new string[] { Left, Right };

    map.Add(location, destinations);
}

if (task == 1)
{
    string current = "AAA";
    int j = -1;
    steps = 0;
    while (current != "ZZZ")
    {
        j = steps % directions.Length;
        if (directions[j] == 'R')
        {
            current = map[current][1];
        }
        else if (directions[j] == 'L')
        {
            current = map[current][0];
        }
        else
        {
            Console.WriteLine("FUCK direction not RL");
        }
        steps++;
    }
    Console.WriteLine(steps);
}

else if (task ==2)
{
   


}

