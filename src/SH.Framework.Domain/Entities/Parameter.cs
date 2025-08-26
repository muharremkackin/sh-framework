using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Domain.Entities;

public class Parameter: Entity, IHasTitleColumn, IHasCodeColumn, IHasValueColumn, IHasDeletableColumn
{
    public const string Schema = "App";
    public const string Table = nameof(Parameter);
    
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Value { get; set; }

    public bool Deletable { get; set; } = true;
}