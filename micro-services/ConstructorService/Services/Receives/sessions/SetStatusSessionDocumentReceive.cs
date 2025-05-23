﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.constructor;

/// <summary>
/// Установить статус сессии (от менеджера)
/// </summary>
public class SetStatusSessionDocumentReceive(IConstructorService conService) : IResponseReceive<SessionStatusModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.SetStatusSessionDocumentReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(SessionStatusModel? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await conService.SetStatusSessionDocumentAsync(payload, token);
    }
}
