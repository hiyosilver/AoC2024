namespace AoC2024;

internal class Day5 : AocDay
{
    
    public void Part1()
    {
        int sum = 0;

        List<string> input = [.. File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day5.txt")];
        Dictionary<int, List<int>> orderingRules = new();
        bool orderingRulesRead = false;

        foreach(string line in input) {
            if(line == string.Empty) {
                orderingRulesRead = true;
                continue;
            }
            if(!orderingRulesRead) {
                int[] rule = line.Split('|').Select(int.Parse).ToArray();
                if(orderingRules.TryGetValue(rule[0], out List<int> pages)) {
                    pages.Add(rule[1]);
                }
                else {
                    orderingRules[rule[0]] = new List<int>() { rule[1] };
                }
            }
            else {
                bool isValid = true;
                int[] update = line.Split(',').Select(int.Parse).ToArray();

                for(int i = 0; i < update.Length - 1; i++) {
                    for(int j = i + 1; j < update.Length; j++) {
                        if(orderingRules.TryGetValue(update[j], out List<int> pages)) {
                            if(pages.Contains(update[i])) {
                                isValid = false;
                                break;
                            }
                        }
                    }
                    if(!isValid) {
                        break;
                    }
                }

                if(isValid) {
                    sum += update[update.Length / 2];
                }
            }
        }

        Console.WriteLine(sum);
    }

    public void Part2()
    {

    }
}