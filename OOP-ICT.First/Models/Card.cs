namespace OOP_ICT.Models
{
    public class Card
    {
        public Suits Suit { get; private set; } 
        public CardValues CardValue { get; private set; }

        public Card(Suits suit, CardValues cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
        }
    }
}