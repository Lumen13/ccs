namespace CCS.Core.Interfaces;

/// <summary>
/// Provides output directory paths for export operations
/// </summary>
public interface IExportPathProvider
{
    /// <summary>
    /// Return directory path to store export artifacts for the given timestamp.
    /// </summary>
    /// <param name="rootOutputDir">Root base directory for exports</param>
    /// <param name="nowUtc">Current UTC timestamp used for folder naming</param>
    /// <returns>Absolute directory path where files should be stored</returns>
    string GetOutputDirectory(string rootOutputDir, DateTime nowUtc);
}
