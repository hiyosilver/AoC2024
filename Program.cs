namespace AoC2024;
internal class Program {
    static void Main(string[] args) {
        List<AocDay> daysToCalc = new() {
            //new Day1(),
            new Day2(),
            //new Day3(),
        };

        foreach(AocDay day in daysToCalc) {
            Console.WriteLine( "╔═════╗");
            Console.WriteLine($"║{day.GetType().Name} ║");
            Console.WriteLine( "╚═════╝");
            Console.WriteLine("Part1--------------------------------------------");
            day.Part1();
            Console.WriteLine("Part2--------------------------------------------");
            day.Part2();
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
