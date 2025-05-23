﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.Extensions.Options;
using RemoteCallLib;
using SharedLib;
using TelegramBotService;

namespace Transmission.Receives.telegram;

/// <summary>
/// Get TelegramBot Token
/// </summary>
public class GetBotTokenReceive(IOptions<BotConfiguration> tgConfig, ILogger<GetBotTokenReceive> _logger) : IResponseReceive<object?, TResponseModel<string>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.GetBotTokenTelegramReceive;

    /// <inheritdoc/>
    public Task<TResponseModel<string>?> ResponseHandleActionAsync(object? payload, CancellationToken token = default)
    {
        _logger.LogInformation($"call `{GetType().Name}`");
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
        return Task.FromResult(new TResponseModel<string>() { Response = tgConfig.Value.BotToken });
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
    }
}