namespace Template.Utils.Logger;

public abstract class AuditLogger
{
    protected AuditType _auditType;
    public required IAuditLogger Logger;

    protected string AuditLog(string description)
    {
        string dateTime = DateTime.UtcNow.ToString("yyyy-M-d");
        string message = $"time: {dateTime} | category: {_auditType} | {description}";
        Logger.HandleMessage(message);
        return message;
    }
}