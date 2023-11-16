namespace OOP_ICT.Second;

public abstract class Account
{
    public double Balance { get; protected set; }
    
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
        else
        {
            throw new WrongAmountException("Wrong amount for deposit");
        }
    }

    public void WithDraw(double amount)
    {
       
        if (IsEnough(amount))
        {
            Balance -= amount;
        }
        else
        {
            throw new NotEnoughException("Not enough money on your balance:", Balance);
        }
    }
    public bool IsEnough(double amount)
    {
        return Balance >= amount;
    }
}