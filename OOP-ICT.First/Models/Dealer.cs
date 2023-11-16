namespace OOP_ICT.Models
{

    public class Dealer
    {
        public CardDeck CardDeck { get;  private set; }

        public Dealer(CardDeck deck)
        {
            CardDeck = deck;
        }
        
    }
}    