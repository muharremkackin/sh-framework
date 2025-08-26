using SH.Framework.Library.Cqrs.Implementation;

namespace SH.Framework.Application.Features.Authentication;

public class AuthenticationResultCode
{
    public static ResultCode UserNotFound => ResultCode.Instance(1000, "User Not Found");
}