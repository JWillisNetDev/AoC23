using _4_Scratchcards;

string input = File.ReadAllText("./input.txt");
ScratchcardParser parser = new(input);
ScratchcardReader reader = new(parser.ParseAll());
Console.WriteLine($"Part 1 - Winning totals: {reader.GetWinningTotals()}");