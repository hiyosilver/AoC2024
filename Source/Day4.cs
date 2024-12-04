namespace AoC2024;

internal class Day4 : AocDay
{
    

    public void Part1()
    {
        (int, int)[] _directions = [
            (-1, -1), (-1, 0), (-1, 1),
            ( 0, -1),          ( 0, 1),
            ( 1, -1), ( 1, 0), ( 1, 1)
        ];

        int counter = 0;

        List<char[]> grid = new();
        foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day4.txt"))
        {
            grid.Add(line.ToCharArray());
        }

        for(int row = 0; row < grid.Count; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                char current = grid[row][col];
                if(current != 'X') {
                    continue;
                }
                foreach((int X, int Y) dir in _directions) {
                    int newRow = row + dir.X;
                    int newCol = col + dir.Y;
                    if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || grid[newRow][newCol] != 'M') {
                        continue;
                    }
                    newRow += dir.X;
                    newCol += dir.Y;
                    if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || grid[newRow][newCol] != 'A') {
                        continue;
                    }
                    newRow += dir.X;
                    newCol += dir.Y;
                    if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || grid[newRow][newCol] != 'S') {
                        continue;
                    }
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }

    public void Part2()
    {
        int counter = 0;

        List<char[]> grid = new();
        foreach(string line in File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day4.txt")) {
            grid.Add(line.ToCharArray());
        }

        for(int row = 0; row < grid.Count; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                char current = grid[row][col];
                if(current != 'A') {
                    continue;
                }

                int newRow = row - 1;
                int newCol = col - 1;

                if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || (grid[newRow][newCol] != 'M' && grid[newRow][newCol] != 'S')) {
                    continue;
                }

                char topLeft = grid[newRow][newCol];

                newRow = row + 1;
                newCol = col + 1;

                if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || (grid[newRow][newCol] != 'M' && grid[newRow][newCol] != 'S')) {
                    continue;
                }

                char bottomRight = grid[newRow][newCol];

                if(!((topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M'))) {
                    continue;
                }

                newRow = row - 1;
                newCol = col + 1;

                if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || (grid[newRow][newCol] != 'M' && grid[newRow][newCol] != 'S')) {
                    continue;
                }

                char topRight = grid[newRow][newCol];

                newRow = row + 1;
                newCol = col - 1;

                if(newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Length || (grid[newRow][newCol] != 'M' && grid[newRow][newCol] != 'S')) {
                    continue;
                }

                char bottomLeft = grid[newRow][newCol];

                if(!((topRight == 'M' && bottomLeft == 'S') || (topRight == 'S' && bottomLeft == 'M'))) {
                    continue;
                }

                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}