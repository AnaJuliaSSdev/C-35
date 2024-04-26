namespace ToDoList.Models;

public class RequestLog
{
    public RequestLog(string requestMethod, string requestPath, string clientIpAddress, DateTime requestTimestamp,
        int responseStatusCode, long executionTimeInMilliseconds)
    {
        Id = Guid.NewGuid();
        RequestMethod = requestMethod;
        RequestPath = requestPath;
        ClientIpAddress = clientIpAddress;
        RequestTimestamp = requestTimestamp;
        ResponseStatusCode = responseStatusCode;
        ExecutionTimeInMilliseconds = executionTimeInMilliseconds; 
    }

    public Guid Id { get; set; }
    public string RequestMethod { get; set; }
    public string RequestPath { get; set; }
    public string ClientIpAddress { get; set; }
    public DateTime RequestTimestamp { get; set; }
    public int ResponseStatusCode { get; set; }
    public long ExecutionTimeInMilliseconds { get; set; }
}
