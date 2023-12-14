using _4_Scratchcards;

string input = File.ReadAllText("./input.txt");
ScratchcardParser parser = new(input);
ScratchcardPuzzleSolver puzzleSolver = new(parser.ParseAll());
Console.WriteLine($"Part 1 - Winning totals: {puzzleSolver.Part1()}");

Console.WriteLine($"Part 2 - Total cards won: {puzzleSolver.Part2()}");