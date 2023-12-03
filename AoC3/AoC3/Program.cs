// See https://aka.ms/new-console-template for more information
using System.Globalization;

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] data = sr.ReadToEnd().Split("\r\n");
char[] numbers = { '0', '1', '2', '3', '4', '5', '6','7','8','9' };
char check = '.';
string foundPartNumber = "";
List<int> adjacents = new List<int>();
int sum = 0;

int part = 2;

if (part == 1)
{
    for (int i = 0; i < data.Length - 2; i++)
    {
        Console.Clear();
        // Loop through 3 lines at a time
        string line1 = data[i];
        string line2 = data[i + 1];
        string line3 = data[i + 2];
        Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n");

        for (int j = 0; j < line2.Length; j++)
        { //Check every character in the middle line
            check = line2[j];

            if (!numbers.Contains(check) && check != '.')
            { // Check is a symbol

                // There is a number North
                if (numbers.Contains(line1[j]))
                {

                    if (!numbers.Contains(line1[j - 1]))
                    { // Found first
                        foundPartNumber = line1[j] + "" + line1[j + 1] + "" + line1[j + 2];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                    }

                    else if (!numbers.Contains(line1[j + 1]))
                    { // Found last
                        foundPartNumber = line1[j - 2] + "" + line1[j - 1] + "" + line1[j];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                    }
                    else
                    { // Found middle
                        foundPartNumber = line1[j - 1] + "" + line1[j] + "" + line1[j + 1];
                        sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                    }

                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));

                }
                else
                {
                    // There is a number NW, and not North
                    if (numbers.Contains(line1[j - 1]))
                    {
                        // Found last
                        foundPartNumber = line1[j - 3] + "" + line1[j - 2] + "" + line1[j - 1];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }

                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }

                    // There is a number NE, and not North
                    if (numbers.Contains(line1[j + 1]))
                    {
                        // Found first
                        foundPartNumber = line1[j + 1] + "" + line1[j + 2] + "" + line1[j + 3];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }
                }

                // There is a number South
                if (numbers.Contains(line3[j]))
                {

                    if (!numbers.Contains(line3[j - 1]))
                    { // Found first
                        foundPartNumber = line3[j] + "" + line3[j + 1] + "" + line3[j + 2];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                    }

                    else if (!numbers.Contains(line3[j + 1]))
                    { // Found last
                        foundPartNumber = line3[j - 2] + "" + line3[j - 1] + "" + line3[j];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                    }
                    else
                    { // Found middle
                        foundPartNumber = line3[j - 1] + "" + line3[j] + "" + line3[j + 1];
                        sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                    }

                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }
                else
                {
                    // There is a number SW, and not South
                    if (numbers.Contains(line3[j - 1]))
                    {
                        // Found last
                        foundPartNumber = line3[j - 3] + "" + line3[j - 2] + "" + line3[j - 1];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }

                    // There is a number SE, and not South
                    if (numbers.Contains(line3[j + 1]))
                    {
                        // Found first
                        foundPartNumber = line3[j + 1] + "" + line3[j + 2] + "" + line3[j + 3];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            sum += Convert.ToInt32(foundPartNumber);
                        }
                        else
                        {
                            sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }
                }

                // There is a number West
                if (numbers.Contains(line2[j - 1]))
                {
                    // Found last
                    foundPartNumber = line2[j - 3] + "" + line2[j - 2] + "" + line2[j - 1];
                    if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                    { // accidentally found two numbers
                        foundPartNumber = foundPartNumber.Substring(2, 1);
                        sum += Convert.ToInt32(foundPartNumber);
                    }
                    else
                    {
                        sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                    }
                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }

                // There is a number East
                if (numbers.Contains(line2[j + 1]))
                {
                    // Found first
                    foundPartNumber = line2[j + 1] + "" + line2[j + 2] + "" + line2[j + 3];
                    if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                    { // accidentally found two numbers
                        foundPartNumber = foundPartNumber.Substring(0, 1);
                        sum += Convert.ToInt32(foundPartNumber);
                    }
                    else
                    {
                        sum += Convert.ToInt32(foundPartNumber.Replace(".", ""));
                    }
                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }
            }
        }
        Console.WriteLine(sum);
    }

    
}
else if(part == 2)
{
    for (int i = 0; i < data.Length - 2; i++)
    {
        Console.Clear();
        // Loop through 3 lines at a time
        string line1 = data[i];
        string line2 = data[i + 1];
        string line3 = data[i + 2];
        Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n");

        for (int j = 0; j < line2.Length; j++)
        { //Check every character in the middle line
            adjacents = new List<int>();
            check = line2[j];

            if (check == '*')
            { // Check is a gear

                // There is a number North
                if (numbers.Contains(line1[j]))
                {

                    if (!numbers.Contains(line1[j - 1]))
                    { // Found first
                        foundPartNumber = line1[j] + "" + line1[j + 1] + "" + line1[j + 2];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                    }

                    else if (!numbers.Contains(line1[j + 1]))
                    { // Found last
                        foundPartNumber = line1[j - 2] + "" + line1[j - 1] + "" + line1[j];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                    }
                    else
                    { // Found middle
                        foundPartNumber = line1[j - 1] + "" + line1[j] + "" + line1[j + 1];
                        adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                    }

                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));

                }
                else
                {
                    // There is a number NW, and not North
                    if (numbers.Contains(line1[j - 1]))
                    {
                        // Found last
                        foundPartNumber = line1[j - 3] + "" + line1[j - 2] + "" + line1[j - 1];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }

                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }

                    // There is a number NE, and not North
                    if (numbers.Contains(line1[j + 1]))
                    {
                        // Found first
                        foundPartNumber = line1[j + 1] + "" + line1[j + 2] + "" + line1[j + 3];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }
                }

                // There is a number South
                if (numbers.Contains(line3[j]))
                {

                    if (!numbers.Contains(line3[j - 1]))
                    { // Found first
                        foundPartNumber = line3[j] + "" + line3[j + 1] + "" + line3[j + 2];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                    }

                    else if (!numbers.Contains(line3[j + 1]))
                    { // Found last
                        foundPartNumber = line3[j - 2] + "" + line3[j - 1] + "" + line3[j];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                    }
                    else
                    { // Found middle
                        foundPartNumber = line3[j - 1] + "" + line3[j] + "" + line3[j + 1];
                        adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                    }

                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }
                else
                {
                    // There is a number SW, and not South
                    if (numbers.Contains(line3[j - 1]))
                    {
                        // Found last
                        foundPartNumber = line3[j - 3] + "" + line3[j - 2] + "" + line3[j - 1];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(2, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }

                    // There is a number SE, and not South
                    if (numbers.Contains(line3[j + 1]))
                    {
                        // Found first
                        foundPartNumber = line3[j + 1] + "" + line3[j + 2] + "" + line3[j + 3];
                        if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                        { // accidentally found two numbers
                            foundPartNumber = foundPartNumber.Substring(0, 1);
                            adjacents.Add(Convert.ToInt32(foundPartNumber));
                        }
                        else
                        {
                            adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                        }
                        Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                    }
                }

                // There is a number West
                if (numbers.Contains(line2[j - 1]))
                {
                    // Found last
                    foundPartNumber = line2[j - 3] + "" + line2[j - 2] + "" + line2[j - 1];
                    if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                    { // accidentally found two numbers
                        foundPartNumber = foundPartNumber.Substring(2, 1);
                        adjacents.Add(Convert.ToInt32(foundPartNumber));
                    }
                    else
                    {
                        adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                    }
                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }

                // There is a number East
                if (numbers.Contains(line2[j + 1]))
                {
                    // Found first
                    foundPartNumber = line2[j + 1] + "" + line2[j + 2] + "" + line2[j + 3];
                    if (foundPartNumber.Substring(1, 1) == "." && foundPartNumber.Replace(".", "").Length == 2)
                    { // accidentally found two numbers
                        foundPartNumber = foundPartNumber.Substring(0, 1);
                        adjacents.Add(Convert.ToInt32(foundPartNumber));
                    }
                    else
                    {
                        adjacents.Add(Convert.ToInt32(foundPartNumber.Replace(".", "")));
                    }
                    Console.WriteLine(foundPartNumber + " " + foundPartNumber.Replace(".", ""));
                }

                if(adjacents.Count == 2)
                {
                    sum += adjacents[0] * adjacents[1];
                }
            }
        }
    }
}

Console.WriteLine(sum);
sr.Close();
