﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;

namespace DbcLib;

/// <summary>
/// Промежуточный/общий слой контекста базы данных
/// </summary>
public partial class ApiBreezRuContext(DbContextOptions<ApiBreezRuContext> options) : ApiBreezRuLayerContext(options)
{

}