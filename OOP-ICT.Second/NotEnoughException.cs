namespace OOP_ICT.Second;
[Serializable]
public class NotEnoughException : Exception
{
    public double Amount { get; }
    public NotEnoughException() { }
    public NotEnoughException(string message) : base(message) { }
    public NotEnoughException(string message, Exception inner) : base(message, inner) { }

    public NotEnoughException(string message, double amount) : this(message)
    {
        Amount = amount;
    }
}