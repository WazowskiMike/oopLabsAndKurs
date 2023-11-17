using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class DealerAdapter : Dealer {
    private static CardDeck Deck;
    private ArrayList cardList = new();

    public DealerAdapter(CardDeck deck) : base(deck)
    {
        Deck = deck ?? throw new EmptyDeckException("The deck is empty!");
    }

    public void Shuffle() {
        Deck.Shuffle();
    }

    public void GetCard() {
        List<Card> deckAsList = Deck.CardList;
        cardList.Add(deckAsList[0]);
        deckAsList.Remove(deckAsList[0]);
    }

    public static void GiveCard(ArrayList playerCards) {
        List<Card> deckAsList = Deck.CardList;
        playerCards.Add(deckAsList[0]);
        deckAsList.Remove(deckAsList[0]);
    }
} 