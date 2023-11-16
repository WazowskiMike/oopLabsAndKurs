namespace OOP_ICT.Second;

public class BankAccount : Account
{
    public BankAccount(double initialBalance)
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