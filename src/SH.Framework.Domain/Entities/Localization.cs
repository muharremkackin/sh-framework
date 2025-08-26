using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Domain.Entities;

public class Localization: Entity, IHasCodeColumn, IHasValueColumn, IHasLanguageColumn
{
    public const string Schema = "App";
    public const string Table = nameof(Localization);
    
    public string? Code { get; set; }
    public string? Value { get; set; }
    public string? Language { get; set; }
}