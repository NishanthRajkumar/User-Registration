using System.Text.RegularExpressions;

namespace UserRegistration;

/// <summary>
/// Takes details from user for registration form purposes
/// </summary>
internal class Registration
{
    private const string namePattern = @"^[A-Z][a-zA-Z]{2,}$";
    private const string emailPattern = @"^[A-Za-z0-9]{3,}([.][A-Za-z0-9]{3,})?[@][a-zA-Z]{2,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2})?$";


    private string firstName;
    private string lastName;
    private string email;

    public void GetInfo()
    {
        firstName = GetValidInfo("First Name: ", namePattern);
        lastName = GetValidInfo("Last Name: ", namePattern);
        email = GetValidInfo("Email: ", emailPattern);
    }

    private static string GetValidInfo(string message, string pattern)
    {
        string name;
        do
        {
            Console.Write(message);
            name = Console.ReadLine();
            if (IsValid(name, pattern))
                return name;
            else
                Console.WriteLine("Invalid! (First letter caps, Min 3 characters)");
        } while (true);
    }

    private static bool IsValid(string name, string pattern)
    {
        return Regex.IsMatch(name, pattern);
    }
}
