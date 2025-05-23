﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.constructor;

/// <summary>
/// Удалить набор значений сессии опроса/анкеты по номеру строки [GroupByRowNum].
/// Если индекс ниже нуля - удаляются все значения для указанной JoinForm (полная очистка таблицы или очистка всех значений всех полей стандартной формы)
/// </summary>
public class DeleteValuesFieldsByGroupSessionDocumentDataByRowNumReceive(IConstructorService conService) : IResponseReceive<ValueFieldSessionDocumentDataBaseModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.DeleteValuesFieldsByGroupSessionDocumentDataByRowNumReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(ValueFieldSessionDocumentDataBaseModel? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await conService.DeleteValuesFieldsByGroupSessionDocumentDataByRowNumAsync(payload, token);
    }
}