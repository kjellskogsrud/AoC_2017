using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC_2017.Days;

namespace AoC_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDay> AdventDays = new List<IDay>();

            AdventDays.Add(new Day01());
            AdventDays.Add(new Day02());
            AdventDays.Add(new Day03());
            AdventDays.Add(new Day04());
            AdventDays.Add(new Day05());
            AdventDays.Add(new Day06());

            IDay SelectedDay = null;
            int SelectedPart = 0;

            if (AdventDays.Count > 0)
            {
                while (true)
                {
                    while (SelectedDay == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Choose day to solve: \n");
                        for (int i = 0; i < AdventDays.Count; i++)
                        {
                            Console.WriteLine("[{0}] - {1}", i, AdventDays[i].ToString());
                        }
                        string input = Console.ReadLine();
                        if(input!= null || input != "")
                        {
                            int TrySelectedDay;
                            int.TryParse(input, out TrySelectedDay);
                            if( TrySelectedDay <= AdventDays.Count && TrySelectedDay >= 0)
                            {
                                SelectedDay = AdventDays[TrySelectedDay];
                            }
                        }
                    }
                    while (SelectedPart != 1 && SelectedPart != 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Choose what part to solve: \n");
                        Console.WriteLine("[1] - Part 1");
                        Console.WriteLine("[2] - Part 2");

                        string input = Console.ReadLine();
                        if (input != null || input != "")
                        {
                            int TrySelectedPart;
                            int.TryParse(input, out TrySelectedPart);
                            if (TrySelectedPart == 1 || TrySelectedPart == 2)
                            {
                                SelectedPart = TrySelectedPart;
                            }
                        }
                    }
                    Console.Clear();
                    switch (SelectedPart)
                    {
                        case 1:
                            SelectedDay.Solve_Part1();
                            break;
                        case 2:
                            SelectedDay.Solve_Part2();
                            break;
                        default:
                            break;
                    }
                    SelectedDay = null;
                    SelectedPart = 0;
                }
            }
        }
    }
}
