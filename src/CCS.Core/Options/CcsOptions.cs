namespace CCS.Core.Options;

public sealed class CcsOptions
{
    private string? rootOutputDir;

    public ConnectionStringsOptions ConnectionStrings { get; set; } = new ConnectionStringsOptions();

    public int DbDefaultBatchSize { get; set; } = 1000;

    public string RootOutputDir
    {
        get
        {
            if (string.IsNullOrWhiteSpace(rootOutputDir))
            {
                throw new ArgumentNullException(nameof(RootOutputDir));
            }
            return rootOutputDir;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(RootOutputDir));
            }
            rootOutputDir = value;
        }
    }
}

public sealed class ConnectionStringsOptions
{
    public string? Postgres { get; set; }
}


