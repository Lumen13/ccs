using System.Reflection;
using CSS.CctxClient.Interfaces;
using CSS.CctxClient.Models;
using CSS.Core.Interfaces;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace CSS.Impl.Services;

internal sealed class OhlcvService(
    IOhlcvClient ohlcvClient
    ) : IOhlcvService
{
    private readonly string _filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..\\..\\" +
        $"output\\OhlcvData.json";

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
        StreamWriter streamWriter = new(_filePath, false);

        List<OhlcvModel> ohlcvList = await ohlcvClient.FetchOHLCV(
            parameters: parameters,
            symbol: symbol,
            timeFrame: timeFrame,
            since: since,
            limit: limit++);
        ohlcvList.RemoveAt(ohlcvList.Count - 1);

        string json = JsonConvert.SerializeObject(ohlcvList, Formatting.Indented);
        WriteLineToConsoleAndFile(ref streamWriter, json);

        streamWriter.Close();

        static void WriteLineToConsoleAndFile(ref StreamWriter streamWriter, string line)
        {
            Console.WriteLine(line);
            streamWriter.WriteLine(line);
        }

        return ohlcvList;
    }
}
