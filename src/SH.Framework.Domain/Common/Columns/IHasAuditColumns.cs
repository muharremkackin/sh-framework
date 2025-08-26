namespace SH.Framework.Domain.Common.Columns;

public interface IHasAuditColumns<TType> 
{
    public DateTime? CreatedDate { get; set; }
    public TType? CreatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public TType? ModifiedById { get; set; }
    public DateTime? DeletedDate { get; set; }
    public TType? DeletedById { get; set; }
}