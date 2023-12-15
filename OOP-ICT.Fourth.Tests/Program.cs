using Xunit;
using OOP_ICT.Third;
using OOP_ICT.Models;
using OOP_ICT.Second;

namespace OOP_ICT.Fourth.Tests 
{
    public class PokerTests 
    {
        [Fact]
        public void TestPlayerCreation()
        {
            var player = new Player("Test", 1000);
            Assert.Equal("Test", player.name);
            Assert.Equal(1000, player.bankAccount.Balance);
        }

        [Fact]
        public void TestDealerCreation()
        {
            var deck = new CardDeck();
            var dealer = DealerAdapter.getDealer(deck);
            Assert.Equal(deck, dealer.CardDeck);
        }

        [Fact]
        public void TestOnePlayerCards()
        {
            Poker poker = new Poker();
            Player player = new Player("artem", 100);
            player.playerHand.Add(new Card(Suits.Diamond, CardValues.Ace));
            List<Card> cardList = new();
            cardList.Add(new Card(Suits.Diamond, CardValues.Ace));
            Assert.Equal(cardList, poker.OnePlayerCards(player));
        }

        [Fact]
        public void TestHandleWinners() 
        {
            Poker poker = new();
            poker.pot = 150;
            Player player = new Player("artem", 1000);
            List<Player> winningPlayers = new(){player};
            poker.HandleWinners(winningPlayers);
            Assert.Equal(150, player.playerAccount.Balance);
        }
    }
}