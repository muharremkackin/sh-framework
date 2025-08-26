using SH.Framework.Library.Cqrs.Implementation;

namespace SH.Framework.Application.Common.Cqrs;

public class CustomResultCode
{
    public static ResultCode MaintenanceMode => ResultCode.Instance(1000, "Maintenance Mode");
}