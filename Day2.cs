using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace AoC2024;

internal class Day2 : AocDay {
    public void Part1() {
        int counter = 0;

        foreach(string line in File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day2.txt")) {
            List<int> nums = line
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if(nums[0] == nums[1] || Math.Abs(nums[1] - nums[0]) < 1 || Math.Abs(nums[1] - nums[0]) > 3) {
                continue;
            }
            bool isAscending = nums[0] < nums[1];
            bool isValid = true;

            for(int i = 1; i < nums.Count - 1; i++) {
                if(Math.Abs(nums[i + 1] - nums[i]) > 3 ||
                    (isAscending && nums[i] >= nums[i + 1]) ||
                    (!isAscending && nums[i] <= nums[i + 1])) {
                    isValid = false;
                    break;
                }
            }

            if(isValid) {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }

    public void Part2() {
        int counter = 0;

        foreach(string line in File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day2.txt")) {
            List<int> nums = line
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if(nums[0] == nums[1] || Math.Abs(nums[1] - nums[0]) > 3) {
                List<int> newSequenceA = new(nums);
                newSequenceA.RemoveAt(0);
                List<int> newSequenceB = new(nums);
                newSequenceB.RemoveAt(1);
                if(IsSequenceValid(newSequenceA) || IsSequenceValid(newSequenceB)) {
                    counter++;
                }
                continue;
            }
            bool isAscending = nums[0] < nums[1];
            bool isValid = true;

            for(int i = 1; i < nums.Count - 1; i++) {
                if( Math.Abs(nums[i + 1] - nums[i]) > 3 ||
                    (isAscending && nums[i] >= nums[i + 1]) ||
                    (!isAscending && nums[i] <= nums[i + 1])) {

                    List<int> newSequenceA = new(nums);
                    newSequenceA.RemoveAt(i);
                    List<int> newSequenceB = new(nums);
                    newSequenceB.RemoveAt(i + 1);
                    isValid = IsSequenceValid(newSequenceA) || IsSequenceValid(newSequenceB);
                    break;
                }
            }

            if(isValid) {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }

    private bool IsSequenceValid(List<int> seq) {
        if(seq[0] == seq[1] || Math.Abs(seq[1] - seq[0]) > 3) {
            return false;
        }
        bool isAscending = seq[0] < seq[1];

        for(int i = 1; i < seq.Count - 1; i++) {
            if(Math.Abs(seq[i + 1] - seq[i]) > 3 ||
                (isAscending && seq[i] >= seq[i + 1]) ||
                (!isAscending && seq[i] <= seq[i + 1])) {
                return false;
            }
        }

        return true;
    }
}