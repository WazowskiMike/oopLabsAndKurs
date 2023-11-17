using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{
    private PlayerAccount playerAccount;
    public BankAccount bankAccount { get; private set; }
    private ArrayList playerCardList = new();
    public string name { get; private set; }
    private int Bid = 0;

    public Player (string name, double deposit) {
        this.playerAccount = new ChipBank(new PlayerAccountFactory()).CreateAccount(0);
        this.bankAccount = new Bank(new BankAccountFactory()).CreateAccount(deposit);
        this.name = name;
    }

    private void GetCard(Card card) {
        playerCardList.Add(card);
    }

    public void makeBid(int bid) {
        if (playerAccount.Balance >= bid) {
            Bid = bid;
            playerAccount.WithDraw(Bid);
        } else {
            Console.WriteLine("Not enough chips in bank");
        }
    }
    
}
