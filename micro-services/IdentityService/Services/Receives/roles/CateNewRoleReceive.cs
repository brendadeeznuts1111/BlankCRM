﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.Identity;

/// <summary>
/// Создать новую роль
/// </summary>
public class CateNewRoleReceive(IIdentityTools idRepo, ILogger<CateNewRoleReceive> loggerRepo)
    : IResponseReceive<string?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.CateNewRoleReceive;

    /// <summary>
    /// Создать новую роль
    /// </summary>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(string? roleName, CancellationToken token = default)
    {
        if(string.IsNullOrWhiteSpace(roleName))
            throw new ArgumentNullException(nameof(roleName));

        loggerRepo.LogWarning(JsonConvert.SerializeObject(roleName, GlobalStaticConstants.JsonSerializerSettings));
        return await idRepo.CreateNewRoleAsync(roleName, token);
    }
}