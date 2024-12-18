﻿namespace AoC2024;
internal class Program
{
    static void Main(string[] args)
    {
        List<AocDay> daysToCalc = new() {
            //new Day1(),
            //new Day2(),
            //new Day3(),
            //new Day4(),
            //new Day5(),
            //new Day6(),
            //new Day7(),
            //new Day8(),
            //new Day9(),
            //new Day10(),
            //new Day11(),
            //new Day12(),
            //new Day13(),
            //new Day14(),
            //new Day15(),
            //new Day17(),
            new Day19(),
        };

        foreach (AocDay day in daysToCalc)
        {
            Console.WriteLine("╔═════╗");
            Console.WriteLine($"║{day.GetType().Name} ║");
            Console.WriteLine("╚═════╝");
            Console.WriteLine("Part1--------------------------------------------");
            day.Part1();
            Console.WriteLine("Part2--------------------------------------------");
            day.Part2();
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
