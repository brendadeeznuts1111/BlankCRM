﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.commerce;

/// <summary>
/// NomenclaturesReadReceive
/// </summary>
public class NomenclaturesReadReceive(ICommerceService commerceRepo)
    : IResponseReceive<TAuthRequestModel<int[]>?, TResponseModel<List<NomenclatureModelDB>>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.NomenclaturesReadCommerceReceive;

    /// <inheritdoc/>
    public async Task<TResponseModel<List<NomenclatureModelDB>>?> ResponseHandleActionAsync(TAuthRequestModel<int[]>? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        return await commerceRepo.NomenclaturesReadAsync(req, token);
    }
}