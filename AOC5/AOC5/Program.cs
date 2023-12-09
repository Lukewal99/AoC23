// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n\r\n");

string[] seeds = data[0].Split(": ")[1].Split(" ");
// Seed, Next value
long nextValue = 0;
string[] SeedToSoilMap = data[1].Split(":\r\n")[1].Split("\r\n");
string[] SoilToFertilizerMap = data[2].Split(":\r\n")[1].Split("\r\n");
string[] FertilizerToWaterMap = data[3].Split(":\r\n")[1].Split("\r\n");
string[] WaterToLightMap = data[4].Split(":\r\n")[1].Split("\r\n");
string[] LightToTempMap = data[5].Split(":\r\n")[1].Split("\r\n");
string[] TempToHumidityMap = data[6].Split(":\r\n")[1].Split("\r\n");
string[] HumidityToLocationMap = data[7].Split(":\r\n")[1].Split("\r\n");
long lowestLocal = -1;
string[][] Maps = new string[][] {SeedToSoilMap,SoilToFertilizerMap,FertilizerToWaterMap,WaterToLightMap,LightToTempMap,TempToHumidityMap,HumidityToLocationMap};
int task = 2;

if (task == 1)
{
	// foreach seed
	foreach (string seed in seeds)
	{
		nextValue = Convert.ToInt64(seed);
		// foreach map
		for (int i = 0; i < Maps.Length; i++)
		{
			//foreach map straight
			int j = 0;
			bool Found = false;
			while (j < Maps[i].Length && !Found)
			{
				string[] nextMapping = Maps[i][j].Split(" ");

				if (Convert.ToInt64(nextValue) >= Convert.ToInt64(nextMapping[1]) && Convert.ToInt64(nextValue) < Convert.ToInt64(nextMapping[1]) + Convert.ToInt64(nextMapping[2]))
				{
					nextValue = Convert.ToInt64(nextMapping[0]) + (nextValue - Convert.ToInt64(nextMapping[1]));
					Found = true;
				}
				j++;
			}
		}
		//location should be found
		if (nextValue < lowestLocal || lowestLocal == -1)
		{
			lowestLocal = nextValue;
		}
	}
}


else if(task == 2)
{
    for (int i = 0; i < seeds.Length/2; i++)
    {
        long seedStart = Convert.ToInt64(seeds[2 * i]);
        long seedRange = Convert.ToInt64(seeds[2 * i + 1]);
    }



	for (int l = 1000; l < seeds.Length-1000; l+=1000)
    {
		string seed = seeds[l];
        nextValue = Convert.ToInt64(seed);
        // foreach map
        for (int i = 0; i < Maps.Length; i++)
        {
            //foreach map straight
            int j = 0;
            bool Found = false;
            while (j < Maps[i].Length && !Found)
            {
                string[] nextMapping = Maps[i][j].Split(" ");

                if (Convert.ToInt64(nextValue) >= Convert.ToInt64(nextMapping[1]) && Convert.ToInt64(nextValue) < Convert.ToInt64(nextMapping[1]) + Convert.ToInt64(nextMapping[2]))
                {
                    nextValue = Convert.ToInt64(nextMapping[0]) + (nextValue - Convert.ToInt64(nextMapping[1]));
                    Found = true;
                }
                j++;
            }
        }
        if (nextValue < lowestLocal || lowestLocal == -1)
        {
            for (int k = l-1000; k < l+1000; k++)
            {
                nextValue = Convert.ToInt64(seed);
                // foreach map
                for (int i = 0; i < Maps.Length; i++)
                {
                    //foreach map straight
                    int j = 0;
                    bool Found = false;
                    while (j < Maps[i].Length && !Found)
                    {
                        string[] nextMapping = Maps[i][j].Split(" ");

                        if (Convert.ToInt64(nextValue) >= Convert.ToInt64(nextMapping[1]) && Convert.ToInt64(nextValue) < Convert.ToInt64(nextMapping[1]) + Convert.ToInt64(nextMapping[2]))
                        {
                            nextValue = Convert.ToInt64(nextMapping[0]) + (nextValue - Convert.ToInt64(nextMapping[1]));
                            Found = true;
                        }
                        j++;
                    }
                }
                //location should be found
                if (nextValue < lowestLocal || lowestLocal == -1)
                {
                    lowestLocal = nextValue;
                }
            }
        }
    }
}

// 10,000,000 is too low
// 100,000,000 is too high
// I can guarantee it is not a seed that maps onto itself

Console.WriteLine(lowestLocal);
sr.Close();