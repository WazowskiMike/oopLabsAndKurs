namespace OOP_ICT.Models
{
    public class CardDeck
    {
        Random r = new Random();
        public List<Card> CardList { private set; get; }

        public CardDeck()
        {
            CardList = Initialization();
        }

        private List<Card> Initialization()
        {
            var deck = new List<Card>();
            for (int i = 0; i < Enum.GetValues(typeof(Suits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetValues(typeof(CardValues)).Length; j++)
                {
                    deck.Add(new Card((Suits)Enum.GetValues(typeof(Suits)).GetValue(i),
                        (CardValues)Enum.GetValues(typeof(CardValues)).GetValue(j)));
                }
            }

            return deck;
        }

        public void Shuffle()
        {
            try
            {
                int n = CardList.Count;
                while (n > 1)
                {
                    n--;
                    int i = r.Next(0, n);
                    (CardList[i], CardList[n]) = (CardList[n], CardList[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}