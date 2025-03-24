
public class EmailNotFoundException : Exception
{
    public EmailNotFoundException(string email) : base($"Admin with email {email} not found")
    {

    }
    public EmailNotFoundException(string email, Exception InnerException ) : base($"Admin with email ${email} not found", InnerException)
    {
    
    }
    public EmailNotFoundException() : base()
    {

    }
}