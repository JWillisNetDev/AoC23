using System.Collections.Immutable;

namespace _4_Scratchcards;

public class ScratchcardParser
{
	public string Input { get; }

	public IReadOnlyList<string> Errors => _Errors;

	private readonly List<string> _Errors = new();
	private int _Pointer;
	private char _Current;
	private char _Peek;

	public ScratchcardParser(string input)
	{
		Input = input ?? throw new ArgumentNullException(nameof(input));
		_Pointer = 0;
		_Peek = Input[0];

	}

	public Scratchcard ParseLine()
	{
		// Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
		
		int cardNumber = ParseCardNumber();
		ImmutableArray<int> winningNumbers = ParseWinningNumbers().ToImmutableArray();
		ImmutableArray<int> chosenNumbers = ParseChosenNumbers().ToImmutableArray();

		return new Scratchcard(cardNumber, winningNumbers, chosenNumbers);

		int ParseCardNumber()
		{
			while (!ExpectNumber()) { MoveNext(); }
			return ParseNumber();
		}

		IEnumerable<int> ParseWinningNumbers()
		{
			while (!ExpectPipe())
			{
				while (!ExpectNumber()) { MoveNext(); }
				yield return ParseNumber();
			}
			MoveNext();
		}

		IEnumerable<int> ParseChosenNumbers()
		{
			while (!ExpectEndOfCard())
			{
				while (!ExpectNumber()) { MoveNext(); }
				yield return ParseNumber();
			}
			MoveNext();
		}
	}

	private int ParseNumber()
	{
		int acc = 0;

		do
		{
			MoveNext();
			acc = acc * 10 + (_Current - '0');
		}
		while (CurrentIsNumber());

		return acc;
	}

	private bool ExpectEndOfCard() => _Peek is '\n' or '\0';

	private bool ExpectPipe() => _Peek == '|';

	private bool ExpectNumber() => char.IsNumber(_Peek);

	private bool CurrentIsNumber() => char.IsNumber(_Current);

	private void MoveNext()
	{
		_Current = _Peek;
		
		if (++_Pointer >= Input.Length)
		{
			_Peek = '\0';
			return;
		}

		_Peek = Input[_Pointer];
	}
}