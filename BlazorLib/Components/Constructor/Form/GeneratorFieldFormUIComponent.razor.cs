﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using MudBlazor;
using SharedLib;

namespace BlazorLib.Components.Constructor.Form;

/// <inheritdoc/>
public partial class GeneratorFieldFormUIComponent : ComponentBase
{
    /// <inheritdoc/>
    [Inject]
    protected ISnackbar SnackbarRepo { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public required FieldFormConstructorModelDB FieldObject { get; set; }

    /// <inheritdoc/>
    [CascadingParameter, EditorRequired]
    public required Action<FieldFormBaseLowConstructorModel, Type> StateHasChangedHandler { get; set; }

    string? _generation_options;
    string? OptionsGeneration
    {
        get => _generation_options;
        set
        {
            _generation_options = value;
            FieldObject.SetValueOfMetadata(MetadataExtensionsFormFieldsEnum.Parameter, OptionsGeneration);
            FieldObject.SetValueOfMetadata(MetadataExtensionsFormFieldsEnum.Descriptor, SelectedGeneratorField);
            StateHasChangedHandler(FieldObject, GetType());
        }
    }

    IEnumerable<CommandEntryModel> Entries = [];
    string? selected_generator_field;

    DeclarationAbstraction? _declaration;

    /// <inheritdoc/>
    public string? SelectedGeneratorField
    {
        get => selected_generator_field;
        private set
        {
            selected_generator_field = value;
            FieldObject.SetValueOfMetadata(MetadataExtensionsFormFieldsEnum.Parameter, OptionsGeneration);
            FieldObject.SetValueOfMetadata(MetadataExtensionsFormFieldsEnum.Descriptor, SelectedGeneratorField);
            if (!string.IsNullOrEmpty(selected_generator_field))
                _declaration = DeclarationAbstraction.GetHandlerService(selected_generator_field);

            StateHasChangedHandler(FieldObject, GetType());
        }
    }

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        Entries = [.. DeclarationAbstraction.CommandsAsEntries<FieldValueGeneratorAbstraction>()];

        if (Entries.Any())
            SelectedGeneratorField = Entries.First().Id;
    }

    /// <inheritdoc/>
    public void Update(FieldFormBaseLowConstructorModel field)
    {
        FieldObject.Update(field);
        StateHasChanged();
    }
}