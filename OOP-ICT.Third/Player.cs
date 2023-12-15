using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{
    public PlayerAccount playerAccount;
    public BankAccount bankAccount { get; private set; }
    public List<Card> playerHand = new List<Card>();
    public string name { get; private set; }
    public int Bid = 0;
    private bool isInGame;


    public Player (string name, double deposit) {
        this.playerAccount = new ChipBank(new PlayerAccountFactory()).CreateAccount(0);
        this.bankAccount = new Bank(new BankAccountFactory()).CreateAccount(deposit);
        this.name = name;
        this.isInGame = true;
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
        bool pointsToLose = pointsSum > 21;
        bool anyAcesInHand = aceCounter > 0;
        foreach (var card in playerHand) {
            if (card.CardValue == CardValues.Ace) {
                aceCounter += 1;
                pointsSum += card.Value;
            } else {
                pointsSum += card.Value;
            }
        }
        while (pointsToLose && anyAcesInHand) {
            pointsSum -= 10;
            aceCounter--;
        }
        return pointsSum;
    }

    public void GetCard(Card card) {
        playerHand.Add(card);
    }

    public void makeBid() {
        int bid = TypeInt();
        if (playerAccount.Balance >= bid) {
            Bid = bid;
            playerAccount.WithDraw(Bid);
        } else {
            Console.WriteLine("Not enough chips in bank. Choose another amount to bid.");
            bid = TypeInt();
            if (playerAccount.Balance >= bid) {
                Bid = bid;
                playerAccount.WithDraw(Bid);
            } else {
                Console.WriteLine("You've been banned. Get out of my casino.");
            }
        }
    }

    public void BuyChips() {
        int quantityOfChips = TypeInt();
        bankAccount.WithDraw(quantityOfChips * Game.chipPrice);
        playerAccount.Deposit(quantityOfChips);
    }

    public int TypeInt() {
        try {
            return int.Parse(Console.ReadLine());
        } catch (Exception) {
            throw new WrongFormatException("You should write a positive number");
        }
    }

    public bool GetIsInGame() {
        return this.isInGame;
    }

    public void SetIsInGame(bool isInGame) {
        this.isInGame = isInGame;
    }

    public void ClearHand() {
        playerHand.Clear();
    }
}
