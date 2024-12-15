using System.Text.RegularExpressions;

namespace AoC2024;

internal class Day14 : AocDay
{
    public void Part1()
    {
        string pattern = @"p=(-?\d*),(-?\d*) v=(-?\d*),(-?\d*)";
        Regex regex = new(pattern);

        int[] quadrants = new int[4]; //Top left, Top right, Bottom right, Bottom left
        int width = 101;
        int height = 103;
        int seconds = 100;

        foreach(Match match in regex.Matches(File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day14.txt"))) {
            int positionX = int.Parse(match.Groups[1].Value);
            int positionY = int.Parse(match.Groups[2].Value);
            int velocityX = int.Parse(match.Groups[3].Value);
            int velocityY = int.Parse(match.Groups[4].Value);

            int newPositionX = (positionX + (seconds * velocityX)) % width;
            int newPositionY = (positionY + (seconds * velocityY)) % height;

            if(newPositionX < 0) {
                newPositionX += width;
            }
            if(newPositionY < 0) {
                newPositionY += height;
            }

            int midX = width / 2;
            int midY = height / 2;

            if(newPositionX == midX || newPositionY == midY) {
                continue;
            }
            else if(newPositionX < midX && newPositionY < midY) {
                quadrants[0]++;
            }
            else if(newPositionX > midX && newPositionY < midY) {
                quadrants[1]++;
            }
            else if(newPositionX > midX && newPositionY > midY) {
                quadrants[2]++;
            }
            else if(newPositionX < midX && newPositionY > midY) {
                quadrants[3]++;
            }
        }

        Console.WriteLine(quadrants.Aggregate(1, (a, b) => a * b));
    }

    public void Part2(){
        string pattern = @"p=(-?\d*),(-?\d*) v=(-?\d*),(-?\d*)";
        Regex regex = new(pattern);

        int width = 101;
        int height = 103;
        int seconds = 10403 + 400;

        char[][] grid = new char[height][];
        for(int n = 0; n < grid.Length; n++) {
            grid[n] = new char[width];
        }

        while(true) {
            ConsoleKeyInfo key = Console.ReadKey();
            if(key.Key == ConsoleKey.Escape) {
                break;
            }
            Console.Clear();
            seconds++;

            for(int n = 0; n < grid.Length; n++) {
                for(int c = 0; c < grid[n].Length; c++) {
                    grid[n][c] = '.';
                }
            }

            foreach(Match match in regex.Matches(File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day14.txt"))) {
                int positionX = int.Parse(match.Groups[1].Value);
                int positionY = int.Parse(match.Groups[2].Value);
                int velocityX = int.Parse(match.Groups[3].Value);
                int velocityY = int.Parse(match.Groups[4].Value);

                int newPositionX = (positionX + (seconds * velocityX)) % width;
                int newPositionY = (positionY + (seconds * velocityY)) % height;

                if(newPositionX < 0) {
                    newPositionX += width;
                }
                if(newPositionY < 0) {
                    newPositionY += height;
                }

                grid[newPositionY][newPositionX] = 'X';
            }
            Console.WriteLine(seconds);
            for(int row = 0; row < grid.Length; row++) {
                for(int col = 0; col < grid[row].Length; col++) {
                    Console.Write($"{grid[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}