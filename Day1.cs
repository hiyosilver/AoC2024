using System.Text;

namespace AoC2024;

internal class Day1 : AocDay {
    public void Part1() {
        List<int> listA = new();
        List<int> listB = new();
        using(var fileStream = File.OpenRead(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day1.txt")) {
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                String line;
                while((line = streamReader.ReadLine()) != null) {
                    int[] nums = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    listA.Add(nums[0]);
                    listB.Add(nums[1]);
                }
            }
        }
        listA = listA.Order().ToList();
        listB = listB.Order().ToList();

        int diffSum = 0;
        for(int i = 0; i < listA.Count; i++) {
            diffSum += Math.Abs(listA[i] - listB[i]);
        }
        Console.WriteLine(diffSum);
    }

    public void Part2() {
        List<int> listA = new();
        Dictionary<int, int> rightSideCounts = new();
        using(var fileStream = File.OpenRead(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day1.txt")) {
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                String line;
                while((line = streamReader.ReadLine()) != null) {
                    int[] nums = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    listA.Add(nums[0]);
                    if(rightSideCounts.ContainsKey(nums[1])) {
                        rightSideCounts[nums[1]]++;
                    }
                    else {
                        rightSideCounts[nums[1]] = 1;
                    }
                }
            }
        }

        int similarityScore = 0;
        foreach(int num in listA) {
            if(rightSideCounts.TryGetValue(num, out int count)) {
                similarityScore += num * count;
            }
        }
        Console.WriteLine(similarityScore);
    }
}