using System.Collections.Immutable;

namespace _4_Scratchcards;

public record class Scratchcard(int CardNumber, ImmutableArray<int> WinningNumbers, ImmutableArray<int> ChosenNumbers)
{
	public int GetScore()
	{
		int acc = 0;

		foreach (int number in ChosenNumbers.Where(WinningNumbers.Contains))
		{
			if (acc == 0)
			{
				acc = 1;
				continue;
			}

			acc *= 2;
		}

		return acc;
	}
}