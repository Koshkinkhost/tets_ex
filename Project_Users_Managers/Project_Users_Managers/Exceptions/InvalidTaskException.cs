namespace Project_Users_Managers.Exceptions
{
    public class InvalidTaskException:Exception
    {
        public InvalidTaskException()
                : base("Время затрачено на задачу должно быть больше нуля.") { }

        public InvalidTaskException(string message)
            : base(message) { }

        public InvalidTaskException(string message, Exception inner)
            : base(message, inner) { }
    }
}
