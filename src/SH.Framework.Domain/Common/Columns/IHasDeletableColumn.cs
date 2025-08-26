namespace SH.Framework.Domain.Common.Columns;

public interface IHasDeletableColumn
{
    public bool Deletable { get; set; }
}