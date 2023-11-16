using System.ComponentModel;

namespace OOP_ICT.Third;
using Second;
using OOP_ICT.Models;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

public class Game
{
    private int _oneChipPrice;
    private readonly Dictionary<string, Account> _playersDictionary = new();
    private Dictionary<string, double> bids = new();
    private Dictionary<string, int> playerPoints = new();
    private Dictionary<string, Card[]> everyPlayerCards = new();
    
    public void JoinGame()
    {
        Console.WriteLine("Write player as \"[name] [balance]\" in one string or \"enter\" to end adding:");
        var player = Console.ReadLine();
        while (player is not null && player.Trim() != "")
        {
            string[] splitPlayer = player.Trim().Split(' ');
            Account balance = new PlayerAccount(double.Parse(splitPlayer[1])); 
            try
            {
                _playersDictionary.Add(splitPlayer[0], balance);
            }
            catch (FormatException)
            {
                throw new WarningException("Wrong format of player's info. Check the rule of adding new player");
            }
            player = Console.ReadLine();
        }
        Console.WriteLine("Write the price of one chip in this game:");
        _oneChipPrice = int.Parse(Console.ReadLine() ?? throw new CantBeNullException("The " +
            "meaning can't be null"));
        foreach (var plr in _playersDictionary)
        {
            Console.WriteLine($"name: {plr.Key}, balance: {plr.Value.Balance}");
        }
        Console.WriteLine($"One chip price for this game: {_oneChipPrice}");

    }

    public void Bid()
    {
        foreach (var plr in _playersDictionary)
        {
            Console.WriteLine($"Player {plr.Key}, select quantity of chips you want to buy:");
            var quantityOfChips = double.Parse(Console.ReadLine() ?? throw new CantBeNullException("The " + 
                "meaning can't be null"));
            var minusBalance = quantityOfChips * _oneChipPrice * 1.0;
            try
            {
                plr.Value.WithDraw(minusBalance);
            }
            catch (NotEnoughException)
            {
                Console.WriteLine("Not enough money on your balance\n"
                    + $"Money on your account: {plr.Value.Balance}\n"                      
                    + "Choose another quantity of chips:");
                quantityOfChips = double.Parse(Console.ReadLine() ?? throw new CantBeNullException("The " + 
                    "meaning can't be null"));
                minusBalance = quantityOfChips * _oneChipPrice * 1.0;
                try
                {
                    plr.Value.WithDraw(minusBalance);
                }
                catch (NotEnoughException)
                {
                    _playersDictionary.Remove(plr.Key);
                    continue;
                }
            }
            bids.Add(plr.Key, quantityOfChips);
        }

        foreach (var plr in bids)
        {
            Console.WriteLine($"Player: {plr.Key}, quantity of chips: {plr.Value}\n");
        }
    }

    public void GetCards() {
        CardDeck deck = new CardDeck();
        Dealer dealer = new Dealer(deck);
        dealer.CardDeck.Shuffle();
        List<Card> cards = dealer.CardDeck.CardList;
        foreach (var plr in _playersDictionary) {
            Card[] twoCards = {cards[0], cards[1]};
            cards.Remove(cards[0]);
            cards.Remove(cards[0]);
            everyPlayerCards.Add(plr.Key, twoCards);
        }
        foreach (var plrWithCards in everyPlayerCards) {
            Console.WriteLine($"Player: {plrWithCards.Key}\n" +
            $"card1: {plrWithCards.Value[0].Suit} {plrWithCards.Value[0].CardValue}\n" +
            $"card2: {plrWithCards.Value[1].Suit} {plrWithCards.Value[1].CardValue}\n\n");
        }
        Dictionary<Card, double> dealerCards = new();
        for (int i = 0; i < 2; i++) {
            dealerCards.Add(cards[0], GetPointsFromCards(cards[0]));
            cards.Remove(cards[0]);
        }
        Console.WriteLine("Dealer card:");
        foreach (var dlr in dealerCards) {
            Console.WriteLine($"Card: {dlr.Key.Suit} {dlr.Key.CardValue}, Points: {dlr.Value}\n");
            break;
        }
        foreach (var plrWithCards in everyPlayerCards) {
            int points = 0;
            foreach(var card in plrWithCards.Value) {
                points += GetPointsFromCards(card);
            }
            playerPoints.Add(plrWithCards.Key, points);
            var bidWithBlackJack = BlackJack(bids[plrWithCards.Key], playerPoints[plrWithCards.Key]);
            if (bidWithBlackJack > bids[plrWithCards.Key]) {
                bids[plrWithCards.Key] = bidWithBlackJack;
                everyPlayerCards.Remove(plrWithCards.Key);
                playerPoints.Remove(plrWithCards.Key);
                Console.WriteLine($"You have a blackjack! Your chips: {bids[plrWithCards.Key]}");
                continue;
            }
            if ((points > 20 && plrWithCards.Value[0].CardValue == CardValues.Ace) ||
            (points > 20 && plrWithCards.Value[1].CardValue == CardValues.Ace)) {
                playerPoints[plrWithCards.Key] -= 10;
            }
        }
        foreach (var plrPoints in playerPoints) {
            Console.WriteLine($"Player: {plrPoints.Key}, Points: {plrPoints.Value}\n");
        }
    }

    public void FinishGame() {
        foreach(var plr in playerPoints) {
            while (plr.Value < 21) {
                Console.WriteLine($"Player {plr.Key}, do you want to take one more card? Type \"y\" or \"n\"");
                var answer = Console.ReadLine();
                
            }
        }
    }

    public static int GetPointsFromCards(Card card) {
        int points = 0;
        if (card.CardValue == CardValues.One) {points += 1;}
        else if (card.CardValue == CardValues.Two) {points += 2;}
        else if (card.CardValue == CardValues.Three) {points += 3;}
        else if (card.CardValue == CardValues.Four) {points += 4;}
        else if (card.CardValue == CardValues.Five) {points += 5;}
        else if (card.CardValue == CardValues.Six) {points += 6;}
        else if (card.CardValue == CardValues.Seven) {points += 7;}
        else if (card.CardValue == CardValues.Eight) {points += 8;}
        else if (card.CardValue == CardValues.Nine) {points += 9;}
        else if (card.CardValue == CardValues.Ten) {points += 10;}
        else if (card.CardValue == CardValues.Jack) {points += 10;}
        else if (card.CardValue == CardValues.Queen) {points += 10;}
        else if (card.CardValue == CardValues.King) {points += 10;}
        else if (card.CardValue == CardValues.Ace) {points += 11;}
        return points;
    }

    public static double BlackJack(double bid, int points) {
        if (points == 21) {
            return bid * 1.5;
        }
        return bid;
    }
}
