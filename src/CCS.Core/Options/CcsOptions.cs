using System.Reflection;

namespace CCS.Core.Options;

public sealed class CcsOptions
{
    private string rootOutputDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..\\..\\output";

    public ConnectionStringsOptions ConnectionStrings { get; set; } = new ConnectionStringsOptions();

    public int DbDefaultBatchSize { get; set; } = 1000;

    public string RootOutputDir
    {
        get => rootOutputDir;
        set => rootOutputDir = string.IsNullOrEmpty(value) ? rootOutputDir : value;
    }
}

public sealed class ConnectionStringsOptions
{
    public string? Postgres { get; set; }
}


