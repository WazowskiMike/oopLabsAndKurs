using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{

    private PlayerAccount playerAccount;
    private BankAccount bankAccount;

    private string name;

    public Player (PlayerAccount playerAccount, BankAccount bankAccount, string name) {
        this.playerAccount = playerAccount;
        this.bankAccount = bankAccount;
        this.name = name;
    }


}
