namespace OOP_ICT.Second;

public class Bank
{
    private BankAccountFactory _accountFactory;

    public Bank(BankAccountFactory accountFactory)
    {
        _accountFactory = accountFactory;
    }

    public BankAccount CreateAccount(double initialBalance)
    {
        return _accountFactory.CreateAccount(initialBalance);
    }

    public void AddMoney(BankAccount account, double amount)
    {
        account.Deposit(amount);
    }   
    public void RemoveMoney(BankAccount account, double amount)
    {
        account.WithDraw(amount);
    }

    public bool IsEnough(BankAccount account, double amount)
    {
        return account.IsEnough(amount);
    }
}