﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.Identity;

/// <summary>
/// Get Role (by id)
/// </summary>
public class GetRoleReceive(IIdentityTools idRepo)
    : IResponseReceive<string?, TResponseModel<RoleInfoModel>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.GetRoleReceive;

    /// <summary>
    /// Get Role (by id)
    /// </summary>
    public async Task<TResponseModel<RoleInfoModel>?> ResponseHandleActionAsync(string? roleName, CancellationToken token = default)
    {
        if(string.IsNullOrWhiteSpace(roleName))
            throw new ArgumentNullException(nameof(roleName));
        
        return await idRepo.GetRoleAsync(roleName, token);
    }
}