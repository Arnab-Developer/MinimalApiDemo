namespace Lib1;

public class GreetServiceLib : IGreetServiceLib
{
    public string GetGreetMessage(string name, int serviceNumber) =>
        $"Hello {name}, this is greet {serviceNumber} service.";
}