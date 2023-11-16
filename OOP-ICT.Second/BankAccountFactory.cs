namespace OOP_ICT.Second;

public class BankAccountFactory: AccountFactory
{
    public override BankAccount CreateAccount(double initialBalance)
    {
        if (initialBalance >= 0)
        {
            return new BankAccount(initialBalance);
        }
        else
        {
            throw new WrongAmountForAccountException("Wrong amount to initialize account");
        }
    }
}