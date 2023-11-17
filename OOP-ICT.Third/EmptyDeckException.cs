namespace OOP_ICT.Third;
[Serializable]

public class EmptyDeckException : Exception {
    public EmptyDeckException() { }
    public EmptyDeckException(string message) : base(message) { }
    public EmptyDeckException(string message, Exception inner) : base(message) {}
}