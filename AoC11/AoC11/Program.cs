// See https://aka.ms/new-console-template for more information

// IMPORTANT
// Put input data into MATLABinput, run MATLAB AoC11, then run this code
using System.Diagnostics.CodeAnalysis;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] dataTemp = sr.ReadToEnd().Split("\r\n");
// x,y
Dictionary<long, int[]> map = new Dictionary<long, int[]>();
long count = 0;
long sum = 0;
int task = 2;

if (task == 1)
{
    for (int i = 0; i < dataTemp.Length; i++)
    {
        string data = dataTemp[i];
        string[] line = data.Split(',');
        for (int j = 0; j < line.Length; j++)
        {
            if (line[j] == "#")
            {
                map.Add(count, new int[] { j, i });
                count++;
            }
        }
    }

    int[] pointOne = new int[2];
    int[] pointTwo = new int[2];

    for (int i = 0; i < map.Count; i++)
    {
        pointOne = map[i];
        for (int j = i + 1; j < map.Count; j++)
        {
            pointTwo = map[j];
            sum += Math.Abs(pointTwo[0] - pointOne[0]) + Math.Abs(pointTwo[1] - pointOne[1]);

        }
    }
}

else if(task == 2)
{
    for (int i = 0; i < dataTemp.Length; i++)
    {
        string[] line = dataTemp[i].Split(",");
        for (int j = 0; j < line.Length; j++)
        { 
            string item = line[j];
            if(item == "0")
            {
                map.Add(count, new int[] { j, i });
                count++;
            }
        }
    }

    // x,y
    int[] pointOne = new int[2];
    int[] pointTwo = new int[2];

    for (int i = 0; i < map.Count; i++)
    {
        pointOne = map[i];
        for (int j = i+1; j < map.Count; j++)
        {
            pointTwo = map[j];
            int x1 = Math.Min(pointOne[0], pointTwo[0]);
            int y1 = Math.Min(pointOne[1], pointTwo[1]);
            int x2 = Math.Max(pointOne[0], pointTwo[0]);
            int y2 = Math.Max(pointOne[1], pointTwo[1]);

            for (int k = x1; k <= x2; k++)
            {
                int square = Convert.ToInt32(dataTemp[y1].Split(",")[k]);
                if(square == 001 || square == 000 || square == 101)
                {
                    count += 1;
                }
                else if(square == 011 || square == 111)
                {
                    count += 1000000;
                }
            }

            for (int k = y1; k <= y2; k++)
            {
                int square = Convert.ToInt32(dataTemp[k].Split(",")[x2]);
                if (square == 001 || square == 000 || square == 011)
                {
                    count += 1;
                }
                else if (square == 101 || square == 111)
                {
                    count += 1000000;
                }
            }

            //Console.WriteLine("Point " + (i+1) + " & Point: " + (j+1) + " Distance: " + count);
            sum += count;
            count = 0;
        }
    }


}
Console.WriteLine(sum-81);
sr.Close();


