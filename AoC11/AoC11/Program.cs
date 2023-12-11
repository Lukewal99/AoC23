// See https://aka.ms/new-console-template for more information

// IMPORTANT
// Put input data into MATLABinput, run MATLAB AoC11, then run this code
StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] dataTemp = sr.ReadToEnd().Split("\r\n");
// x,y
Dictionary<int, int[]> map = new Dictionary<int, int[]>();
int count = 0;
int sum = 0;
int task = 1;

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

}
Console.WriteLine(sum);
sr.Close();


