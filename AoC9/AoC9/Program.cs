bool allZeroes(List<int> input)
{
    foreach (int item in input)
    {
        if (item != 0)
        {
            return false;
        }
    }
    return true;
}



// See https://aka.ms/new-console-template for more information

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
List<List<List<int>>> differences = new List<List<List<int>>>();
int sum = 0;

foreach (string line in data)
{
    List<List<int>> lineDifferences = new List<List<int>>();
    string[] lineSplitTemp = line.Split(" ");
    List<int> lineSplit = new List<int>();
    foreach (string item in lineSplitTemp)
    {
        lineSplit.Add(Convert.ToInt32(item));
    }

    lineDifferences.Add(lineSplit);
    while (!allZeroes(lineDifferences.Last())) 
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < lineDifferences.Last().Count - 1; i++)
        {
            int difference = Convert.ToInt32(lineDifferences.Last()[i + 1]) - Convert.ToInt32(lineDifferences.Last()[i]);
            temp.Add(difference);
        }
        lineDifferences.Add(temp);
    }

    lineDifferences.Last().Insert(0,0);

    for (int j = lineDifferences.Count-2; j > -1; j--)
    {
        lineDifferences[j].Insert(0,lineDifferences[j].First() - lineDifferences[j + 1].First());
    }

    
    sum += lineDifferences.First().First();
}
Console.WriteLine(sum);