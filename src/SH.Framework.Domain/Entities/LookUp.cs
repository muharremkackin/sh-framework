using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Domain.Entities;

public class LookUp: Entity, IHasTitleColumn, IHasCodeColumn, IHasValueColumn
{
    public const string Schema = "App";
    public const string Table = nameof(LookUp);
    
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Value { get; set; }
    
    public IReadOnlyList<LookUpValue> Values { get; set; } = new List<LookUpValue>();
}