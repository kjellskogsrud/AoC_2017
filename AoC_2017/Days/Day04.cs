using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2017.Days
{
    class Day04 : IDay
    {
        string[] passphrasesFromFile;
        List<string> UnsortedValidNonDuplicate = new List<string>();

        public Day04()
        {
            passphrasesFromFile = File.ReadAllLines("Inputs/Day04.txt");
        }

        public void Solve_Part1()
        {
            Solve_Part1(passphrasesFromFile, false, out UnsortedValidNonDuplicate);
        }
        private void Solve_Part1(string[] passphraselist, bool suppressoutput, out List<string> outputList)
        {
            List<string> internalOutputList = new List<string>();
            for (int i = 0; i < passphraselist.Length; i++)
            {
                bool isValid = true;
                string[] wordsInPhrase = passphraselist[i].Split(' ');
                for (int j = 0; j < wordsInPhrase.Length; j++)
                {
                    for (int k = 0; k < wordsInPhrase.Length; k++)
                    {
                        if (k != j && wordsInPhrase[k] == wordsInPhrase[j])
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                    internalOutputList.Add(passphraselist[i]);
                    
            }
            if (!suppressoutput)
            {
                Console.WriteLine("There are {0} valid passphrases in the list", internalOutputList.Count);
                Console.ReadLine();
            }
            outputList = internalOutputList;
        }

        public void Solve_Part2()
        {
            List<string> ValidByPartOneCriteria = new List<string>();
            Solve_Part1(passphrasesFromFile,true, out ValidByPartOneCriteria);

            string[] sortedValidPhrasesFromPart1 = new string[ValidByPartOneCriteria.Count];

            for (int i = 0; i < sortedValidPhrasesFromPart1.Length; i++)
            {
                string[] words = ValidByPartOneCriteria[i].Split(' ');
                string[] sortedWords = words;
                for (int j = 0; j < words.Length; j++)
                {
                    sortedWords[j] = String.Concat(words[j].OrderBy(c => c));
                }
                sortedValidPhrasesFromPart1[i] = String.Join(" ", sortedWords);
            }
            List<string> ValidByPartTwoCriteria = new List<string>();
            Solve_Part1(sortedValidPhrasesFromPart1, false, out ValidByPartTwoCriteria);
        }
    }
}
