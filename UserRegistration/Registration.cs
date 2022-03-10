using System.Text.RegularExpressions;

namespace UserRegistration;

/// <summary>
/// Takes details from user for registration form purposes
/// </summary>
public class Registration
{
    // RegEx patterns for various types of information
    public const string NAME_PATTERN = @"^[A-Z][a-zA-Z]{2,}$";
    public const string EMAIL_PATTERN = @"^[A-Za-z0-9]{3,}([\.\-\+][A-Za-z0-9]{3,})?[@][a-zA-Z0-9]{1,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2,})?$";
    public const string MOBILE_PATTERN = @"^[0-9]{2}[ ][0-9]{10}$";
    public const string PASSWORD_PATTERN = @"^(?!.*[!@#&()–\[{}\]:;',?/*~$^+=<>].*[!@#&()–\[{}\]:;',?/*~$^+=<>])(?=.*[A-Z])(?=.*[0-9]).{8,}$";

    // Registration details of user
    private string firstName;
    private string lastName;
    private string email;
    private string mobile;
    private string password;

    /// <summary>
    /// Gets the information from user.
    /// </summary>
    public void GetInfo()
    {
        try
        {
            firstName = GetValidInfo("First Name: ", NAME_PATTERN, UserRegistrationException.ExceptionType.INVALID_NAME);
            lastName = GetValidInfo("Last Name: ", NAME_PATTERN, UserRegistrationException.ExceptionType.INVALID_NAME);
            email = GetValidInfo("Email: ", EMAIL_PATTERN, UserRegistrationException.ExceptionType.INVALID_EMAIL);
            mobile = GetValidInfo("Mobile: ", MOBILE_PATTERN, UserRegistrationException.ExceptionType.INVALID_MOBILE);
            password = GetValidInfo("Password: ", PASSWORD_PATTERN, UserRegistrationException.ExceptionType.INVALID_PASSWORD);
        }
        catch (UserRegistrationException e)
        {
            switch (e.type)
            {
                case UserRegistrationException.ExceptionType.INVALID_NAME:
                    Console.WriteLine("Invalid Name! Must start with capital and min 3 letters");
                    break;
                case UserRegistrationException.ExceptionType.INVALID_EMAIL:
                    Console.WriteLine("Inavlid Email!");
                    break;
                case UserRegistrationException.ExceptionType.INVALID_MOBILE:
                    Console.WriteLine("Invalid Mobile! Must include country code, empty space and 10 numbers after that");
                    break;
                case UserRegistrationException.ExceptionType.INVALID_PASSWORD:
                    Console.WriteLine("Invalid Password! following rules apply:");
                    Console.WriteLine("1. Min 8 characters");
                    Console.WriteLine("2. At least 1 Uppercase");
                    Console.WriteLine("3. At least 1 number");
                    Console.WriteLine("4. Exactly 1 special character");
                    break;
                default:
                    Console.WriteLine(e.Message);
                    break;
            }
        }
    }

    /// <summary>
    /// Gets the valid information from user.
    /// <para>based on the pattern, this ensures the user enters valid info pattern</para>
    /// </summary>
    /// <returns>A valid info string</returns>
    private static string GetValidInfo(string message, string pattern, UserRegistrationException.ExceptionType type)
    {
        string info;
        try
        {
            Console.Write(message);
            info = Console.ReadLine();
            if (IsValid(info, pattern))
                return info;
            else
                throw new UserRegistrationException(type, "Does not match pattern");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Cannot give empty or null information");
        }
        return null;
    }

    /// <summary>
    /// Returns true if the info is valid i.e matches the pattern.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if the specified name is valid; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValid(string info, string pattern)
    {
        return Regex.IsMatch(info, pattern);
    }
}
