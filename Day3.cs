using System.Text.RegularExpressions;

namespace AoC2024;

internal class Day3 : AocDay {
    public void Part1() {
        int product = 0;
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        string fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day3.txt");

        foreach(Match match in Regex.Matches(fileContent, pattern)) {
            int first = int.Parse(match.Groups[1].Value);
            int second = int.Parse(match.Groups[2].Value);
            product += first * second;
        }

        Console.WriteLine(product);
    }

    public void Part2() {
        int product = 0;
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\)";
        string fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day3.txt");

        bool isEnabled = true;
        foreach (Match match in Regex.Matches(fileContent, pattern)) {
            switch(match.Value) {
                case "don't()":
                    isEnabled = false;
                    break;
                case "do()":
                    isEnabled = true;
                    break;
                default:
                    if(isEnabled) {
                        int first = int.Parse(match.Groups[1].Value);
                        int second = int.Parse(match.Groups[2].Value);
                        product += first * second;
                    }
                    break;
            }
        }

        Console.WriteLine(product);
    }
}