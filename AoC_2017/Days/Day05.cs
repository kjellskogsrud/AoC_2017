using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2017.Days
{
    class Day05 : IDay
    {
        int[] JumpInstructions;
        public Day05()
        {
            string[] inputFromFile = File.ReadAllLines("Inputs/Day05.txt");
            JumpInstructions = new int[inputFromFile.Length];
            for (int i = 0; i < inputFromFile.Length; i++)
            {
                int.TryParse(inputFromFile[i], out JumpInstructions[i]);
            }
        }
        public void Solve_Part1()
        {
            int jumpsMade = 0;
            try
            {
                int currentIndex = 0;
                int nextIndex = 0;
                while (true)
                {
                    nextIndex = currentIndex + JumpInstructions[currentIndex];
                    JumpInstructions[currentIndex]++;
                    currentIndex = nextIndex;
                    jumpsMade++;
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("We jumped {0} times to get out of range", jumpsMade);
                Console.ReadLine();
            }
        }

        public void Solve_Part2()
        {
            int jumpsMade = 0;
            try
            {
                int currentIndex = 0;
                int nextIndex = 0;
                while (true)
                {
                    nextIndex = currentIndex + JumpInstructions[currentIndex];
                    if (JumpInstructions[currentIndex] >= 3)
                        JumpInstructions[currentIndex]--;
                    else
                        JumpInstructions[currentIndex]++;
                    currentIndex = nextIndex;
                    jumpsMade++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("We jumped {0} times to get out of range", jumpsMade);
                Console.ReadLine();
            }
        }
    }
}
