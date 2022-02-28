using System.Text.RegularExpressions;

namespace UserRegistration;

/// <summary>
/// Takes details from user for registration form purposes
/// </summary>
internal class Registration
{
    private string firstName;
    private string lastName;

    public void GetInfo()
    {
        firstName = GetValidName("First Name: ");
        lastName = GetValidName("Last Name: ");
    }

    private static string GetValidName(string message)
    {
        string name;
        do
        {
            Console.Write(message);
            name = Console.ReadLine();
            if (IsValidName(name))
                return name;
            else
                Console.WriteLine("Invalid! (First letter caps, Min 3 characters)");
        } while (true);
    }

    private static bool IsValidName(string name)
    {
        string pattern = @"^[A-Z][a-zA-Z]{2,}$";
        return Regex.IsMatch(name, pattern);
    }
}
