namespace Template.Utils.Logger;

public class ConsoleLogger: IAuditLogger
{
    public string HandleMessage(string message)
    {
        Console.WriteLine(message);
        return message;
    }
}