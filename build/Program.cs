using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Frosting;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Common.Tools.DotNet.Test;
using Cake.Common.Tools.DotNet.Format;


public static class Program
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .Run(args);
    }
}

public class BuildContext : FrostingContext
{
    public string MsBuildConfiguration { get; set; }

    public BuildContext(ICakeContext context)
        : base(context)
    {
        MsBuildConfiguration = context.Argument("configuration", "Release");
    }
}

[TaskName("Format")]
public sealed class FormatTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetFormat("../Template.sln", new DotNetFormatSettings
        {
            Severity = DotNetFormatSeverity.Info,
            Verbosity = DotNetVerbosity.Minimal
        });
    }
}

[TaskName("FormatCheck")]
public sealed class FormatCheck : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetFormat("../Template.sln", new DotNetFormatSettings
                {
                Severity = DotNetFormatSeverity.Info,
                Verbosity = DotNetVerbosity.Minimal,
                VerifyNoChanges = true,
                });

    }
}

[TaskName("Clean")]
public sealed class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CleanDirectories($"../Template.*/bin/{context.MsBuildConfiguration}");
    }
}

[TaskName("Build")]
[IsDependentOn(typeof(CleanTask))]
public sealed class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetBuild("../Template.sln", new DotNetBuildSettings
        {
            Configuration = context.MsBuildConfiguration,
        });
    }
}

[TaskName("Test")]
[IsDependentOn(typeof(BuildTask))]
public sealed class TestTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetTest("../Template.sln", new DotNetTestSettings
        {
            Configuration = context.MsBuildConfiguration,
            NoBuild = true,
            Verbosity = DotNetVerbosity.Detailed
        });
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(TestTask))]
public class DefaultTask : FrostingTask
{
}