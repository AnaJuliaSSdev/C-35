namespace ToDoList.Models;

public class ErrorResponse
{
    public string TraceId { get; private set; }
    public List<ErrorDetails> Errors { get; private set; }

    public ErrorResponse()
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = new List<ErrorDetails>();
    }

    public ErrorResponse(string logref, string message, string? stackTrace)
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = new List<ErrorDetails>();
        AddError(logref, message, stackTrace);
    }

    public void AddError(string logref, string message, string? stackTrace)
    {
        Errors.Add(new ErrorDetails(logref, message, stackTrace));
    }
}
