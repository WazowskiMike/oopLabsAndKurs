using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.First.Tests
{
    public class CardDeckTests
    {
        [Fact]
        public void CardDeck_Initialization_ShouldCreateFullDeck()
        {
            // Arrange
            var cardDeck = new CardDeck();

            // Act
            int expectedCount = Enum.GetValues(typeof(Suits)).Length * Enum.GetValues(typeof(CardValues)).Length;

            // Assert
            Assert.Equal(expectedCount, cardDeck.CardList.Count);
        }

        [Fact]
        public void CardDeck_Shuffle_ShouldShuffleDeck()
        {
            // Arrange
            var cardDeck = new CardDeck();
            var originalDeck = cardDeck.CardList.ToList();

            // Act
            cardDeck.Shuffle();

            // Assert
            Assert.NotEqual(originalDeck, cardDeck.CardList);
        }
    }

    public class DealerTests
    {
        [Fact]
        public void Dealer_CardDeck_ShouldNotBeNull()
        {
            // Arrange
            CardDeck deck = new CardDeck();
            var dealer = new Dealer(deck);

            // Assert
            Assert.NotNull(dealer.CardDeck);
        }
        [Fact]
        public void Dealer_CardDeck_ShouldHaveFullDeckAfterShuffle()
        {
            // Arrange
            CardDeck deck = new CardDeck();
            var dealer = new Dealer(deck);

            // Act
            dealer.CardDeck.Shuffle();

            // Assert
            int expectedCount = Enum.GetValues(typeof(Suits)).Length * Enum.GetValues(typeof(CardValues)).Length;
            Assert.Equal(expectedCount, dealer.CardDeck.CardList.Count);
        }
        [Fact]
        public void Dealer_CardDeck_ShouldBeShuffled()
        {
            // Arrange
            CardDeck deck = new CardDeck();
            var dealer = new Dealer(deck);
            var originalDeck = new List<Card>(dealer.CardDeck.CardList);

            // Act
            dealer.CardDeck.Shuffle();

            // Assert
            Assert.NotEqual(originalDeck, dealer.CardDeck.CardList);
        }
    }
}