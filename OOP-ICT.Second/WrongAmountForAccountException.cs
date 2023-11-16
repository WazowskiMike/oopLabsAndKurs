namespace OOP_ICT.Second;
[Serializable]
public class WrongAmountForAccountException : Exception
{
    public WrongAmountForAccountException() { }
    public WrongAmountForAccountException(string message) : base(message) { }
    public WrongAmountForAccountException(string message, Exception inner) : base(message, inner) { }
}