namespace OOP_ICT.Second;

public class ChipBank
{
    protected PlayerAccountFactory AccountFactory;
    public ChipBank(PlayerAccountFactory accountFactory)
    {
        AccountFactory = accountFactory;
    }
    public PlayerAccount CreateAccount(double initialBalance)
    {
        return AccountFactory.CreateAccount(initialBalance);
    }

    public void AddChips(PlayerAccount player, double amount)
    {
        player.Deposit(amount);
    }

    public void RemoveChips(PlayerAccount player, double amount)
    {
        player.WithDraw(amount);
    }
    public void Blackjack(PlayerAccount player, double amount, bool blackJack)
    {
        if (blackJack)
        {
            player.Deposit(amount * 1.5);
        }
    }

}