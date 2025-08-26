namespace SH.Framework.Domain.Common.Columns;

public interface IHasSecretColumn
{
    public string? Secret { get; set; }
}