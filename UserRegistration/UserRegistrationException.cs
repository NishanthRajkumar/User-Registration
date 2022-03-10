namespace UserRegistration;

/// <summary>
/// Custom Exception class for handling invalid entries in user registration
/// </summary>
/// <seealso cref="System.Exception" />
public class UserRegistrationException : Exception
{
    public readonly ExceptionType type;

    public enum ExceptionType
    {
        INVALID_NAME,
        INVALID_EMAIL,
        INVALID_MOBILE,
        INVALID_PASSWORD,
        INVALID_ENTRY
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistrationException"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="errorMessage">The error message.</param>
    public UserRegistrationException(ExceptionType type, string errorMessage) : base(errorMessage)
    {
        this.type = type;
    }
}
