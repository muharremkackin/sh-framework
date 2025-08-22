using SH.Framework.Library.Cqrs;

namespace SH.Framework.Application.Common.Cqrs;

public abstract class Request: IRequest<Result>, IHasRequestId
{
    public Guid RequestId => Guid.NewGuid();
}

public abstract class Request<TResponse>: IRequest<Result<TResponse>>, IHasRequestId
{
    public Guid RequestId => Guid.NewGuid();
}

public abstract class Notification: INotification, IHasNotificationId
{
    public Guid NotificationId => Guid.NewGuid();
}

public class Result
{
    public virtual int Code {get; init;}
    public virtual string? Description {get; init;}
    public virtual bool IsSuccess => Code == 0;
    public virtual bool IsFailure => !IsSuccess;
    public virtual Dictionary<string, Dictionary<string, string>>? Errors {get; init;} = new();
    public Guid? RequestId {get; init;}
    
    public Result() {}

    public static Result Success(Guid? requestId = null) => new()
    {
        Code = ResultCode.Success.Code,
        Description = ResultCode.Success.Description,
        RequestId = requestId
    };

    public static Result Failure(int code, string description,
        Dictionary<string, Dictionary<string, string>>? errors = null, Guid? requestId = null) => new()
    {
        Code = code,
        Description = description,
        Errors = errors,
        RequestId = requestId
    };

    public static Result Failure(ResultCode resultCode, Dictionary<string, Dictionary<string, string>>? errors = null, Guid? requestId = null) => new()
    {
        Code = resultCode.Code,
        Description = resultCode.Description,
        Errors = errors,
        RequestId = requestId
    };

    public static Result<TResponse> Success<TResponse>(TResponse? data, Guid? requestId = null) => new()
    {
        Code = ResultCode.Success.Code,
        Description = ResultCode.Success.Description,
        Data = data,
        RequestId = requestId
    };

    public static Result<TResponse> Failure<TResponse>(int code, string description,
        Dictionary<string, Dictionary<string, string>>? errors = null, Guid? requestId = null) => new()
    {
        Code = code,
        Description = description,
        Errors = errors,
        RequestId = requestId   
    };
    
    public static Result<TResponse> Failure<TResponse>(ResultCode resultCode,
        Dictionary<string, Dictionary<string, string>>? errors = null, Guid? requestId = null) => new()
    {
        Code = resultCode.Code,
        Description = resultCode.Description,
        Errors = errors,
        RequestId = requestId   
    };
}

public class Result<TResponse>: Result
{
    public virtual TResponse? Data { get; set; }
    
    public Result(): base() {}
}

public class ResultCode
{
    public int Code { get;  }
    public string? Description { get;  }
    
    protected ResultCode(int code, string? description)
    {
        Code = code;
        Description = description;
    }
    
    public static ResultCode Instance(int code, string? description) => new(code, description);
    
    public static ResultCode Success => Instance(0, "Success");
    public static ResultCode Exception => Instance(1, "Exception");
    public static ResultCode InternalServerError => Instance(500, "Internal Server Error");
    public static ResultCode NotFound => Instance(404, "Not Found");
    public static ResultCode BadRequest => Instance(400, "Bad Request");
    public static ResultCode Unauthorized => Instance(401, "Unauthorized");
    public static ResultCode Forbidden => Instance(403, "Forbidden");
    public static ResultCode Conflict => Instance(409, "Conflict");
    public static ResultCode UnprocessableEntity => Instance(422, "Unprocessable Entity");
    public static ResultCode TooManyRequests => Instance(429, "Too Many Requests");
    public static ResultCode ServiceUnavailable => Instance(503, "Service Unavailable");
    public static ResultCode GatewayTimeout => Instance(504, "Gateway Timeout");
}

public abstract class RequestHandler<TRequest>: IRequestHandler<TRequest, Result> where TRequest: IHasRequestId, IRequest<Result>
{
    public abstract Task<Result> HandleAsync(TRequest request,
        CancellationToken cancellationToken = new());
}

public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IHasRequestId, IRequest<Result<TResponse>>
{
    public abstract Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken = new());
}

public abstract class RequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IHasRequestId, IRequest<TResponse> where TResponse : Result, new()
{
    public abstract Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken = new CancellationToken());
}

public abstract class NotificationBehavior<TNotification> : INotificationHandler<TNotification>
    where TNotification : INotification, IHasNotificationId
{
    public abstract Task HandleAsync(TNotification notification, CancellationToken cancellationToken = new());
}