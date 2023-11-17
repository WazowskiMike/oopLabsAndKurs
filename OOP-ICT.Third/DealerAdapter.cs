using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class DealerAdapter : Dealer {
    private ArrayList cardList = new();


    public DealerAdapter(CardDeck deck) : base(deck)
    {
    }

    public void Shuffle() {
        CardDeck.Shuffle();
    }

    public void GetCard() {
        List<Card> deckAsList = CardDeck.CardList;
        cardList.Add(deckAsList[0]);
        deckAsList.Remove(deckAsList[0]);
    }

    public Card GiveCard() {
        List<Card> deckAsList = CardDeck.CardList;
        Card toBeGivenCard = deckAsList[0];
        deckAsList.Remove(toBeGivenCard);
        return toBeGivenCard;
    }
} 