﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////


namespace SharedLib;

/// <summary>
/// CategoryRealBreezRuModel
/// </summary>
public class CategoryRealBreezRuModel : CategoryBreezRuModel
{
    /// <inheritdoc/>
    public required int Key { get; set; }

    /// <inheritdoc/>
    public static CategoryRealBreezRuModel Build(KeyValuePair<int, CategoryBreezRuModel> x)
    {
        return new()
        {
            Key = x.Key,
            Level = x.Value.Level,
            Title = x.Value.Title,
            CHPU = x.Value.CHPU,
            Order = x.Value.Order,
        };
    }
}