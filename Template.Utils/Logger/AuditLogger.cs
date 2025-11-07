namespace Template.Utils.Logger;

public abstract class AuditLogger
{
    protected AuditType _auditType;
private readonly ConsoleLogger _logger = new();

    protected void WriteAuditLog(string description)
{
        AuditEntry message = new(_auditType, description);
        _logger.HandleMessage(message);
    }
}