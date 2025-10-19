namespace Template.Utils.Logger;

public record AuditEntry
{
    private readonly DateTime _timestamp = DateTime.UtcNow;
    private readonly AuditType _type;
    private readonly string _description;

    public AuditEntry(AuditType type, string description)
    {
        _type = type;
        _description = description;
    }

    public override string ToString()
    {
        return $"{_timestamp.ToString("yyyy-M-d hh:mm:ss")} | {_type} | {_description}";
    }
}