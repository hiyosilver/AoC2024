using System.Text.RegularExpressions;

namespace AoC2024;

internal class Day13 : AocDay
{
    public void Part1()
    {
        int sum = 0;

        string pattern = @".* X\+(\d*), Y\+(\d*)\r\n.* X\+(\d*), Y\+(\d*)\r\n.* X=(\d*), Y=(\d*)";
        Regex regex = new(pattern);

        foreach(Match match in regex.Matches(File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day13.txt"))) {
            int buttonAX = int.Parse(match.Groups[1].Value);
            int buttonAY = int.Parse(match.Groups[2].Value);
            int buttonBX = int.Parse(match.Groups[3].Value);
            int buttonBY = int.Parse(match.Groups[4].Value);
            int prizeX = int.Parse(match.Groups[5].Value);
            int prizeY = int.Parse(match.Groups[6].Value);

            int buttonPressesB = prizeX / buttonBX;
            if(buttonPressesB * buttonBX == prizeX && buttonPressesB * buttonBY == prizeY) {
                sum += buttonPressesB;
                continue;
            }
            buttonPressesB++;
            int buttonPressesA = 0;
            while(buttonPressesB > 0) {
                buttonPressesA++;
                while((buttonPressesA * buttonAX) + (buttonPressesB * buttonBX) > prizeX) {
                    buttonPressesB--;
                }
                if( (buttonPressesA * buttonAX) + (buttonPressesB * buttonBX) == prizeX &&
                    (buttonPressesA * buttonAY) + (buttonPressesB * buttonBY) == prizeY) {
                    sum += (buttonPressesA * 3) + buttonPressesB;
                    break;
                }
            }
        }

        Console.WriteLine(sum);
    }

    public void Part2(){
        long sum = 0;

        string pattern = @".* X\+(\d*), Y\+(\d*)\r\n.* X\+(\d*), Y\+(\d*)\r\n.* X=(\d*), Y=(\d*)";
        Regex regex = new(pattern);

        int counter = 1;
        foreach(Match match in regex.Matches(File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day13.txt"))) {
            Console.WriteLine($"Match {counter++}");
            
            long buttonAX = long.Parse(match.Groups[1].Value);
            long buttonAY = long.Parse(match.Groups[2].Value);
            long buttonBX = long.Parse(match.Groups[3].Value);
            long buttonBY = long.Parse(match.Groups[4].Value);
            long prizeX = long.Parse(match.Groups[5].Value) + 10_000_000_000_000L;
            long prizeY = long.Parse(match.Groups[6].Value) + 10_000_000_000_000L;

            long buttonPressesB = prizeX / buttonBX;
            if(buttonPressesB * buttonBX == prizeX && buttonPressesB * buttonBY == prizeY) {
                sum += buttonPressesB;
                continue;
            }
            buttonPressesB++;
            long buttonPressesA = 0;
            while(buttonPressesB > 0) {
                buttonPressesA++;
                while((buttonPressesA * buttonAX) + (buttonPressesB * buttonBX) > prizeX) {
                    buttonPressesB--;
                }
                if((buttonPressesA * buttonAX) + (buttonPressesB * buttonBX) == prizeX &&
                    (buttonPressesA * buttonAY) + (buttonPressesB * buttonBY) == prizeY) {
                    sum += (buttonPressesA * 3) + buttonPressesB;
                    break;
                }
            }
        }

        Console.WriteLine(sum);
    }
}