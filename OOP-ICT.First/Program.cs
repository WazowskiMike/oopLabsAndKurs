using OOP_ICT.Models;

CardDeck deck = new CardDeck();
Dealer dealer = new Dealer(deck);
dealer.CardDeck.Shuffle();
foreach (Card s in dealer.CardDeck.CardList) 
{
    Console.WriteLine(s.Suit + " " + s.CardValue);
} 