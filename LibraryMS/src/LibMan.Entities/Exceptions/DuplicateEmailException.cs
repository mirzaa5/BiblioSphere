using LibMan.Entities;
public class DublicateEmailException : Exception
{
    public DublicateEmailException(string message) : base(message)
    {

    }
    public DublicateEmailException(string message, Exception InnerException ) : base(message, InnerException)
    {

    }
    public DublicateEmailException() : base()
    {

    }
}