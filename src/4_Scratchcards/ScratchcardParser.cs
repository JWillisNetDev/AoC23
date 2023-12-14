using System.Collections.Immutable;
using System.Diagnostics;

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
		MoveNext();
	}
	
	public IEnumerable<Scratchcard> ParseAll()
	{
		while (_Current != '\0')
		{
			yield return ParseLine();
		}
	}

	public Scratchcard ParseLine()
	{
		int cardNumber = ParseNumbersUntil(':').Single();
		ImmutableArray<int> winningNumbers = ParseNumbersUntil('|').ToImmutableArray();
		MoveNext();
		ImmutableArray<int> chosenNumbers = ParseNumbersUntil('\n').ToImmutableArray();

		return new Scratchcard(cardNumber, winningNumbers, chosenNumbers);

		IEnumerable<int> ParseNumbersUntil(char c)
		{
			while (_Current != c && _Current != '\0')
			{
				while (_Peek == ' ') { MoveNext(); }
				if (ExpectNumber()) { yield return ParseNumber(); }
				MoveNext();
			}
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