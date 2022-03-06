using System.Reflection;
using UserRegistration;

Console.Title = "User Registration";
Console.WriteLine("==========User Registration==========");

Console.WriteLine("Using Reflection to enter Registration form for a new user");
try
{
    Type type = typeof(Registration);
    var form = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("GetInfo");
    methodInfo.Invoke(form, null);
}
catch
{
    Console.WriteLine("Reflection failed");
}