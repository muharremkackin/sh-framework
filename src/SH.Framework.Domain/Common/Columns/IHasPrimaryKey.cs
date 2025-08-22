namespace SH.Framework.Domain.Common.Columns;

public interface IHasPrimaryKey<TKey> where TKey : struct
{
    public TKey Id { get; set; }
}