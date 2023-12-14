namespace _4_Scratchcards;

public class ScratchcardReader
{
	public IReadOnlyList<Scratchcard> Scratchcards { get; }

	public ScratchcardReader(IReadOnlyList<Scratchcard> scratchcards)
	{
		Scratchcards = scratchcards;
	}

	public ScratchcardReader(IEnumerable<Scratchcard> scratchcards)
	{
		Scratchcards = scratchcards.ToArray();
	}

	public int GetWinningTotals()
	{
		return Scratchcards.Sum(GetScore);
	}

	private static int GetScore(Scratchcard scratchcard)
	{
		return scratchcard.WinningNumbers
			.Intersect(scratchcard.ChosenNumbers)
			.Aggregate(0, (acc, _) => acc == 0 ? 1 : acc << 1);
	}
}