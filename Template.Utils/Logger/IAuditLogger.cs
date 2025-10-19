namespace Template.Utils.Logger;

public interface IAuditLogger
{
    public void HandleMessage(string message);
}