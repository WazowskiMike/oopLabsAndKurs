namespace OOP_ICT.Models
{
    public class Card
    {
        public Suits Suit { get; private set; } 
        public CardValues CardValue { get; private set; }
        public int Value { get; private set; }

        public Card(Suits suit, CardValues cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
            switch (cardValue) {
                case CardValues.Two :
                    Value = 2;
                    break;
                case CardValues.Three :
                    Value = 3;
                    break;
                case CardValues.Four :
                    Value = 4;
                    break;
                case CardValues.Five :
                    Value = 5;
                    break;
                case CardValues.Six :
                    Value = 6;
                    break;
                case CardValues.Seven :
                    Value = 7;
                    break;
                case CardValues.Eight :
                    Value = 8;
                    break;
                case CardValues.Nine :
                    Value = 9;
                    break;
                case CardValues.Ten :
                    Value = 10;
                    break;
                case CardValues.Jack :
                    Value = 10;
                    break;
                case CardValues.Queen :
                    Value = 10;
                    break;
                case CardValues.King :
                    Value = 10;
                    break;
                case CardValues.Ace :
                    Value = 11;
                    break;
                default:
                    Value = -999;
                    break;
            }
        }
    }
}