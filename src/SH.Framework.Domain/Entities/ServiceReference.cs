using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Domain.Entities;

public class ServiceReference : Entity, IHasTitleColumn, IHasHostColumn, IHasPortColumn, IHasUserNameColumn,
    IHasPasswordColumn, IHasKeyColumn, IHasSecretColumn, IHasAdditionalInfoColumn, IHasTypeIdColumn, IHasGroupIdColumn, IHasCategoryColumn
{
    public const string Schema = "App";
    public const string Table = nameof(ServiceReference);

    public string? Title { get; set; }

    public string? Host { get; set; }
    public int? Port { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Key { get; set; }
    public string? Secret { get; set; }
    public string? AdditionalInfo { get; set; }
    public int? TypeId { get; set; }
    public int? GroupId { get; set; }
    public string? CategoryId { get; set; }
}