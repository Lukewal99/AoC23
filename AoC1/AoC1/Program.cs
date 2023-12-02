// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string line = sr.ReadLine();
int first = 0;
int last = 0;
int total = 0;
int[] checkInt = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
int i = 0;
string[] checkStr = { "one", "two", "three","four","five","six","seven","eight","nine"};
bool notFound = true;

while (line != null)
{
    i = 0;
    notFound = true;

    while (i < line.Length && notFound)
    {
        if (i + 5 <= line.Length)
        {
            if (checkStr.Contains(line.Substring(i, 5)))
            {
                first = Array.FindIndex(checkStr, element => element == line.Substring(i, 5)) + 1;
                notFound = false;
                i += 4;
            }
        }

        if (i + 4 <= line.Length && notFound) 
        { 
            if (checkStr.Contains(line.Substring(i, 4)))
            {
                first = Array.FindIndex(checkStr, element => element == line.Substring(i, 4)) + 1;
                notFound = false;
                i += 3;
            } 
        }

        if (i + 3 <= line.Length && notFound)
        {
            if (checkStr.Contains(line.Substring(i, 3)))
            {
                first = Array.FindIndex(checkStr, element => element == line.Substring(i, 3)) + 1;
                notFound = false;
                i += 2;
            }
        }


        if (checkInt.Contains(Convert.ToInt32(line[i])-48))
        {
            first = line[i] - 48;
            notFound = false;
        }
        i++;
        
    }

    i = line.Length - 1;
    notFound = true;
    while (i >= 0 && notFound)
    {
        if (i + 5 <= line.Length)
        {
            if (checkStr.Contains(line.Substring(i, 5)))
            {
                last = Array.FindIndex(checkStr, element => element == line.Substring(i, 5)) + 1;
                notFound = false;
                i -= 4;
            }
        }
        
        if (i + 4 <= line.Length && notFound)
        {
            if (checkStr.Contains(line.Substring(i, 4)))
            {
                last = Array.FindIndex(checkStr, element => element == line.Substring(i, 4)) + 1;
                notFound = false;
                i -= 3;
            }
        }

        if (i + 3 <= line.Length && notFound)
        {
            if (checkStr.Contains(line.Substring(i, 3)))
            {
                last = Array.FindIndex(checkStr, element => element == line.Substring(i, 3)) + 1;
                notFound = false;
                i -= 2;
            }
        }

        if (notFound)
        {
            if (checkInt.Contains(Convert.ToInt32(line[i]) - 48))
            {
                last = line[i] - 48;
                notFound = false;
            }
        }

        i--;
    }


    string combined = first + "" + last;
    int intCombined = Convert.ToInt32(combined);
    total += intCombined;

    Console.WriteLine(line + " " + combined);
    line = sr.ReadLine();
}

Console.WriteLine(total);

sr.Close();