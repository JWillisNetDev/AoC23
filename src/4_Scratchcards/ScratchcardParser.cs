using System.Collections.Immutable;

namespace _4_Scratchcards;

public class ScratchcardParser
{
	public string Input { get; }

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
		ImmutableArray<int> winningNumbers = ParseNumbersUntil('|').ToImmutableArray();
		ImmutableArray<int> chosenNumbers = ParseNumbersUntil('\n').ToImmutableArray();

		return new Scratchcard(cardNumber, winningNumbers, chosenNumbers);

		int ParseCardNumber()
		{
			while (!ExpectNumber()) { MoveNext(); }
			return ParseNumber();
		}

		IEnumerable<int> ParseNumbersUntil(char c)
		{
			while (_Peek != c && _Peek != '\0')
			{
				SkipSpaces();
				if (ExpectNumber()) { yield return ParseNumber(); }
				MoveNext();
			}

			MoveNext();
		}
	}

	private int ParseNumber()
	{
		int acc = 0;

		while (ExpectNumber())
		{
			MoveNext();
			acc = acc * 10 + (_Current - '0');
		}

		return acc;
	}

	private void SkipSpaces()
	{
		while (_Peek == ' ') { MoveNext(); }
	}

	private bool ExpectNumber() => char.IsNumber(_Peek);
	
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