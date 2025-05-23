﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.Identity;

/// <summary>
/// Отправка Email - receive
/// </summary>
public class SendEmailReceive(IMailProviderService mailRepo, ILogger<SendEmailReceive> _logger)
    : IResponseReceive<SendEmailRequestModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.SendEmailReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(SendEmailRequestModel? email_send, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(email_send);
        _logger.LogInformation($"call `{GetType().Name}`: {JsonConvert.SerializeObject(email_send, GlobalStaticConstants.JsonSerializerSettings)}");
        return await mailRepo.SendEmailAsync(email_send.Email, email_send.Subject, email_send.TextMessage, email_send.MimeType, token);
    }
}