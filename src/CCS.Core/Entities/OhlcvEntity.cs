﻿namespace CCS.Core.Entities;

/// <summary>
/// Ohlcv entity
/// </summary>
public sealed class OhlcvEntity : EntityBase<Guid>
{
    public DateTime Timestamp { get; set; }

    public double Open { get; set; }

    public double Close { get; set; }

    public double High { get; set; }

    public double Low { get; set; }

    public double Volume { get; set; }
}
