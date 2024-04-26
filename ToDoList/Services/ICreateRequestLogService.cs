using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ICreateRequestLogService
    {
        RequestLog CreateLogRequest(string requestMethod, string requestPath, string clientIpAddress, DateTime requestTimestamp,
        int responseStatusCode, long executionTimeInMilliseconds);
    }
}
