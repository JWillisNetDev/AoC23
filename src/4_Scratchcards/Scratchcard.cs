using System.Collections.Immutable;

namespace _4_Scratchcards;

public record struct Scratchcard(int CardNumber, ImmutableArray<int> WinningNumbers, ImmutableArray<int> ChosenNumbers)
{
	public Scratchcard(int cardNumber, IEnumerable<int> winningNumbers, IEnumerable<int> chosenNumbers)
		: this(cardNumber, winningNumbers.ToImmutableArray(), chosenNumbers.ToImmutableArray())
	{
	}
}