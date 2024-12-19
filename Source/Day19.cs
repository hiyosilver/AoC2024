using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AoC2024;

internal class Day19 : AocDay
{
    private string[] availablePatterns = [];

    public void Part1()
    {
        int count = 0;

        string[] input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day19.txt").Split("\r\n\r\n");
        availablePatterns = input[0].Split(", ");
        string[] desiredDesigns = input[1].Split("\r\n");

        foreach (string design in desiredDesigns) {
            if (CheckDesign(design).Any(x => x == true)) {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    private IEnumerable<bool> CheckDesign(string design) {
        foreach (string pattern in availablePatterns) {
            if(pattern == design) {
                yield return true;
            }
            if(pattern.Length > design.Length) {
                continue;
            }
            if(Enumerable.Range(0, pattern.Length).All(x => pattern[x] == design[x])) {
                yield return CheckDesign(design[pattern.Length..]).Any(x => x == true);
            }
        }
        yield return false;
    }

    public void Part2(){
        int count = 0;

        string[] input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day19.txt").Split("\r\n\r\n");
        availablePatterns = input[0].Split(", ");
        string[] desiredDesigns = input[1].Split("\r\n");

        foreach (string design in desiredDesigns) {
            foreach (bool res in CheckAllDesigns(design)) {
                if(res) { count++; }
            }
        }

        Console.WriteLine(count);
    }

    private IEnumerable<bool> CheckAllDesigns(string design) {
        foreach (string pattern in availablePatterns) {
            if (pattern == design) {
                yield return true;
            }
            if (pattern.Length > design.Length) {
                continue;
            }
            if (Enumerable.Range(0, pattern.Length).All(x => pattern[x] == design[x])) {
                foreach(bool res in CheckAllDesigns(design[pattern.Length..])) {
                    yield return res;
                }
            }
        }
        yield return false;
    }
}