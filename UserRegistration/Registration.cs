using System.Text.RegularExpressions;

namespace UserRegistration;

/// <summary>
/// Takes details from user for registration form purposes
/// </summary>
internal class Registration
{
    // RegEx patterns for various types of information
    const string namePattern = @"^[A-Z][a-zA-Z]{2,}$";
    const string emailPattern = @"^[A-Za-z0-9]{3,}([.][A-Za-z0-9]{3,})?[@][a-zA-Z]{2,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2})?$";
    const string mobilePattern = @"^[0-9]{2}[ ][0-9]{10}$";
    const string passwordPattern = @"^(?!.*[!@#&()–\[{}\]:;',?/*~$^+=<>].*[!@#&()–\[{}\]:;',?/*~$^+=<>])(?=.*[A-Z])(?=.*[0-9]).{8,}$";

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
        firstName = GetValidInfo("First Name: ", namePattern);
        lastName = GetValidInfo("Last Name: ", namePattern);
        email = GetValidInfo("Email: ", emailPattern);
        mobile = GetValidInfo("Mobile: ", mobilePattern);
        password = GetValidInfo("Password: ", passwordPattern);
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
    private static bool IsValid(string info, string pattern)
    {
        return Regex.IsMatch(info, pattern);
    }
}
