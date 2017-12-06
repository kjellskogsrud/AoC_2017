using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2017.Days
{
    class Day06 : IDay
    {
        string[] inputFile;
        int[] memoryBanks = new int[16];
        

        public Day06()
        {
            inputFile = File.ReadAllLines("Inputs/Day06.txt");
            string[] stringBanks = inputFile[0].Split(' ');
            for (int i = 0; i < stringBanks.Length; i++)
            {
                int.TryParse(stringBanks[i], out memoryBanks[i]);
            }
        }
        public void Solve_Part1()
        {
            Solve_Part1(false);
        }

        public void Solve_Part1(bool suppressOutput)
        {
            List<string> states = new List<string>();
            // Add our initial state
            states.Add(IntArrayToString(memoryBanks));
            bool duplicateState = false;

            while (!duplicateState)
            {
                // Begin Cycle
                // Find large number
                int highBank = 0;
                int highBankBlocks = 0;
                for (int i = 0; i < memoryBanks.Length; i++)
                {
                    if(memoryBanks[i] > highBankBlocks)
                    {
                        highBank = i;
                        highBankBlocks = memoryBanks[i];
                    }
                }
                // Take all the blocks from the highbank
                memoryBanks[highBank] = 0;
                int nextBank = (highBank + 1 < 16) ? highBank + 1 : 0;
                while (highBankBlocks > 0)
                {
                    // put a block in the next bank
                    memoryBanks[nextBank]++;
                    highBankBlocks--;

                    // move to the next bank
                    nextBank = (nextBank + 1 < 16) ? nextBank + 1 : 0; 
                }

                // there is a new state, does it exist?
                if (!states.Contains(IntArrayToString(memoryBanks)))
                    states.Add(IntArrayToString(memoryBanks));
                else
                    duplicateState = true;
            }
            if (!suppressOutput)
            {
                Console.WriteLine("Duplicate State Found, the count of states is {0}", states.Count);
                Console.ReadLine();
            }

        }

        public void Solve_Part2()
        {
            Solve_Part1(true);
            Solve_Part1(false);
        }

        private string IntArrayToString(int[] array)
        {
            return String.Join(",", array);
        }
    }
}
