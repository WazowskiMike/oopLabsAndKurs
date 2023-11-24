namespace OOP_ICT.Third;
[Serializable]
public class WrongFormatException : Exception
{
    public WrongFormatException() { }
    public WrongFormatException(string message) : base(message) { }
    public WrongFormatException(string message, Exception inner) : base(message, inner) { }
}