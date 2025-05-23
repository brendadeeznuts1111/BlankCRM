﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.storage;

/// <summary>
/// LogsSelectReceive
/// </summary>
public class LogsSelectReceive(ILogsService storeRepo) 
    : IResponseReceive<TPaginationRequestStandardModel<LogsSelectRequestModel>?, TPaginationResponseModel<NLogRecordModelDB>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.LogsSelectStorageReceive;

    /// <inheritdoc/>
    public async Task<TPaginationResponseModel<NLogRecordModelDB>?> ResponseHandleActionAsync(TPaginationRequestStandardModel<LogsSelectRequestModel>? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await storeRepo.LogsSelectAsync(payload, token);
    }
}