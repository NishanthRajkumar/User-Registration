using System.Text.RegularExpressions;

namespace UserRegistration;

/// <summary>
/// Takes details from user for registration form purposes
/// </summary>
public class Registration
{
    public delegate bool ValidityCheck(string input);
    public ValidityCheck patternMatch;

    // RegEx patterns for various types of information
    public const string NAME_PATTERN = @"^[A-Z][a-zA-Z]{2,}$";
    public const string EMAIL_PATTERN = @"^[A-Za-z0-9]{3,}([\.\-\+][A-Za-z0-9]{3,})?[@][a-zA-Z0-9]{1,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2,})?$";
    public const string MOBILE_PATTERN = @"^[0-9]{2}[ ][0-9]{10}$";
    public const string PASSWORD_PATTERN = @"^(?!.*[!@#&()–\[{}\]:;',?/*~$^+=<>].*[!@#&()–\[{}\]:;',?/*~$^+=<>])(?=.*[A-Z])(?=.*[0-9]).{8,}$";

    // Registration details of user
    private string? firstName;
    private string? lastName;
    private string? email;
    private string? mobile;
    private string? password;

    public Registration()
    {
        firstName = "";
        lastName = "";
        email = "";
        mobile = "";
        password = "";
    }

    /// <summary>
    /// Gets the information from user.
    /// </summary>
    public void GetInfo()
    {
        try
        {
            patternMatch = new((userInput) => { return Regex.IsMatch(userInput, NAME_PATTERN); });
            Console.Write("First Name: ");
            firstName = GetValidInfo(patternMatch, UserRegistrationException.ExceptionType.INVALID_NAME);
            Console.Write("Last Name: ");
            lastName = GetValidInfo(patternMatch, UserRegistrationException.ExceptionType.INVALID_NAME);
            patternMatch = new((userInput) => { return Regex.IsMatch(userInput, EMAIL_PATTERN); });
            Console.Write("Email: ");
            email = GetValidInfo(patternMatch, UserRegistrationException.ExceptionType.INVALID_EMAIL);
            patternMatch = new((userInput) => { return Regex.IsMatch(userInput, MOBILE_PATTERN); });
            Console.Write("Mobile: ");
            mobile = GetValidInfo(patternMatch, UserRegistrationException.ExceptionType.INVALID_MOBILE);
            patternMatch = new((userInput) => { return Regex.IsMatch(userInput, PASSWORD_PATTERN); });
            Console.Write("Password: ");
            password = GetValidInfo(patternMatch, UserRegistrationException.ExceptionType.INVALID_PASSWORD);
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
    private static string GetValidInfo(ValidityCheck Match, UserRegistrationException.ExceptionType type)
    {
        try
        {
            string info = Console.ReadLine();
            if (Match(info))
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
