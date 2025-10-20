namespace Template.Utils.Logger;

public abstract class AuditLogger
{
    protected AuditType _auditType;
    private readonly IAuditLogger _logger = new ConsoleLogger();

    protected void WriteAuditLog(string description)
    {
        AuditEntry message = new(_auditType, description);
        _logger.HandleMessage(message);
    }
}