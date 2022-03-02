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
        firstName = GetValidInfo("First Name: ", NAME_PATTERN);
        lastName = GetValidInfo("Last Name: ", NAME_PATTERN);
        email = GetValidInfo("Email: ", EMAIL_PATTERN);
        mobile = GetValidInfo("Mobile: ", MOBILE_PATTERN);
        password = GetValidInfo("Password: ", PASSWORD_PATTERN);
    }

    /// <summary>
    /// Gets the valid information from user.
    /// <para>based on the pattern, this ensures the user enters valid info pattern</para>
    /// </summary>
    /// <returns>A valid info string</returns>
    private static string GetValidInfo(string message, string pattern)
    {
        string info;
        do
        {
            Console.Write(message);
            info = Console.ReadLine();
            if (IsValid(info, pattern))
                return info;
            else
                Console.WriteLine("Invalid!");
        } while (true);
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
