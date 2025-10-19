using System.Diagnostics.CodeAnalysis;

namespace Template.Utils.Test;

using Template.Utils.Logger;

public class UnitTest1
{
    private class DummyScanner: AuditLogger
    {
        [SetsRequiredMembers]
        public DummyScanner()
        {
            _auditType = AuditType.Scanner; 
            Logger = new ConsoleLogger();
        }

        public string TestLogging()
        {
            return this.AuditLog("message");
        }
    }

    [Fact]
    public void TestLogger()
    {
        DummyScanner scanner = new();
        string message = scanner.TestLogging();
        Assert.Contains("Scanner", message);
        Assert.Contains("message", message);
    }

}