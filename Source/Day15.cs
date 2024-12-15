using System.ComponentModel;

namespace AoC2024;

internal class Day15 : AocDay
{
    public void Part1()
    {
        int sum = 0;

        string[] input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day15.txt").Split("\r\n\r\n");

        char[][] grid = input[0].Split("\n").Select(x => x.ToCharArray()).ToArray();
        char[] moves = string.Join("", input[1].Split("\r\n")).ToCharArray();
        (int Row, int Col) robotPosition = (0, 0);

        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                if(grid[row][col] == '@') {
                    robotPosition = (row, col);
                    grid[row][col] = '.';
                }
            }
        }

        for(int mv = 0; mv < moves.Length; mv++) {
            switch(moves[mv]) {
                case '^':
                    for(int row = robotPosition.Row - 1; row > 0; row--) {
                        if(grid[row][robotPosition.Col] == '#') {
                            break;
                        }
                        if(grid[row][robotPosition.Col] == '.') {
                            if(row < robotPosition.Row - 1) {
                                grid[row][robotPosition.Col] = 'O';
                                grid[robotPosition.Row - 1][robotPosition.Col] = '.';
                            }
                            robotPosition = (robotPosition.Row - 1, robotPosition.Col);
                            break;
                        }
                    }
                    break;
                case '>':
                    for(int col = robotPosition.Col + 1; col < grid[robotPosition.Row].Length - 1; col++) {
                        if(grid[robotPosition.Row][col] == '#') {
                            break;
                        }
                        if(grid[robotPosition.Row][col] == '.') {
                            if(col > robotPosition.Col + 1) {
                                grid[robotPosition.Row][col] = 'O';
                                grid[robotPosition.Row][robotPosition.Col + 1] = '.';
                            }
                            robotPosition = (robotPosition.Row, robotPosition.Col + 1);
                            break;
                        }
                    }
                    break;
                case 'v':
                    for(int row = robotPosition.Row + 1; row < grid.Length - 1; row++) {
                        if(grid[row][robotPosition.Col] == '#') {
                            break;
                        }
                        if(grid[row][robotPosition.Col] == '.') {
                            if(row > robotPosition.Row + 1) {
                                grid[row][robotPosition.Col] = 'O';
                                grid[robotPosition.Row + 1][robotPosition.Col] = '.';
                            }
                            robotPosition = (robotPosition.Row + 1, robotPosition.Col);
                            break;
                        }
                    }
                    break;
                case '<':
                    for(int col = robotPosition.Col - 1; col > 0; col--) {
                        if(grid[robotPosition.Row][col] == '#') {
                            break;
                        }
                        if(grid[robotPosition.Row][col] == '.') {
                            if(col < robotPosition.Col - 1) {
                                grid[robotPosition.Row][col] = 'O';
                                grid[robotPosition.Row][robotPosition.Col - 1] = '.';
                            }
                            robotPosition = (robotPosition.Row, robotPosition.Col - 1);
                            break;
                        }
                    }
                    break;
            }
        }

        //PrintGrid(grid);

        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                if(grid[row][col] == 'O') {
                    sum += (100 * row) + col;
                }
            }
        }

        Console.WriteLine(sum);
    }

    private void PrintGrid(char[][] grid) {
        for(int row = 0; row < grid.Length; row++) {
            for(int col = 0; col < grid[row].Length; col++) {
                Console.Write(grid[row][col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void Part2(){
        int sum = 0;

        string[] input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day15.txt").Split("\r\n\r\n");

        char[][] grid = input[0]
            .Split("\n")
            .Select(x => x.ToCharArray()
                .Select(y => {
                    switch(y) {
                        case '#':
                            return "##";
                        case 'O':
                            return "[]";
                        case '.':
                            return "..";
                        case '@':
                            return "@.";
                        default:
                            return "";
                            //throw new InvalidEnumArgumentException($"Symbol was: {y}");
                    }
                })
                .Aggregate((a, b) => a + b)
            )
            .Select(z => z.ToCharArray())
            .ToArray();

        PrintGrid(grid);

        char[] moves = string.Join("", input[1].Split("\r\n")).ToCharArray();

        Console.WriteLine(sum);
    }
}