using Xunit;
using OOP_ICT.Third;
using OOP_ICT.Models;
using OOP_ICT.Second;


namespace OOP_ICT.Third.Tests {
    public class PlayerTests 
    {
        [Fact]
        public void TestPlayerCreation()
        {
            var player = new Player("Test", 1000);
            Assert.Equal("Test", player.name);
            Assert.Equal(1000, player.bankAccount.Balance);
        }
        
        [Fact]
        public void TestGetCard()
        {
            var player = new Player("Test", 1000);
            var card = new Card(Suits.Hearts, CardValues.Ace);
            player.GetCard(card);
            Assert.Single(player.playerHand);
            Assert.Equal(card, player.playerHand[0]);
        }

        [Fact]
        public void TestCorrectSum()
        {
            var player = new Player("Test", 1000);
            var card1 = new Card(Suits.Hearts, CardValues.Ace);
            var card2 = new Card(Suits.Hearts, CardValues.Ten);
            player.GetCard(card1);
            player.GetCard(card2);
            Assert.Equal(21, player.CorrectSum());
        }
    }

    public class DealerAdapterTests
    {
        [Fact]
        public void TestDealerCreation()
        {
            var deck = new CardDeck();
            var dealer = new DealerAdapter(deck);
            Assert.Equal(deck, dealer.CardDeck);
        }

        [Fact]
        public void TestGetCard()
        {
            var deck = new CardDeck();
            var dealer = new DealerAdapter(deck);
            dealer.GetCard();
            Assert.Single(dealer.dealerHand);
            Assert.Equal(deck.CardList[0], dealer.dealerHand[0]);
        }

        [Fact]
        public void TestGiveCard()
        {
            var deck = new CardDeck();
            var dealer = new DealerAdapter(deck);
            var card = dealer.GiveCard();
            Assert.Equal(deck.CardList[0], card);
        }
    }
}
