using ToDoList.Models;

namespace ToDoList.Services;

public class CreateRequestLogService : ICreateRequestLogService
{
    public RequestLog CreateLogRequest(string requestMethod, string requestPath, string clientIpAddress, DateTime requestTimestamp,
        int responseStatusCode, long executionTimeInMilliseconds)
    {
        return new RequestLog(requestMethod, requestPath, clientIpAddress, requestTimestamp, responseStatusCode, executionTimeInMilliseconds);
    }
}
