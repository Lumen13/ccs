using CCS.Core.Interfaces;

namespace CCS.Impl.Services;

internal sealed class DefaultExportPathProvider : IExportPathProvider
{
    public string GetOutputDirectory(string rootOutputDir, DateTime nowUtc)
    {
        string folderName = nowUtc.ToString("dd-MM-yyyy_HH-mm-ss");
        string outputDir = Path.Combine(rootOutputDir, folderName);
        return outputDir;
    }
}
