using System.Globalization;
using System.Text;
using ClosedXML.Excel;
using CCS.Core.Constants;
using CCS.Core.Interfaces;
using CCS.Core.Models;

namespace CCS.Excel.Services;

internal sealed class ExportService : IExportService
{
    private readonly CultureInfo culture = CultureInfo.InvariantCulture;
    private readonly string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

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
            string timestamp = item.Timestamp.ToString(dateTimeFormat, culture);
            string open = item.Open.ToString(culture);
            string high = item.High.ToString(culture);
            string low = item.Low.ToString(culture);
            string close = item.Close.ToString(culture);
            string volume = item.Volume.ToString(culture);

            await writer.WriteLineAsync(string.Join(',', new[] { timestamp, open, high, low, close, volume }));
        }

        await writer.FlushAsync();
    }

    public Task ExportXlsxAsync(IEnumerable<OhlcvModel> data, string filePath, string dateFormat = DateTimeConstants.DateFormat)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        using XLWorkbook workbook = new();
        IXLWorksheet sheet = workbook.Worksheets.Add("OHLCV");

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
            sheet.Cell(row, 1).Value = item.Timestamp;
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
