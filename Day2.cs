using System.Text;

namespace AoC2024;

internal class Day2 : AocDay {
    public void Part1() {
        using(var fileStream = File.OpenRead(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Day1.txt")) {
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                String line;
                while((line = streamReader.ReadLine()) != null) {
                }
            }
        }
    }

    public void Part2() {
        
    }
}