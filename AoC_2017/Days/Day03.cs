using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2017.Days
{
    class Day03 : IDay
    {
        int input = 0;

        public Day03()
        {
            string[] fileInput = File.ReadAllLines("Inputs/Day03.txt");
            int.TryParse(fileInput[0], out input);
        }
        

        // A list to store the coords for part 2
        Dictionary<string, int> spiralCords = new Dictionary<string, int>();
        public void Solve_Part1()
        {
            int cornerNumber = 1;
            int incrementNumber = 8;
            int currentRing = 0;
            int currentRingSide = 1;
            int lastRing = 0;
            while(cornerNumber < input)
            {
                cornerNumber += incrementNumber;
                lastRing = currentRing;
                currentRing++;
                incrementNumber += 8;
                currentRingSide += 2;
            }

            bool foundIt = false;

            int x = currentRing;
            int y = currentRing * -1;
            int startX = x;
            int startY = y;
            int thisNumber = cornerNumber;

            Console.WriteLine("Stopped at ring number {0}.", currentRing);
            Console.WriteLine("The number is {0} less than the current corner number.", cornerNumber - input);
            Console.WriteLine("This ring has a side of {0}", currentRingSide);

            // Walk left looking for our number
            while(x != startX * -1)
            {
                x--;
                thisNumber--;

                if (thisNumber == input)
                {
                    foundIt = true;
                    break;
                }
            }
            Console.WriteLine("We walked left to {0},{1}", x, y);
            cornerNumber = thisNumber;            
            Console.WriteLine("The number is {0} less than the current corner number.", cornerNumber - input);
            if (!foundIt)
            {
                // We walk up
                while (y != startY * -1)
                {
                    y++;
                    thisNumber--;
                    if (thisNumber == input)
                    {
                        foundIt = true;
                        break;
                    }
                }
            }
            Console.WriteLine("We walked up to {0},{1}", x, y);
            cornerNumber = thisNumber;
            Console.WriteLine("The number is {0} less than the current corner number.", cornerNumber - input);
            startX = x;
            if (!foundIt)
            {
                // We walk right
                while (x != startX * -1)
                {
                    x++;
                    thisNumber--;

                    if (thisNumber == input)
                    {
                        foundIt = true;
                        break;
                    }
                }
            }
            Console.WriteLine("We walked right to {0},{1}", x,y);
            Console.WriteLine("The current number is {0}, and we wanted {1}", thisNumber, input);
            Console.WriteLine("Manhattan Distance to 1 is {0}",Math.Abs(x)+Math.Abs(y));
            Console.ReadLine();
        }

        public void Solve_Part2()
        {
            // We begin in 0,0
            int x = 0;
            int y = 0;
            spiralCords.Clear();
            spiralCords.Add("0,0", 1);

            // We then set the current and target value
            int currentValue = 0;   // this is zero because we calculate at each step and we have not begun yet.
            int targetValue = input;

            // loop time!
            // move to the first square in the new ring now
            
            int nthRing = 1;
            int cornerbox = 1;
            bool foundIt = false;
            while (!foundIt)
            {
                cornerbox += (8 * nthRing);
                int ringWidth = (int)Math.Sqrt(cornerbox);
                x++;
                // move up in y
                for (int i = 0; i < ringWidth -2; i++)
                {
                    currentValue = CalculateNewValue(x, y);
                    spiralCords.Add(MakeCordString(x,y), currentValue);
                    y++;
                    if (currentValue > targetValue)
                    {
                        foundIt = true;
                        break;
                    }
                }
                if (!foundIt)
                {
                    // move left in x
                    for (int i = 0; i < ringWidth - 1; i++)
                    {
                        currentValue = CalculateNewValue(x, y);
                        spiralCords.Add(MakeCordString(x, y), CalculateNewValue(x, y));
                        x--;
                        if (currentValue > targetValue)
                        {
                            foundIt = true;
                            break;
                        }
                    }
                }
                if (!foundIt)
                {
                    // move down in y
                    for (int i = 0; i < ringWidth-1; i++)
                    {
                        currentValue = CalculateNewValue(x, y);
                        spiralCords.Add(MakeCordString(x, y), CalculateNewValue(x, y));
                        y--;
                        if (currentValue > targetValue)
                        {
                            foundIt = true;
                            break;
                        }
                    }
                }
                if (!foundIt)
                {
                    // move right in x
                    for (int i = 0; i < ringWidth-1; i++)
                    {
                        currentValue = CalculateNewValue(x, y);
                        spiralCords.Add(MakeCordString(x, y), CalculateNewValue(x, y));
                        x++;
                        if (currentValue > targetValue)
                        {
                            foundIt = true;
                            break;
                        }
                    }
                }
                if(!foundIt)
                {
                    currentValue = CalculateNewValue(x, y);
                    spiralCords.Add(MakeCordString(x, y), CalculateNewValue(x, y));
                }
                nthRing++;
            }

            // Once the loop is done we have the current value
            Console.WriteLine("The first value written that is larger than {0} is {1}", targetValue, currentValue);

            Console.ReadLine();
        }
        private string MakeCordString(int x, int y)
        {
            return x + "," + y;
        }

        private int CalculateNewValue(int x, int y)
        {
            string[] possibleCords = new string[8];
            possibleCords[0] = MakeCordString(x+1, y);
            possibleCords[1] = MakeCordString(x+1, y+1);
            possibleCords[2] = MakeCordString(x, y + 1);
            possibleCords[3] = MakeCordString(x-1, y+1);
            possibleCords[4] = MakeCordString(x-1, y);
            possibleCords[5] = MakeCordString(x-1, y-1);
            possibleCords[6] = MakeCordString(x, y-1);
            possibleCords[7] = MakeCordString(x+1, y-1);

            int newValue = 0;
            for (int i = 0; i < possibleCords.Length; i++)
            {
                if (spiralCords.ContainsKey(possibleCords[i]))
                    newValue += spiralCords[possibleCords[i]];
            }

            return newValue;
        }
    }

    
}
