namespace OOP_ICT.Models
{
    public class Card
    {
        public Suits Suit { get; private set; } 
        public CardValues CardValue { get; private set; }
        public int Value { get; private set; }
        private Dictionary<CardValues, int> valueDictionary = new Dictionary<CardValues, int> {
            {CardValues.Two, 2},
            {CardValues.Three, 3},
            {CardValues.Four, 4},
            {CardValues.Five, 5},
            {CardValues.Six, 6},
            {CardValues.Seven, 7},
            {CardValues.Eight, 8},
            {CardValues.Nine, 9},
            {CardValues.Ten, 10},
            {CardValues.Jack, 10},
            {CardValues.Queen, 10},
            {CardValues.King, 10},
            {CardValues.Ace, 11}

        };
        public Card(Suits suit, CardValues cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
            Value = valueDictionary[cardValue];
        }
    }
}