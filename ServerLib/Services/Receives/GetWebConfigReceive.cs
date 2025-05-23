﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.Extensions.Options;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.web;

/// <summary>
/// Get web config - receive
/// </summary>
public class GetWebConfigReceive(IOptions<TelegramBotConfigModel> webConfig) : IResponseReceive<object?, TelegramBotConfigModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.GetWebConfigReceive;

    /// <inheritdoc/>
    public Task<TelegramBotConfigModel?> ResponseHandleActionAsync(object? payload = null, CancellationToken token = default)
    {
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
        return Task.FromResult(webConfig.Value);
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
    }
}