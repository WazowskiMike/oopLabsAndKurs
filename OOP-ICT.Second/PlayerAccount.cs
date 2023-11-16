namespace OOP_ICT.Second;

public class PlayerAccount: Account
{
    public PlayerAccount(double initialBalance)
    {
        if (initialBalance >= 0)
        {
            Balance = initialBalance;
        }
        else
        {
            throw new WrongAmountForAccountException("Wrong amount to initialize account");
        }
    }
}