namespace DataBaseLib.Exceptions
{
    public class NoAnswerException : DataBaseException
    {
        public NoAnswerException(TypeException typeException, string tableName) 
            : base(typeException, tableName) { }

        public NoAnswerException(string? message, TypeException typeException, string tableName) 
            : base(message, typeException, tableName) { }
    }
}