﻿namespace _4_Scratchcards;

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

	public int Part1()
	{
		return Scratchcards.Sum(GetScore);

		static int GetScore(Scratchcard scratchcard)
		{
			return Enumerable.Range(0, GetMatches(scratchcard)).Aggregate(0, (acc, _) => acc == 0 ? 1 : acc << 1);
		}
	}

	public int Part2()
	{
		Stack<Scratchcard> wonCards = new(Scratchcards);
		int acc = wonCards.Count;

		while (wonCards.TryPop(out Scratchcard scratchcard))
		{
			int score = GetMatches(scratchcard);
			if (score > 0)
			{
				acc += score;
				for (int i = 0; i < score; i++)
				{
					wonCards.Push(Scratchcards[scratchcard.CardNumber + i]);
				}
			}
		}

		return acc;
	}

	private static int GetMatches(Scratchcard scratchcard)
	{
		return scratchcard.WinningNumbers.Intersect(scratchcard.ChosenNumbers).Count();
	}
}