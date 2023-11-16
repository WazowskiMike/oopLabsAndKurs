namespace OOP_ICT.Second;

public class PlayerAccountFactory: AccountFactory
{
    public override PlayerAccount CreateAccount(double initialBalance)
    {
        if (initialBalance >= 0)
        {
            return new PlayerAccount(initialBalance);
        }
        else
        {
            throw new WrongAmountForAccountException("Wrong amount to initialize account");
        }
    }
}