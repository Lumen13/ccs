using CSS.Core.Models;

namespace CSS.Core.Interfaces;

/// <summary>
/// Сервис для работы с данными OHLCV
/// </summary>
public interface IOhlcvService
{
    /// <summary>
    /// Основной метод получения данных Ohlcv
    /// </summary>
    /// <param name="symbol">Символ отождествляющий валюту биржи</param>
    /// <param name="timeFrame">Время за которое необходимо выгрузить данные</param>
    /// <param name="since">Точка отчёта "с" (НЕ ТОЧНО)</param>
    /// <param name="limit">Ограничение кол-ва записей</param>
    /// <param name="parameters">Дополнительные параметры. Например "interval". 
    /// Параметр "category" ("linear") является обязательным для получения корректной информации</param>
    /// <returns>Список Ohlcv в виде моделей Ohlcv</returns>
    Task<List<OhlcvModel>> Get(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null);
}
