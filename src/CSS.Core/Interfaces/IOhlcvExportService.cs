using CSS.Core.Models;

namespace CSS.Core.Interfaces;

/// <summary>
/// Service responsible for exporting OHLCV data to CSV files
/// </summary>
public interface IOhlcvExportService
{
    /// <summary>
    /// Export provided OHLCV data to CSV file. The method should overwrite existing file and always include header.
    /// </summary>
    /// <param name="data">Sequence of OHLCV rows to export (kept as-is, no reordering)</param>
    /// <param name="filePath">Target CSV file path</param>
    Task ExportCsvAsync(IEnumerable<OhlcvModel> data, string filePath);

    /// <summary>
    /// Export provided OHLCV data to XLSX file with human-readable timestamp column.
    /// </summary>
    /// <param name="data">Sequence of OHLCV rows to export (kept as-is, no reordering)</param>
    /// <param name="filePath">Target XLSX file path</param>
    /// <param name="dateFormat">Cell display format for timestamp column</param>
    Task ExportXlsxAsync(IEnumerable<OhlcvModel> data, string filePath, string dateFormat = "dd-MM-yyyy HH:mm:ss");
}


