// See https://aka.ms/new-console-template for more information

StreamReader sr = new StreamReader("C:\\Users\\lukew\\Desktop\\AoC23\\Advent.csv");
string[] map = sr.ReadToEnd().Split("\r\n");
int startX = 0;
int startY = 0;
object[] temp = new object[3];
int count = 0;
char debug = 'a';
int task = 2;
bool found = false;
// I needed two of them, or use breaks but breaks suck
bool foundTwo = false;
char outside = '!';

Dictionary<string,char> mappedLoop = new Dictionary<string, char>();

int i = 0;
while(!found)
{
    string line = map[i];  
    if (line.Contains("S"))
    {
        found= true;
        startX = line.IndexOf("S");
        startY = i;
    }
    i++;
}
// Using a list so that i can just append, and then i dont have to worry about if one connection has been found already or not
// Y, X, From(NESW)
List<object[]> nextSteps = new List<object[]>();
if (startY > 0) {
    debug = map[startY - 1][startX];
    if (map[startY - 1][startX] == '7' || map[startY - 1][startX] == 'F' || map[startY - 1][startX] == '|')
    {
        temp[0] = startY - 1;
        temp[1] = startX;
        temp[2] = 'S';
        nextSteps.Add((object[])temp.Clone());
    } 
}
if (startY < map.Length - 1)
{
    debug = map[startY + 1][startX];
    if (map[startY + 1][startX] == 'J' || map[startY + 1][startX] == 'L' || map[startY + 1][startX] == '|')
    {
        temp[0] = startY + 1;
        temp[1] = startX;
        temp[2] =  'N';
        nextSteps.Add((object[])temp.Clone());
    }
}
if (startX > 0)
{
    debug = map[startY][startX - 1];
    if (map[startY][startX - 1] == 'L' || map[startY][startX - 1] == 'F' || map[startY][startX - 1] == '-')
    {

        temp[0] = startY;
        temp[1] = startX - 1;
        temp[2] = 'E';
        nextSteps.Add((object[])temp.Clone());
    }
}
if (startX < map.Length -1)
{
    debug = map[startY][startX + 1];
    if (map[startY][startX + 1] == '7' || map[startY][startX + 1] == 'J' || map[startY][startX + 1] == '-')
    {
        temp[0] = startY;
        temp[1] = startX + 1;
        temp[2] = 'W';
        nextSteps.Add((object[])temp.Clone());
    }
}

// Y, X, NESW
object[] directionOne = nextSteps[0];
object[] directionTwo = nextSteps[1];

if (task == 1)
{
    count = 1;
    while (!((int)nextSteps[0][0] == (int)nextSteps[1][0] && (int)nextSteps[0][1] == (int)nextSteps[1][1]))
    {
        directionOne = nextSteps[0];
        directionTwo = nextSteps[1];

        debug = map[(int)directionOne[0]][(int)directionOne[1]];
        Console.WriteLine(directionOne[1] + "," + directionOne[0] + " From " + directionOne[2] + " is " + debug);
        switch (directionOne[2])
        {
            case 'N':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == 'J')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'L')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '|')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'S':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == '7')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'F')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '|')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'E':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == 'F')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'L')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '-')
                {
                    temp[0] = (int)directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'W':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == '7')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'J')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '-')
                {
                    temp[0] = (int)directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            default:
                Console.WriteLine("Fuck: Invalid From");
                break;
        }

        debug = map[(int)directionTwo[0]][(int)directionTwo[1]];
        Console.WriteLine(directionTwo[1] + "," + directionTwo[0] + " From " + directionTwo[2] + " is " + debug);
        switch (directionTwo[2])
        {
            case "N":
                if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'J')
                {
                    temp[0] = directionTwo[0];
                    temp[1] = (int)directionTwo[1] - 1;
                    temp[2] = "E";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'L')
                {
                    temp[0] = directionTwo[0];
                    temp[1] = (int)directionTwo[1] + 1;
                    temp[2] = "W";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '|')
                {
                    temp[0] = (int)directionTwo[0] + 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "N";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case "S":
                if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '7')
                {
                    temp[0] = directionTwo[0];
                    temp[1] = (int)directionTwo[1] - 1;
                    temp[2] = "E";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'F')
                {
                    temp[0] = directionTwo[0];
                    temp[1] = (int)directionTwo[1] + 1;
                    temp[2] = "W";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '|')
                {
                    temp[0] = (int)directionTwo[0] - 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "S";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case "E":
                if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'F')
                {
                    temp[0] = (int)directionTwo[0] + 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "N";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'L')
                {
                    temp[0] = (int)directionTwo[0] - 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "S";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '-')
                {
                    temp[0] = (int)directionTwo[0];
                    temp[1] = (int)directionTwo[1] - 1;
                    temp[2] = "E";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case "W":
                if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '7')
                {
                    temp[0] = (int)directionTwo[0] + 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "N";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == 'J')
                {
                    temp[0] = (int)directionTwo[0] - 1;
                    temp[1] = (int)directionTwo[1];
                    temp[2] = "S";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else if (map[(int)directionTwo[0]][(int)directionTwo[1]] == '-')
                {
                    temp[0] = (int)directionTwo[0];
                    temp[1] = (int)directionTwo[1] + 1;
                    temp[2] = "W";
                    nextSteps[1] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            default:
                Console.WriteLine("Fuck: Invalid From");
                break;
        }
        count++;
    }
}



if (task == 2)
{
    while ( map[(int)nextSteps[0][1]][(int)nextSteps[0][0]] != 'S')
    {
        directionOne = nextSteps[0];

        // Y, X, NESW
        string tempKey = directionOne[0] + " " + directionOne[1];
        mappedLoop.Add(tempKey, (char)directionOne[2]);

        debug = map[(int)directionOne[0]][(int)directionOne[1]];
        //Console.WriteLine(directionOne[1] + "," + directionOne[0] + " From " + directionOne[2] + " is " + debug);
        switch (directionOne[2])
        {
            case 'N':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == 'J')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'L')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '|')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'S':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == '7')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'F')
                {
                    temp[0] = directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '|')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'E':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == 'F')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'L')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '-')
                {
                    temp[0] = (int)directionOne[0];
                    temp[1] = (int)directionOne[1] - 1;
                    temp[2] = 'E';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            case 'W':
                if (map[(int)directionOne[0]][(int)directionOne[1]] == '7')
                {
                    temp[0] = (int)directionOne[0] + 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'N';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == 'J')
                {
                    temp[0] = (int)directionOne[0] - 1;
                    temp[1] = (int)directionOne[1];
                    temp[2] = 'S';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else if (map[(int)directionOne[0]][(int)directionOne[1]] == '-')
                {
                    temp[0] = (int)directionOne[0];
                    temp[1] = (int)directionOne[1] + 1;
                    temp[2] = 'W';
                    nextSteps[0] = (object[])temp.Clone();
                }
                else
                {
                    Console.WriteLine("Fuck: invalid go to");
                }
                break;
            default:
                Console.WriteLine("Fuck: Invalid From");
                break;
        }

        map[(int)directionOne[0]] = map[(int)directionOne[0]].Remove((int)directionOne[1],1);
        map[(int)directionOne[0]] = map[(int)directionOne[0]].Insert((int)directionOne[1],"X");
    }
}

if (task == 1)
{
    Console.WriteLine(count);
}
else if (task == 2)
{
    found = false;
    while (!found)
    {
        /* debug
        foreach (KeyValuePair<int[],char> item in mappedLoop)
        {
            int x = item.Key[1];
            int y = item.Key[0];
            char dir = item.Value;

            Console.SetCursorPosition(x, y);
            Console.Write(dir);
        }
        Console.SetCursorPosition(0, Console.WindowHeight - 4);
        */
        int searchX = map[0].Length / 2;
        int j = -1;
        foundTwo = false;
        while (!foundTwo)
        {
            j++;
            if (map[j][searchX] == 'X' || map[j][searchX] == 'S')
            {
                foundTwo = true;
            }
            
        }

        // Y, X, NESW
        string key = j + " " + searchX;
        switch (mappedLoop[key])
        {
            case ('N'): // What?
                searchX++;
                break;
            case ('S'): // 7 or F
                searchX++;
                break;
            case ('E'):
                outside = 'R';
                found = true;
                break;
            case ('W'):
                outside = 'L';
                found = true;
                break;
            default:
                Console.WriteLine("Fuck: finding outside went wrong");
                break;

        }
    }


    // EVERYTHING WORKS UP TO HERE
    foreach (KeyValuePair<string,char> pipe in mappedLoop)
    {
        int y = Convert.ToInt32(pipe.Key.Split(" ")[0]);
        int x = Convert.ToInt32(pipe.Key.Split(" ")[1]);

        if (outside == 'R')
        { //inside is on the left at all times
            switch (pipe.Value)
            {
                case ('S'):
                    for (int k = x-1; k >= 0; k--)
                    {
                        if (map[y][k] == 'X' || map[y][k] == 'S')
                        {
                            break;
                        }
                        else if (map[y][k] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('N'):
                    for (int k = x+1; k < map[0].Length; k++)
                    {
                        if (map[y][k] == 'X' || map[y][k] == 'S')
                        {
                            break;
                        }
                        else if (map[y][k] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('E'):
                    for (int k = y+1; k < map.Length; k++)
                    {
                        if (map[k][x] == 'X' || map[k][x] == 'S')
                        {
                            break;
                        }
                        else if (map[k][x] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('W'):
                    for (int k = y-1; k >= 0; k--)
                    {
                        if (map[k][x] == 'X' || map[k][x] == 'S')
                        {
                            break;
                        }
                        else if (map[k][x] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Fuck: Im too tired for error messages, you know where this is");
                    break;
            }
        }
        else if (outside == 'L')
        { //inside is on the right at all times
            switch (pipe.Value)
            {
                case ('N'):
                    for (int k = x - 1; k >= 0; k--)
                    {
                        if (map[y][k] == 'X' || map[y][k] == 'S')
                        {
                            break;
                        }
                        else if (map[y][k] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('S'):
                    for (int k = x; k < map[0].Length; k++)
                    {
                        if (map[y][k] == 'X' || map[y][k] == 'S')
                        {
                            break;
                        }
                        else if (map[y][k] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('W'):
                    for (int k = y; k < map.Length; k++)
                    {
                        if (map[k][x] == 'X' || map[k][x] == 'S')
                        {
                            break;
                        }
                        else if (map[k][x] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                case ('E'):
                    for (int k = y; k >= 0; k--)
                    {
                        if (map[k][x] == 'X' || map[k][x] == 'S')
                        {
                            break;
                        }
                        else if (map[k][x] == '.')
                        {
                            count++;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Fuck: Im too tired for error messages, you know where this is");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Fuck: no outside found");
        }
    }
    //THE FUCKY WUCKY IS IN HERE
}
Console.WriteLine(count);
//task 2 must be less than 632
