using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AoC2024;

internal class Day17 : AocDay
{
    public void Part1()
    {
        string registerPattern = @"Register [ABC]: (\d*)";
        Regex registerRegex = new(registerPattern);

        string programPattern = @"Program: ((?:\d*,?)*)";
        Regex programRegex = new(programPattern);

        string input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day17.txt");

        MatchCollection registers = registerRegex.Matches(input);
        int registerA = int.Parse(registers[0].Groups[1].Value);
        int registerB = int.Parse(registers[1].Groups[1].Value);
        int registerC = int.Parse(registers[2].Groups[1].Value);

        int[] program = programRegex.Match(input).Groups[1].Value.Split(',').Select(int.Parse).ToArray();

        List<int> output = [];

        for(int n = 0; n < program.Length; n += 2) {
            int op = program[n];
            int operand = program[n + 1];
            int combo = operand switch {
                <= 3 => operand,
                4 => registerA,
                5 => registerB,
                6 => registerC,
                _ => throw new InvalidEnumArgumentException(),
            };

            switch(op) {
                case 0: //adv
                    registerA = (int)(registerA / Math.Pow(2, combo));
                    break;
                case 1: //bxl
                    registerB ^= operand;
                    break;
                case 2: //bst
                    registerB = combo % 8;
                    break;
                case 3: //jnz
                    if(registerA != 0) {
                        n = operand - 2;
                    }
                    break;
                case 4: //bxc
                    registerB ^= registerC;
                    break;
                case 5: //out
                    output.Add(combo % 8);
                    break;
                case 6: //bdv
                    registerB = (int)(registerA / Math.Pow(2, combo));
                    break;
                case 7: //cdv
                    registerC = (int)(registerA / Math.Pow(2, combo));
                    break;
            }
        }

        Console.WriteLine(string.Join(",", output.Select(x => x.ToString())));
    }

    public void Part2(){
        string registerPattern = @"Register [ABC]: (\d*)";
        Regex registerRegex = new(registerPattern);

        string programPattern = @"Program: ((?:\d*,?)*)";
        Regex programRegex = new(programPattern);

        string input = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day17.txt");

        MatchCollection registers = registerRegex.Matches(input);
        long registerA = long.Parse(registers[0].Groups[1].Value) * 256;
        long registerB = long.Parse(registers[1].Groups[1].Value);
        long registerC = long.Parse(registers[2].Groups[1].Value);

        int[] program = programRegex.Match(input).Groups[1].Value.Split(',').Select(int.Parse).ToArray();

        List<int> output = [];

        for(int n = 0; n < program.Length; n += 2) {
            int op = program[n];
            int operand = program[n + 1];
            long combo = operand switch {
                <= 3 => operand,
                4 => registerA,
                5 => registerB,
                6 => registerC,
                _ => throw new InvalidEnumArgumentException(),
            };

            switch(op) {
                case 0: //adv
                    registerA = (int)(registerA / Math.Pow(2, combo));
                    break;
                case 1: //bxl
                    registerB ^= operand;
                    break;
                case 2: //bst
                    registerB = combo % 8;
                    break;
                case 3: //jnz
                    if(registerA != 0) {
                        n = operand - 2;
                    }
                    break;
                case 4: //bxc
                    registerB ^= registerC;
                    break;
                case 5: //out
                    output.Add((int)(combo % 8));
                    break;
                case 6: //bdv
                    registerB = (int)(registerA / Math.Pow(2, combo));
                    break;
                case 7: //cdv
                    registerC = (int)(registerA / Math.Pow(2, combo));
                    break;
            }
        }

        Console.WriteLine($"program.Length: {program.Length} -> output.Count: {output.Count}");

        Console.WriteLine(string.Join(",", output.Select(x => x.ToString())));
    }
}