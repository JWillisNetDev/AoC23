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
	public void ParseAll_2LineCards()
	{
		// Arrange
		const string input =
			"""
			Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
			Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
			""";

		ScratchcardParser parser = new(input);

		// Act
		Scratchcard[] scratchcards = parser.ParseAll().ToArray();

		// Assert
		scratchcards
			.Should()
			.BeEquivalentTo(new[]
			{
				new Scratchcard(1, new[] { 41, 48, 83, 86, 17 }, new[] { 83, 86, 6, 31, 17, 9, 48, 53 }),
				new Scratchcard(2, new[] { 13, 32, 20, 16, 61 }, new[] { 61, 30, 68, 82, 17, 32, 24, 19 })
			});
	}
}