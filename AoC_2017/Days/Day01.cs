using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC_2017.Days
{
    class Day01 : IDay
    {
        string[] inputFile;

        public Day01()
        {
            inputFile = File.ReadAllLines("Inputs/Day01.txt");
        }

        public void Solve_Part1()
        {
            char[] theString = inputFile[0].ToCharArray();

            int theSum = 0;
            for (int i = 0; i < theString.Length; i++)
            {
                int checkNext = 0;
                if (i != theString.Length - 1)
                {
                    checkNext = i+1;
                }
                int thisInt = int.Parse(theString[i].ToString());
                int nextInt = int.Parse(theString[checkNext].ToString());
                if(thisInt == nextInt)
                {
                    theSum = theSum + thisInt;
                }
            }

            Console.WriteLine("The captcha sum is: {0}", theSum);
            Console.ReadLine();
        }
        public void Solve_Part2()
        {
            char[] theString = inputFile[0].ToCharArray();

            int theSum = 0;
            for (int i = 0; i < theString.Length; i++)
            {
                int theHalfStep = theString.Length / 2;

                int checkNext = (i + theHalfStep) % theString.Length;

                int thisInt = int.Parse(theString[i].ToString());
                int nextInt = int.Parse(theString[checkNext].ToString());
                if (thisInt == nextInt)
                {
                    theSum = theSum + thisInt;
                }
            }

            Console.WriteLine("The captcha sum is: {0}", theSum);
            Console.ReadLine();

        }


    }
}
