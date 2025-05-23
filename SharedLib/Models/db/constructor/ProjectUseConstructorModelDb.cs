﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SharedLib;

/// <summary>
/// Признак проекта как используемого
/// </summary>
[Index(nameof(UserId), IsUnique = true)]
public class ProjectUseConstructorModelDb
{
    /// <summary>
    /// Идентификатор/Key
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///  User (of Identity)
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Project
    /// </summary>
    public ProjectModelDb? Project { get; set; }

    /// <summary>
    /// Project
    /// </summary>
    public int ProjectId { get; set; }
}