using System.Collections.Immutable;
using FluentAssertions;

namespace _4_Scratchcards.Tests;

public class ScratchcardParserTests
{
	[Fact]
	public void ParseLine_SingleLineCard()
	{
		// Arrange
		const string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

		ScratchcardParser parser = new(input);

		// Act
		Scratchcard card = parser.ParseLine();

		// Assert
		card.CardNumber.Should().Be(1);
		card.WinningNumbers.Should().BeEquivalentTo(new[] { 41, 48, 83, 86, 17 });
		card.ChosenNumbers.Should().BeEquivalentTo(new[] { 83, 86, 6, 31, 17, 9, 48, 53 });
	}

	[Fact]
	public void ParseLine_2LineCard()
	{
		// Arrange
		const string input =
			"""
			Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
			Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
			""";

		ScratchcardParser parser = new(input);

		// Act
		Scratchcard card1 = parser.ParseLine(), card2 = parser.ParseLine();

		// Assert
		card1.CardNumber.Should().Be(1);
		card1.WinningNumbers.Should().BeEquivalentTo(new[] { 41, 48, 83, 86, 17 });
		card1.ChosenNumbers.Should().BeEquivalentTo(new[] { 83, 86, 6, 31, 17, 9, 48, 53 });

		card2.CardNumber.Should().Be(2);
		card2.WinningNumbers.Should().BeEquivalentTo(new[] { 13, 32, 20, 16, 61 });
		card2.ChosenNumbers.Should().BeEquivalentTo(new[] { 61, 30, 68, 82, 17, 32, 24, 19 });
	}


}