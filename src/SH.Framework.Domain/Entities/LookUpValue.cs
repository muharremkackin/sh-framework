using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Domain.Entities;

public class LookUpValue: Entity, IHasTitleColumn, IHasCodeColumn, IHasValueColumn, IHasOrderIdColumn
{
    public const string Schema = "App";
    public const string Table = nameof(LookUpValue);
    
    public Guid LookUpId { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Value { get; set; }
    public int? OrderId { get; set; }
    
    public LookUp LookUp { get; set; } = null!;
}