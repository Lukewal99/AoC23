// See https://aka.ms/new-console-template for more information
StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
long timeHeld = 0;
long numberOfSolutions = 0;
long product = 1;
//Manually rearranged to be  Time, Distance \n

foreach (string line in data)
{
    numberOfSolutions = 0;
    long totalTime = Convert.ToInt64(line.Split(' ')[0]);
    long minDistance = Convert.ToInt64(line.Split(' ')[1]);

    if (totalTime%2 == 0)
    { // Even
        timeHeld = totalTime / 2 ;
        if (timeHeld * (totalTime - timeHeld) >= minDistance)
        {
            numberOfSolutions = 1;
        }

        for (int i = 1; i < totalTime/2; i++)
        {
            timeHeld = totalTime/2 - i;
            if (timeHeld * (totalTime - timeHeld) > minDistance)
            {
                numberOfSolutions +=2;
            }
        }
    }

    else // Odd
    {

        for (int i = 0; i < totalTime / 2; i++)
        {
            timeHeld = totalTime / 2 - i;
            if (timeHeld * (totalTime - timeHeld) > minDistance)
            {
                numberOfSolutions += 2;
            }
        }
    }

    product *= numberOfSolutions;
}

Console.WriteLine(product);