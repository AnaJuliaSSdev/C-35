namespace TratamentoGlobalDeErros.Models;

public class ErrorDetails
{
    public string LogRef { get; private set; }
    public string Message { get; private set; }
    public string? StackTrace { get; private set; }

    public ErrorDetails(string logref, string message, string? stackTrace)
    {
        LogRef = logref;
        Message = message;
        StackTrace = stackTrace;
    }
}
