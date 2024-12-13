namespace AoC2024;

internal class Day11 : AocDay
{
    public void Part1()
    {
        List<long> stones = [.. File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day11.txt").Split().Select(long.Parse)];
        
        for(int i = 0; i < 25; i++) {
            Console.WriteLine($"i: {i}");
            for(int n = 0; n < stones.Count; n++) {
                if(stones[n] == 0) {
                    stones[n] = 1;
                }
                else if(stones[n].ToString().Length % 2 == 0) {
                    string numString = stones[n].ToString();
                    stones[n] = long.Parse(numString[..(numString.Length / 2)]);
                    stones.Insert(n + 1, long.Parse(numString[(numString.Length / 2)..]));
                    n++;
                }
                else {
                    stones[n] *= 2024;
                }
            }
        }

        Console.WriteLine(stones.Count);
    }

    public void Part2()
    {
    }
}