namespace AoC2024;

internal class Day10 : AocDay
{
    public void Part1()
    {
        long sum = 0;
        
        int[][] grid = [.. File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day10.txt").Select(x => x.ToCharArray().Select(y => int.Parse(y.ToString())).ToArray())];
        HashSet<int>[][] trailheads = new HashSet<int>[grid.Length][];
        for(int n = 0; n < trailheads.Length; n++) {
            trailheads[n] = new HashSet<int>[grid[n].Length];
            for(int m = 0; m < trailheads[n].Length; m++) {
                trailheads[n][m] = [];
            }
        }

        int id = 0;
        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                int num = grid[row][col];
                if(num != 9) {
                    continue;
                }
                trailheads[row][col].Add(id++);
            }
        }

        for(int i = 8; i >= 0; i--) {
            for(int row = 0; row < grid.Length; row++) {
                for(int col = 0; col < grid[row].Length; col++) {
                    int num = grid[row][col];
                    if(num != i) {
                        continue;
                    }
                    if(row > 0 && grid[row - 1][col] == num + 1) {
                        trailheads[row][col].UnionWith(trailheads[row - 1][col]);
                    }
                    if(col > 0 && grid[row][col - 1] == num + 1) {
                        trailheads[row][col].UnionWith(trailheads[row][col - 1]);
                    }
                    if(row < grid.Length - 1 && grid[row + 1][col] == num + 1) {
                        trailheads[row][col].UnionWith(trailheads[row + 1][col]);
                    }
                    if(col < grid[row].Length - 1 && grid[row][col + 1] == num + 1) {
                        trailheads[row][col].UnionWith(trailheads[row][col + 1]);
                    }
                    if(num == 0) {
                        sum += trailheads[row][col].Count;
                    }
                }
            }
        }

        Console.WriteLine(sum);
    }

    public void Part2()
    {
        int sum = 0;

        int[][] grid = [.. File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day10.txt").Select(x => x.ToCharArray().Select(y => int.Parse(y.ToString())).ToArray())];
        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                int num = grid[row][col];
                if(num != 0) {
                    continue;
                }
                foreach(var validTrail in GetValidTrails(grid, (row, col), 0)) {
                    if(validTrail) {
                        sum++;
                    }
                }
            }
        }

        Console.WriteLine(sum);
    }

    readonly (int, int)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

    private IEnumerable<bool> GetValidTrails(int[][] grid, (int X, int Y) position, int currentHeight) {
        if(currentHeight == 9) {
            yield return true;
        }
        foreach((int X, int Y) dir in directions) {
            (int X, int Y) newPosition = (position.X + dir.X, position.Y + dir.Y);

            if( newPosition.X < 0 || newPosition.X >= grid.Length || 
                newPosition.Y < 0 || newPosition.Y >= grid[newPosition.X].Length ||
                currentHeight + 1 != grid[newPosition.X][newPosition.Y]) {
                continue;
            }

            foreach(bool res in GetValidTrails(grid, newPosition, currentHeight + 1)) {
                yield return res;
            }
        }
        yield break;
    }
}