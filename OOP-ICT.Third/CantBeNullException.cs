namespace OOP_ICT.Third;
[Serializable]
public class CantBeNullException : Exception
{
    public CantBeNullException() { }
    public CantBeNullException(string message) : base(message) { }
    public CantBeNullException(string message, Exception inner) : base(message) {}
}