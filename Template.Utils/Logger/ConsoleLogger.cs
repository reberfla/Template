namespace Template.Utils.Logger;

public class ConsoleLogger: IAuditLogger
{
    public void HandleMessage(AuditEntry message)
    {
        Console.WriteLine(message.ToString());
    }
}