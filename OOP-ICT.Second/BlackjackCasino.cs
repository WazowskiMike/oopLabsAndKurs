namespace OOP_ICT.Second;

public class BlackjackCasino
{
    protected PlayerAccountFactory AccountFactory;
    public BlackjackCasino(PlayerAccountFactory accountFactory)
    {
        AccountFactory = accountFactory;
    }
    public PlayerAccount CreateAccount(double initialBalance)
    {
        return AccountFactory.CreateAccount(initialBalance);
    }

    public void AddMoney(PlayerAccount player, double amount)
    {
        player.Deposit(amount);
    }

    public void RemoveMoney(PlayerAccount player, double amount)
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