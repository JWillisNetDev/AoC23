using _4_Scratchcards;

string input = File.ReadAllText("./input.txt");
ScratchcardParser parser = new(input);
ScratchcardReader reader = new(parser.ParseAll());
Console.WriteLine($"Part 1 - Winning totals: {reader.Part1()}");

Console.WriteLine($"Part 2 - Total cards won: {reader.Part2()}");