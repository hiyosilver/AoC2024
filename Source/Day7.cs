using System.Diagnostics.Metrics;

namespace AoC2024;

internal class Day7 : AocDay
{
    
    public void Part1()
    {
        long sum = 0;

        foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day7.txt")) {
            string[] lineParts = line.Split(' ', 2);
            long result = long.Parse(new string(lineParts[0].SkipLast(1).ToArray()));
            long[] values = lineParts[1].Split().Select(long.Parse).ToArray();

            if(GetResult(values, string.Empty).Any(x => x == result)) {
                sum += result;
            }
        }

        Console.WriteLine(sum);
    }

    public IEnumerable<long> GetResult(long[] values, string operators) {
        if(operators.Length > values.Length - 1) {
            yield break;
        }
        if(operators.Length == values.Length - 1) {
            long res = values[0];
            for(int i = 1; i < values.Length; i++) {
                if (operators[i - 1] == '+') {
                    res += values[i];
                }
                else {
                    res *= values[i];
                }
            }
            yield return res;
        }
        foreach(long res in GetResult(values, operators + "+")) {
            yield return res;
        }
        foreach (long res in GetResult(values, operators + "*")) {
            yield return res;
        }
    }

    public void Part2()
    {
        long sum = 0;

        foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day7.txt")) {
            string[] lineParts = line.Split(' ', 2);
            long result = long.Parse(new string(lineParts[0].SkipLast(1).ToArray()));
            long[] values = lineParts[1].Split().Select(long.Parse).ToArray();

            if (GetResultNew(values, string.Empty).Any(x => x == result)) {
                sum += result;
            }
        }

        Console.WriteLine(sum);
    }

    public IEnumerable<long> GetResultNew(long[] values, string operators) {
        if (operators.Length > values.Length - 1) {
            yield break;
        }
        if (operators.Length == values.Length - 1) {
            long res = values[0];
            for (int i = 1; i < values.Length; i++) {
                if (operators[i - 1] == '+') {
                    res += values[i];
                }
                else if(operators[i - 1] == '*') {
                    res *= values[i];
                }
                else {
                    res = long.Parse(res.ToString() + values[i].ToString());
                }
            }
            yield return res;
        }
        foreach (long res in GetResultNew(values, operators + "+")) {
            yield return res;
        }
        foreach (long res in GetResultNew(values, operators + "*")) {
            yield return res;
        }
        foreach (long res in GetResultNew(values, operators + "|")) {
            yield return res;
        }
    }
}