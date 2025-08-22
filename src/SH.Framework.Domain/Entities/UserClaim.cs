using Microsoft.AspNetCore.Identity;
using SH.Framework.Domain.Common;

namespace SH.Framework.Domain.Entities;

public class UserClaim: IdentityUserClaim<Guid>, IEntity
{
    public const string Schema = "Identity";
    public const string Table = nameof(UserClaim);
}