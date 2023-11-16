namespace OOP_ICT.Second;
[Serializable]
public class WrongAmountException : Exception
{
    public WrongAmountException() { }
    public WrongAmountException(string message) : base(message) { }
    public WrongAmountException(string message, Exception inner) : base(message, inner) { }
}