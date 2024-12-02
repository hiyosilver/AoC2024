using System.Diagnostics;
using System.Text;

namespace AoC2024;

internal class Day2 : AocDay {
    public void Part1() {
        int counter = 0;
        using(var fileStream = File.OpenRead(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day2.txt")) {
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                String line;
                while((line = streamReader.ReadLine()) != null) {
                    int[] nums = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    
                    if (nums[0] == nums[1] || Math.Abs(nums[1] - nums[0]) < 1 || Math.Abs(nums[1] - nums[0]) > 3) {
                        continue;
                    }
                    bool isAscending = nums[0] < nums[1];
                    bool isValid = true;

                    for(int i = 1; i < nums.Length - 1; i++) {
                        if( Math.Abs(nums[i + 1] - nums[i]) > 3 ||
                            isAscending && nums[i] >= nums[i + 1] ||
                            !isAscending && nums[i] <= nums[i + 1]) {
                            isValid = false;
                            break;
                        }
                    }

                    if(isValid) {
                        counter++;
                    }
                }
            }
        }
        Console.WriteLine(counter);
    }

    public void Part2() {
        
    }
}