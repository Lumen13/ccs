using System.Globalization;
using System.Text;
using CSS.Core.Models;
using CSS.Core.Interfaces;
using ClosedXML.Excel;

namespace CSS.Impl.Services;

internal sealed class OhlcvExportService : IOhlcvExportService
{
    private readonly CultureInfo _culture = CultureInfo.InvariantCulture;

    public async Task ExportCsvAsync(IEnumerable<OhlcvModel> data, string filePath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
        using StreamWriter writer = new(fileStream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

        await writer.WriteLineAsync(
            $"{nameof(OhlcvModel.Timestamp)}, " +
            $"{nameof(OhlcvModel.Open)}, " +
            $"{nameof(OhlcvModel.High)}, " +
            $"{nameof(OhlcvModel.Low)}, " +
            $"{nameof(OhlcvModel.Close)}, " +
            $"{nameof(OhlcvModel.Volume)}"
        );

        foreach (var item in data)
        {
            string timestamp = item.Timestamp.ToString(_culture);
            string open = item.Open.ToString(_culture);
            string high = item.High.ToString(_culture);
            string low = item.Low.ToString(_culture);
            string close = item.Close.ToString(_culture);
            string volume = item.Volume.ToString(_culture);

            await writer.WriteLineAsync(string.Join(',', new[] { timestamp, open, high, low, close, volume }));
        }

        await writer.FlushAsync();
    }

    public Task ExportXlsxAsync(IEnumerable<OhlcvModel> data, string filePath, string dateFormat = "dd-MM-yyyy HH:mm:ss")
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        using XLWorkbook workbook = new();
        IXLWorksheet sheet = workbook.Worksheets.Add("OHLCV");

        // Header
        sheet.Cell(1, 1).Value = nameof(OhlcvModel.Timestamp);
        sheet.Cell(1, 2).Value = nameof(OhlcvModel.Open);
        sheet.Cell(1, 3).Value = nameof(OhlcvModel.High);
        sheet.Cell(1, 4).Value = nameof(OhlcvModel.Low);
        sheet.Cell(1, 5).Value = nameof(OhlcvModel.Close);
        sheet.Cell(1, 6).Value = nameof(OhlcvModel.Volume);
        sheet.Row(1).Style.Font.Bold = true;

        int row = 2;
        foreach (var item in data)
        {
            long ts = item.Timestamp;
            DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(ts).UtcDateTime;
            sheet.Cell(row, 1).Value = dt;
            sheet.Cell(row, 1).Style.DateFormat.Format = dateFormat;

            sheet.Cell(row, 2).Value = item.Open;
            sheet.Cell(row, 3).Value = item.High;
            sheet.Cell(row, 4).Value = item.Low;
            sheet.Cell(row, 5).Value = item.Close;
            sheet.Cell(row, 6).Value = item.Volume;

            row++;
        }

        sheet.Columns().AdjustToContents();

        workbook.SaveAs(filePath);

        return Task.CompletedTask;
    }
}


