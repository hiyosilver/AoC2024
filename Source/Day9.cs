using System.Diagnostics.Tracing;
using System.Text;

namespace AoC2024;

internal class Day9 : AocDay
{
    public void Part1()
    {
        long sum = 0;
        StringBuilder sb = new();

        string line = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day9.txt");

        int frontId = 0;
        int backId = line.Length / 2;
        int backIdx = 1;
        int backIdRemainingDigits = line[^backIdx] - '0';
        backIdx += 2;

        for (int i = 0; i < line.Length - 1; i += 2) {
            int repetitions = frontId < backId ? line[i] - '0' : backIdRemainingDigits;
            for (int x = 0; x < repetitions; x++) {
                sb.Append((char)(frontId + 48));
            }
            if (frontId == backId) {
                break;
            }
            frontId++;
            for(int y = 0; y < line[i + 1] - '0'; y++) {
                sb.Append((char)(backId + 48));
                
                backIdRemainingDigits--;
                if(backIdRemainingDigits == 0) {
                    backId--;
                    backIdRemainingDigits = line[^backIdx] - '0';
                    backIdx += 2;
                }
            }
        }
        string result = sb.ToString();
        for (int n = 0; n < result.Length; n++) {
            sum += n * (result[n] - '0');
        }
        Console.WriteLine(sum);
    }

    public void Part2()
    {
        long sum = 0;
        StringBuilder sb = new();

        string line = File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Day9.txt");

        int frontId = 0;
        int backId = line.Length / 2;
        int backIdx = 1;
        int backIdRemainingDigits = line[^backIdx] - '0';
        backIdx += 2;

        for (int i = 0; i < line.Length - 1; i += 2) {
            int repetitions = frontId < backId ? line[i] - '0' : backIdRemainingDigits;
            for (int x = 0; x < repetitions; x++) {
                sb.Append((char)(frontId + 48));
            }
            if (frontId == backId) {
                break;
            }
            frontId++;
            for (int y = 0; y < line[i + 1] - '0'; y++) {
                sb.Append((char)(backId + 48));

                backIdRemainingDigits--;
                if (backIdRemainingDigits == 0) {
                    backId--;
                    backIdRemainingDigits = line[^backIdx] - '0';
                    backIdx += 2;
                }
            }
        }
        string result = sb.ToString();
        for (int n = 0; n < result.Length; n++) {
            sum += n * (result[n] - '0');
        }
        Console.WriteLine(sum);
    }
}