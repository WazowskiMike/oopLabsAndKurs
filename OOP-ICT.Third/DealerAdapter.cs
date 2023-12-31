using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class DealerAdapter : Dealer {

    private static DealerAdapter dealer; 
    private List<Card> dealerHand = new List<Card>();

    private DealerAdapter(CardDeck deck) : base(deck)
    {
    }

    public static DealerAdapter getDealer(CardDeck cardDeck) {
        if (dealer == null) {
            dealer = new DealerAdapter(cardDeck);
        }
        return dealer;
    }

    public void Shuffle() {
        CardDeck.Shuffle();
    }

    public void GetCard() {
        Card topCard = CardDeck.CardList[0];
        dealerHand.Add(topCard);
        CardDeck.CardList.Remove(topCard);
    }

    public Card GiveCard() {
        Card toBeGivenCard = CardDeck.CardList[0];
        CardDeck.CardList.Remove(toBeGivenCard);
        return toBeGivenCard;
    }

    public void ShowInfo() {
        Console.WriteLine($"Dealer's cards: ");
        foreach (var card in dealerHand) {
            Console.WriteLine($"{card.Suit} {card.CardValue}");
        }
        Console.WriteLine($"Points sum =  {CorrectSum()}");
    }

    public int CorrectSum() {
        int aceCounter = 0;
        int pointsSum = 0;
        foreach (var card in dealerHand) {
            if (card.CardValue == CardValues.Ace) {
                aceCounter += 1;
                pointsSum += card.Value;
            } else {
                pointsSum += card.Value;
            }
        }   
        while (pointsSum > 21 && aceCounter > 0) {
            pointsSum -= 10;
            aceCounter--;
        }
        return pointsSum;
    }

    public void WinChips(Player player) {
        player.playerAccount.Deposit(player.Bid * 2);
        player.Bid = 0;
    }

    public void LoseChips(Player player) {
        player.Bid = 0;
    }

    public void ReturnChips(Player player) {
        player.playerAccount.Deposit(player.Bid);
        player.Bid = 0;
    }

    public void BlackJack(Player player) {
        player.playerAccount.Deposit(player.Bid * 1.5);
        player.Bid = 0;
    }
} 