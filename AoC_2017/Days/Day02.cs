using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC_2017.Days
{
    class Day02 : IDay
    {
        string[] inputFile;
        int[,] spreadsheet;

        int rows;
        int colums;
        public Day02()
        {
            inputFile = File.ReadAllLines("Inputs/Day02.txt");

            // Make multidim Array
            rows = inputFile.Length;

            // This assumes that ther are an equal number of rows
            colums = inputFile[0].Split(' ').Length;

            spreadsheet = new int[colums, rows];

            for (int i = 0; i < rows; i++)
            {
                string[] inputRow = inputFile[i].Split(' ');
                for (int j = 0; j < inputRow.Length; j++)
                {
                    spreadsheet[i, j] = int.Parse(inputRow[j]);
                } 
            }

        }

        private int[,] BubbelSort(int[,] spreadsheet)
        {
            int[,] lastArray = spreadsheet;
      

            for (int i = 0; i < lastArray.GetLength(0); i++)
            {
                bool swaps = true;
                while (swaps)
                {
                    swaps = false;
                    for (int j = 1; j < lastArray.GetLength(1); j++)
                    {
                        if( lastArray[i,j-1] > lastArray[i,j])
                        {
                            int big = lastArray[i, j - 1];
                            lastArray[i, j - 1] = lastArray[i, j];
                            lastArray[i, j] = big;
                            swaps = true;
                        }
                    }
                }
            }
    
            return lastArray;
        }

        public void Solve_Part1()
        {
            int[,] sortedSpreadSheet = BubbelSort(spreadsheet);
            // Evaluating the Checksum, this expects the input to be sorted.
            int checksum = 0;
            for (int i = 0; i < sortedSpreadSheet.GetLength(0); i++)
            {
                checksum = checksum + (sortedSpreadSheet[i,sortedSpreadSheet.GetLength(1) -1] - sortedSpreadSheet[i, 0]);
            }
            Console.WriteLine("The Checksum is: {0}", checksum);
            Console.ReadLine();
        }
        public void Solve_Part2()
        {
            int checksum = 0;
            for (int i = 0; i < spreadsheet.GetLength(0); i++)
            {
                bool divFound = false;
                for (int j = 0; j < spreadsheet.GetLength(1); j++)
                {
                    if (divFound)
                        break;

                    for (int k = 0; k < spreadsheet.GetLength(1); k++)
                    {
                        if (j != k)
                        {
                            if(spreadsheet[i,j] % spreadsheet[i,k] == 0)
                            {
                                checksum = checksum + (spreadsheet[i, j] / spreadsheet[i, k]);
                                divFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("The Checksum is: {0}", checksum);
            Console.ReadLine();

        }

        


    }
}
