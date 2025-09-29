using System.Reflection;
using CSS.CctxClient.Interfaces;
using CSS.Core.Models;
using CSS.Core.Interfaces;

namespace CSS.Impl.Services;

internal sealed class OhlcvService(
    IOhlcvClient ohlcvClient,
    IOhlcvExportService exportService
    ) : IOhlcvService
{
    private readonly string _rootOutputDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..\\..\\output";

    /// <summary>
    /// Получение данных Ohlcv
    /// </summary>
    /// <param name="symbol">Символ отождествляющий валюту биржи</param>
    /// <param name="timeFrame">Время за которое необходимо выгрузить данные</param>
    /// <param name="since">Точка отчёта "с" (НЕ ТОЧНО)</param>
    /// <param name="limit">Ограничение кол-ва записей</param>
    /// <param name="parameters">Дополнительные параметры. Например "interval". 
    /// Параметр "category" ("linear") является обязательным для получения корректной информации</param>
    /// <returns></returns>
    public async Task<List<OhlcvModel>> Get(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null
    )
    {
        List<OhlcvModel> ohlcvList = await ohlcvClient.FetchOHLCV(
            parameters: parameters,
            symbol: symbol,
            timeFrame: timeFrame,
            since: since,
            limit: limit++);
        ohlcvList.RemoveAt(ohlcvList.Count - 1);

        string folderName = DateTime.UtcNow.ToString("dd-MM-yyyy_HH-mm-ss");
        string outputDir = Path.Combine(_rootOutputDir, folderName);
        Directory.CreateDirectory(outputDir);

        string csvPath = Path.Combine(outputDir, "OhlcvData.csv");
        string xlsxPath = Path.Combine(outputDir, "OhlcvData.xlsx");

        await exportService.ExportCsvAsync(ohlcvList, csvPath);
        await exportService.ExportXlsxAsync(ohlcvList, xlsxPath, "dd-MM-yyyy HH:mm:ss");

        return ohlcvList;
    }
}
