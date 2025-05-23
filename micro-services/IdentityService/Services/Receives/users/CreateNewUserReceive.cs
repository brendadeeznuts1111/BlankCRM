﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;
using System.Net.Mail;

namespace Transmission.Receives.Identity;

/// <summary>
/// Регистрация нового email/пользователя без пароля (Identity)
/// </summary>
public class CreateNewUserReceive(IIdentityTools idRepo, ILogger<CreateNewUserReceive> loggerRepo)
    : IResponseReceive<string?, RegistrationNewUserResponseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.RegistrationNewUserReceive;

    /// <inheritdoc/>
    public async Task<RegistrationNewUserResponseModel?> ResponseHandleActionAsync(string? req, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(req) || !MailAddress.TryCreate(req, out _))
            throw new ArgumentNullException(nameof(req));

        loggerRepo.LogWarning(JsonConvert.SerializeObject(req, GlobalStaticConstants.JsonSerializerSettings));
        return await idRepo.CreateNewUserEmailAsync(req, token);
    }
}