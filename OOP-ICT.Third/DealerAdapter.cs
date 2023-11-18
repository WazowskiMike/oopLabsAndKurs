using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class DealerAdapter : Dealer {
    private List<Card> dealerHand = new List<Card>();


    public DealerAdapter(CardDeck deck) : base(deck)
    {
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
} 