namespace AoC2024;

internal class Day12 : AocDay
{
    public void Part1()
    {
        int sum = 0;

        char[][] grid = [.. File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day12.txt").Select(x => x.ToCharArray())];
        HashSet<(int, int)> visited = [];

        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                if(visited.Contains((row, col))) {
                    continue;
                }
                char currentChar = grid[row][col];
                int perimeter = 0;
                int area = 0;
                Stack<(int, int)> plot = [];
                plot.Push((row, col));
                while(plot.Count > 0) {
                    (int X, int Y) current = plot.Pop();
                    if(visited.Contains(current)) {
                        continue;
                    }
                    visited.Add(current);
                    List<(int X, int Y)> neighbours = GetNeighbours(grid, current.X, current.Y);
                    perimeter += 4 - neighbours.Count(n => grid[n.X][n.Y] == currentChar);
                    area++;
                    
                    foreach(var coords in neighbours.Where(n => grid[n.X][n.Y] == currentChar && !visited.Contains(n))) {
                        plot.Push(coords);
                    }
                }
                sum += area * perimeter;
            }
        }

        Console.WriteLine(sum);
    }

    public List<(int, int)> GetNeighbours(char[][] grid, int row, int col) {
        List<(int, int)> res = [];

        if(row > 0) {
            res.Add((row - 1, col));
        }
        if(col > 0) {
            res.Add((row, col - 1));
        }
        if(row < grid.Length - 1) {
            res.Add((row + 1, col));
        }
        if(col < grid[row].Length - 1) {
            res.Add((row, col + 1));
        }

        return res;
    }

    public void Part2()
    {
    }
}