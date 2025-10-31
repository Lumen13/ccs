namespace CCS.Core.Entities;

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

public sealed class Ohlcv1mEntity : EntityBase<Guid> { public Ohlcv1mEntity() { } public Ohlcv1mEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv3mEntity : EntityBase<Guid> { public Ohlcv3mEntity() { } public Ohlcv3mEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv5mEntity : EntityBase<Guid> { public Ohlcv5mEntity() { } public Ohlcv5mEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv15mEntity : EntityBase<Guid> { public Ohlcv15mEntity() { } public Ohlcv15mEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv30mEntity : EntityBase<Guid> { public Ohlcv30mEntity() { } public Ohlcv30mEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv1hEntity : EntityBase<Guid> { public Ohlcv1hEntity() { } public Ohlcv1hEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv2hEntity : EntityBase<Guid> { public Ohlcv2hEntity() { } public Ohlcv2hEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv4hEntity : EntityBase<Guid> { public Ohlcv4hEntity() { } public Ohlcv4hEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv6hEntity : EntityBase<Guid> { public Ohlcv6hEntity() { } public Ohlcv6hEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv12hEntity : EntityBase<Guid> { public Ohlcv12hEntity() { } public Ohlcv12hEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }
public sealed class Ohlcv1dEntity : EntityBase<Guid> { public Ohlcv1dEntity() { } public Ohlcv1dEntity(OhlcvEntity e) { Timestamp = e.Timestamp; Open = e.Open; Close = e.Close; High = e.High; Low = e.Low; Volume = e.Volume; } public DateTime Timestamp { get; set; } public double Open { get; set; } public double Close { get; set; } public double High { get; set; } public double Low { get; set; } public double Volume { get; set; } }