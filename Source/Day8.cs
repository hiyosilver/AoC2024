using System.Diagnostics.Metrics;

namespace AoC2024;

internal class Day8 : AocDay
{
    public void Part1()
    {
        HashSet<(int, int)> antinodes = new();
        Dictionary<char, List<(int, int)>> antennae = new();

        string[] lines = File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day8.txt").ToArray();
        for(int row = 0; row < lines.Length; row++) {
            for(int col = 0; col < lines[row].Length; col++) {
                if(lines[row][col] == '.') {
                    continue;
                }
                if (antennae.TryGetValue(lines[row][col], out List<(int, int)> positions)) {
                    foreach((int Row, int Col) previous in positions) {
                        int rowDiff = row - previous.Row;
                        int colDiff = col - previous.Col;

                        (int Row, int Col) antinodeA = (row + rowDiff, col + colDiff);
                        if(antinodeA.Row >= 0 && antinodeA.Row < lines.Length &&
                            antinodeA.Col >= 0 && antinodeA.Col < lines[antinodeA.Row].Length) {
                            antinodes.Add(antinodeA);
                        }

                        (int Row, int Col) antinodeB = (previous.Row - rowDiff, previous.Col - colDiff);
                        if (antinodeB.Row >= 0 && antinodeB.Row < lines.Length &&
                            antinodeB.Col >= 0 && antinodeB.Col < lines[antinodeB.Row].Length) {
                            antinodes.Add(antinodeB);
                        }
                    }
                    positions.Add((row, col));
                }
                else {
                    antennae[lines[row][col]] = new() { (row, col) };
                }
            }
        }

        Console.WriteLine(antinodes.Count);
    }

    public void Part2()
    {
        HashSet<(int, int)> antinodes = new();
        Dictionary<char, List<(int, int)>> antennae = new();

        string[] lines = File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day8.txt").ToArray();
        for (int row = 0; row < lines.Length; row++) {
            for (int col = 0; col < lines[row].Length; col++) {
                if (lines[row][col] == '.') {
                    continue;
                }
                if (antennae.TryGetValue(lines[row][col], out List<(int, int)> positions)) {
                    foreach ((int Row, int Col) previous in positions) {
                        int rowDiff = row - previous.Row;
                        int colDiff = col - previous.Col;

                        (int Row, int Col) antinodeA = (row + rowDiff, col + colDiff);
                        while (antinodeA.Row >= 0 && antinodeA.Row < lines.Length &&
                            antinodeA.Col >= 0 && antinodeA.Col < lines[antinodeA.Row].Length) {
                            antinodes.Add(antinodeA);
                            antinodeA = (antinodeA.Row - rowDiff, antinodeA.Col - colDiff);
                        }

                        (int Row, int Col) antinodeB = (previous.Row - rowDiff, previous.Col - colDiff);
                        while (antinodeB.Row >= 0 && antinodeB.Row < lines.Length &&
                            antinodeB.Col >= 0 && antinodeB.Col < lines[antinodeB.Row].Length) {
                            antinodes.Add(antinodeB);
                            antinodeB = (antinodeB.Row - rowDiff, antinodeB.Col - colDiff);
                        }
                    }
                    positions.Add((row, col));
                }
                else {
                    antennae[lines[row][col]] = new() { (row, col) };
                }
            }
        }

        Console.WriteLine(antinodes.Count);
    }
}