using System.Diagnostics.CodeAnalysis;

namespace Template.Utils.Test;

using Template.Utils.Logger;

public class UnitTest1
{
    private class DummyScanner: AuditLogger
    {
        public DummyScanner()
        {
            _auditType = AuditType.Scanner; 
        }

        public void TestLogging()
        {
            this.AuditLog("message");
        }
    }

    [Fact]
    public void TestLogger()
    {
        DummyScanner scanner = new();
        scanner.TestLogging();
    }

}