namespace AoC2024;

internal class Day6 : AocDay
{
    
    public void Part1()
    {
        int sum = 1;

        char[][] grid = [.. File.ReadLines(Directory.GetCurrentDirectory() + "/Data/Day6.txt").Select(x => x.ToCharArray())];

        (int X, int Y)[] directions = { (-1, 0), (0, 1), (1, 0), (0, -1) };
        int currentDirection = 0;
        int currentRow = 0;
        int currentCol = 0;

        bool guardFound = false;
        for (int row = 0; row < grid.Length; row++) {
            for (int col = 0; col < grid[row].Length; col++) {
                if (grid[row][col] == '^') {
                    currentRow = row;
                    currentCol = col;
                    grid[row][col] = 'X';
                    guardFound = true;
                    break;
                }
            }
            if(guardFound) {
                break;
            }
        }

        while(true) {
            int nextRow = currentRow + directions[currentDirection].X;
            int nextCol = currentCol + directions[currentDirection].Y;
            if(nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[currentRow].Length) {
                if(grid[nextRow][nextCol] == '#') {
                    currentDirection = (currentDirection + 1) % 4;
                }
                else if(grid[currentRow][currentCol] == '.') {
                    sum++;
                    grid[currentRow][currentCol] = 'X';
                    currentRow = nextRow;
                    currentCol = nextCol;
                }
                else {
                    currentRow = nextRow;
                    currentCol = nextCol;
                }
            }
            else {
                if (grid[currentRow][currentCol] == '.') {
                    sum++;
                }
                break;
            }
        }

        Console.WriteLine(sum);
    }

    public void Part2()
    {
    }
}