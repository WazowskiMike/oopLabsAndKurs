using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{
    private PlayerAccount playerAccount;
    private BankAccount bankAccount;
    private ArrayList playerCardList = new();
    private string name;

    public Player (string name, double deposit) {
        this.playerAccount = new ChipBank(new PlayerAccountFactory()).CreateAccount(0);
        this.bankAccount = new Bank(new BankAccountFactory()).CreateAccount(deposit);
        this.name = name;
    }

    private void GetCard() {
        playerCardList.Add(DealerAdapter.GiveCard());
    }
}
