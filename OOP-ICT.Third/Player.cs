using System.Collections;
using System.Diagnostics.CodeAnalysis;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{
    public PlayerAccount playerAccount { get; private set; }
    public BankAccount bankAccount { get; private set; }
    private List<Card> playerHand = new List<Card>();
    public string name { get; private set; }
    private int Bid = 0;
   

    public Player (string name, double deposit) {
        this.playerAccount = new ChipBank(new PlayerAccountFactory()).CreateAccount(0);
        this.bankAccount = new Bank(new BankAccountFactory()).CreateAccount(deposit);
        this.name = name;
    }

    public void ShowCardsInfo() {
        Console.WriteLine(name + "'s cards :");
        foreach (var card in playerHand) {
            Console.WriteLine(card.Suit + " " + card.CardValue);
        }
        Console.WriteLine("Points sum = " + CorrectSum());
    }

    public int CorrectSum () {
        int aceCounter = 0;
        int pointsSum = 0;
        foreach (var card in playerHand) {
            if (card.CardValue == CardValues.Ace) {
                aceCounter += 1;
                pointsSum += card.Value;
            } else {
                pointsSum += card.Value;
            }
        }
        while (pointsSum > 21 && aceCounter > 0) {
            pointsSum -= 10;
            aceCounter--;
        }
        return pointsSum;
    }

    public void GetCard(Card card) {
        playerHand.Add(card);
    }

    public void makeBid() {
        int bid = int.Parse(Console.ReadLine());
        if (playerAccount.Balance >= bid) {
            Bid = bid;
            playerAccount.WithDraw(Bid);
        } else {
            Console.WriteLine("Not enough chips in bank");
        }
    }

    public void BuyChips() {
        int quantityOfChips = int.Parse(Console.ReadLine());
        bankAccount.WithDraw(quantityOfChips * Game.chipPrice);
        playerAccount.Deposit(quantityOfChips);
    }

    public void winChips() {
        playerAccount.Deposit(Bid * 2);
        Bid = 0;
    }

    public void loseChips() {
        Bid = 0;
    }

    public void blackJack() {
        playerAccount.Deposit(Bid * 1.5);
        Bid = 0;
    }

    
}
